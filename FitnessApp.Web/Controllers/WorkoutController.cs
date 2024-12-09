using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.Services;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using FitnessApp.ViewModels.Workout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<MyWorkoutsView> workouts = await workoutService.MyWorkouts(userId!);

            return View(workouts);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyWorkouts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var workouts = await workoutService.DefaultWorkouts(userId!);

            return View(workouts);
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyWorkouts(string workoutId)
        {
            Guid workoutGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(workoutId, ref workoutGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool succeeded = await workoutService.AddUserWorkoutAsync(workoutGuid, userId!);

            if (!succeeded)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Workout");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromMyWorkouts(string workoutId)
        {

            Guid workoutGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(workoutId, ref workoutGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var succeeded = await workoutService.RemoveFromMyWorkoutsAsync(workoutGuid, userId!);

            if (!succeeded)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "Workout");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<ExerciseViewModel> availableExercises = await workoutService.GetAllExercisesModelAsync();

            ViewBag.AvailableExercises = availableExercises!;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExerciseToWorkout(AddExerciseToWorkoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            Guid workoutGuid = Guid.Empty;
            bool isWorkoutGuidValid = this.IsGuidValid(model.WorkoutId, ref workoutGuid);

            Guid exerciseGuid = Guid.Empty;
            bool isExerciseGuidValid = this.IsGuidValid(model.SelectedExerciseId, ref exerciseGuid);

            //TODO: Change redirection
            if (!isWorkoutGuidValid || !isExerciseGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var isDefault = await workoutService.IsDefaultWorkout(workoutGuid);
            if (isDefault)
            {
                return RedirectToAction(nameof(Index));
            }

            bool recipeExists = await workoutService.ExerciseExist(exerciseGuid);
            bool dietExists = await workoutService.WorkoutExist(workoutGuid);

            if (!recipeExists || !dietExists)
            {
                return RedirectToAction(nameof(Index));
            }

            var isPresent = await workoutService.IsExerciseInWorkoutAsync(workoutGuid, exerciseGuid);
            if (isPresent)
            {
                TempData["ErrorMessage"] = "This exercise is already in this workout.";
                return RedirectToAction(nameof(Index));
                //TODO: change redirection
            }

            var workout = await workoutService.GetWorkoutAsync(workoutGuid);

            await workoutService.AddWorkoutsExercisesToWorkout(workout!, exerciseGuid);

            return RedirectToAction(nameof(Index));
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

            var isDefault = await workoutService.IsDefaultWorkout(workoutGuid);
            if (isDefault)
            {
                return RedirectToAction(nameof(Index));
            }

            bool success = await workoutService.RemoveExerciseFromWorkout(exerciseGuid, workoutGuid);

            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
