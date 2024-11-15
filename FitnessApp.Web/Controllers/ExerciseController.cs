using FitnessApp.Data.Models;
using FitnessApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.ViewModels;

namespace FitnessApp.Web.Controllers
{
	public class ExerciseController : Controller
	{
		private readonly ILogger<RecipeController> logger;
		private readonly UserManager<ApplicationUser> user;
		private readonly FitnessDBContext context;

		public ExerciseController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
		{
			logger = _logger;
			user = _user;
			context = _context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var exercises = context.Exercises.Where(e => !e.IsDeleted)
				.OrderByDescending(e => e.CreatedOn)
				.Select(e => new ExerciseIndexView
				{
					Id=e.Id,
					Name = e.Name,
					Difficulty = e.Difficulty.ToString(),
					ImageUrl = e.ImageUrl,
					MuscleGroup = e.MuscleGroup.ToString()
				}).ToList();

			return View(exercises);
		}

		public IActionResult Delete(Guid id)
		{
			var exercise=context.Exercises.Where(ex => ex.Id == id).FirstOrDefault();

			if (exercise == null)
			{
				return NotFound();
			}

			var workoutExercise = context.WorkoutsExercises.Where(we => we.ExerciseId == id).ToList();

			context.RemoveRange(workoutExercise);
			exercise.IsDeleted=true;

			context.SaveChanges();

			return RedirectToAction("Index", "Exercise");
		}
	}
}
