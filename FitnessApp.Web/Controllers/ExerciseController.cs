using FitnessApp.Data.Models;
using FitnessApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.ViewModels;
using FitnessApp.Services.ServiceContracts;

namespace FitnessApp.Web.Controllers
{
	public class ExerciseController : Controller
	{
		//private readonly ILogger<RecipeController> logger;
		//private readonly UserManager<ApplicationUser> user;
		//private readonly FitnessDBContext context;
		private readonly IExerciseService exerciseService;

		public ExerciseController(/*ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context,*/ IExerciseService exerciseService)
		{
			//this.logger = _logger;
   //         this.user = _user;
   //         this.context = _context;
            this.exerciseService= exerciseService;
        }

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var exercises = await exerciseService.GetAllExercisesAsync();
			return View(exercises);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			var exercise= await exerciseService.GetExerciseAsync(id);

			if (exercise == null)
			{
				return NotFound();
			}

			await exerciseService.ChangeExerciseWorkoutsStateAsync(id, true);

			await exerciseService.SetExerciseActivityAsync(exercise, true);

			return RedirectToAction("Index", "Exercise");
		}

		[HttpGet]
		public async Task<IActionResult> Restore()
		{
			var exercises = await exerciseService.GetInactiveExercisesAsync();
			return View(exercises);
		}

		[HttpPost]
		public async Task<IActionResult> Restore(Guid id)
		{
            var exercise = await exerciseService.GetExerciseAsync(id);

            if (exercise == null)
			{
				return NotFound();
			}

            await exerciseService.ChangeExerciseWorkoutsStateAsync(id, false);
            await exerciseService.SetExerciseActivityAsync(exercise, false);

            return RedirectToAction("Restore", "Exercise");
		}
	}
}
