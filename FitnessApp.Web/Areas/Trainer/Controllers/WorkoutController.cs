using System.Security.Claims;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
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
            var workouts = await workoutService.DefaultWorkouts(null);

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

        [HttpPost]
        public async Task<IActionResult> AddExerciseToWorkout(AddExerciseToWorkoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //model.Exercises = await workoutService.GetExercisesSelectListAsync();
                return RedirectToAction(nameof(ManageDefaultWorkouts));
            }
            Guid workoutGuid = Guid.Empty;
            bool isWorkoutGuidValid = this.IsGuidValid(model.WorkoutId, ref workoutGuid);

            Guid exerciseGuid = Guid.Empty;
            bool isExerciseGuidValid = this.IsGuidValid(model.SelectedExerciseId, ref exerciseGuid);

            //TODO: Change redirection
            if (!isWorkoutGuidValid || !isExerciseGuidValid)
            {
                return RedirectToAction(nameof(ManageDefaultWorkouts));
            }

            bool recipeExists = await workoutService.ExerciseExist(exerciseGuid);
            bool dietExists = await workoutService.WorkoutExist(workoutGuid);

            if (!recipeExists || !dietExists)
            {
                //model.Exercises = await workoutService.GetExercisesSelectListAsync();
                //return View(model);
                return RedirectToAction(nameof(ManageDefaultWorkouts));
            }

            var isPresent = await workoutService.IsExerciseInWorkoutAsync(workoutGuid, exerciseGuid);
            if (isPresent)
            {
                TempData["ErrorMessage"] = "This exercise is already in this workout.";
                return RedirectToAction(nameof(ManageDefaultWorkouts));
                //TODO: change redirection
            }

            var workout = await workoutService.GetWorkoutAsync(workoutGuid);

            await workoutService.AddWorkoutsExercisesToWorkout(workout!, exerciseGuid);

            return RedirectToAction(nameof(ManageDefaultWorkouts));
        }
    }
}
