using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exercises = await exerciseService.GetAllExercisesAsync();
            return View(exercises);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var exercise = await exerciseService.GetExerciseAsync(id);

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

        [HttpPost]
        public async Task<IActionResult> RestoreAll()
        {
            await exerciseService.RestoreAll();

            return RedirectToAction("Index", "Exercise");
        }
    }
}
