using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.Services;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class WorkoutController : BaseController
    {
        private readonly IWorkoutService workoutService;
        private readonly FitnessDBContext context;

        public WorkoutController(IWorkoutService workoutService, FitnessDBContext context)
        {
            this.workoutService = workoutService;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var workouts = await workoutService.MyWorkouts(userId!);

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
                return BadRequest();
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
                return BadRequest();
            }

            return RedirectToAction("Index", "Workout");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var availableExercises = await workoutService.GetAllExercisesModelAsync();

            ViewBag.AvailableExercises = availableExercises!;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkoutCreationViewModel workoutViewModel)
        {
            if (ModelState.IsValid)
            {
                var workout = new Workout
                {
                    Id = Guid.NewGuid(),
                    Name = workoutViewModel.WorkoutName
                };

                foreach (var exerciseId in workoutViewModel.SelectedExerciseIds)
                {
                    Guid exerciseGuid=Guid.Empty;
                    bool success = Guid.TryParse(exerciseId, out exerciseGuid);
                    if (!success)
                    {
                        return NotFound();
                    }

                    bool exists = await workoutService.WorkoutExists(exerciseGuid);
                    if (!exists)
                    {
                        return NotFound();
                    }

                    workout.WorkoutsExercises.Add(new WorkoutExercise
                    {
                        ExerciseId = exerciseGuid,
                        WorkoutId=workout.Id
                    });
                }

                context.Workouts.Add(workout);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            var availableExercises = await workoutService.GetAllExercisesModelAsync();

            ViewBag.AvailableExercises = availableExercises!;
            return View(workoutViewModel);
        }
    }
}
