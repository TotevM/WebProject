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
    }
}
