using System.Security.Claims;
using FitnessApp.Services.ServiceContracts;
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
    }
}
