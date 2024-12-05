using System.Security.Claims;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Web.Areas.Trainer.Controllers
{
    [Authorize(Roles = TrainerRole)]
    [Area(TrainerRole)]
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }


        [HttpGet]
        public async Task<IActionResult> ManageDefaultWorkouts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var workouts = await workoutService.DefaultWorkoutsForTrainers(userId!);

            return View(workouts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var availableExercises = await workoutService.GetAllExercisesModelAsync();

            ViewBag.AvailableExercises = availableExercises!;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWorkout(string workoutId)
        {

            Guid workoutGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(workoutId, ref workoutGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var workout = await workoutService.GetWorkoutAsync(workoutGuid);

            if (workout == null)
            {
                return NotFound();
            }

            await workoutService.RemoveFromDefaultWorkoutsAsync(workoutGuid);

            return RedirectToAction(nameof(ManageDefaultWorkouts));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExercise(string exerciseId, string workoutId)
        {
            Guid exerciseGuid = Guid.Empty;
            bool isExerciseGuidValid = IsGuidValid(exerciseId, ref exerciseGuid);

            Guid workoutGuid = Guid.Empty;
            bool isWorkoutGuidValid = IsGuidValid(workoutId, ref workoutGuid);

            if (!isExerciseGuidValid || !isWorkoutGuidValid)
            {
                return NotFound();
            }

            bool success = await workoutService.RemoveExerciseFromWorkout(exerciseGuid, workoutGuid);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(ManageDefaultWorkouts));
        }

    }
}
