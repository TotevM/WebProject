using System.Security.Claims;
using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class WorkoutController : Controller
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
        public async Task<IActionResult> AddToMyWorkouts(Guid workoutId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool succeeded = await workoutService.AddUserWorkoutAsync(workoutId, userId!);

            if (!succeeded)
            {
                //implement logic to display that the realtion already exists
            }

            return RedirectToAction("Index", "Workout");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromMyWorkouts(Guid workoutId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var succeed = await workoutService.RemoveFromMyWorkoutsAsync(workoutId, userId!);

            if (!succeed)
            {
                //implement logic to display that the realtion already exists
            }

            return RedirectToAction("Index", "Workout");
        }
    }
}
