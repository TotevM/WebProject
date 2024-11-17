using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels.Workout;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class WorkoutController: Controller
    {
		private readonly ILogger<RecipeController> logger;
		private readonly UserManager<ApplicationUser> user;
		private readonly FitnessDBContext context;

		public WorkoutController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
		{
			logger = _logger;
			user = _user;
			context = _context;
		}

		public IActionResult Index()
        {
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var workouts = context.Workouts
				.Where(w => w.UsersWorkouts.Any(u => u.UserId == userId))
				.OrderByDescending(u => u.CreatedOn)
				.Select(w => new MyWorkoutsView
				{
					Id = w.Id,
					Name = w.Name,
					Exercises = context.Exercises
					.Where(e => e.WorkoutsExercises.Any(x => x.WorkoutId == w.Id && !x.IsDeleted))
					.Select(x => new ExercisesInMyWorkoutsView
					{
					Id=x.Id,
					Name = x.Name
					})
					.ToList()
				})
				.ToList();


            return View(workouts);
        }

		[HttpGet]
		public IActionResult AddToMyWorkouts()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var workouts = context.Workouts
				.Where(w => w.UserID==null && !w.UsersWorkouts.Any(u => u.UserId == userId))
				.OrderByDescending(u => u.CreatedOn)
				.Select(w => new MyWorkoutsView
				{
					Id = w.Id,
					Name = w.Name,
					Exercises = context.Exercises
					.Where(e => e.WorkoutsExercises.Any(x => x.WorkoutId == w.Id && !x.IsDeleted))
					.Select(x => new ExercisesInMyWorkoutsView
					{
						Id = x.Id,
						Name = x.Name
					})
					.ToList()
				})
				.ToList();


			return View(workouts);
		}

        [HttpPost]
        public IActionResult AddToMyWorkouts(Guid workoutId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			//Check if userworkout already exists

			var entry = new UserWorkout
			{
				WorkoutId = workoutId,
				UserId = userId
			};

			context.UsersWorkouts.Add(entry);
			context.SaveChanges();

			return RedirectToAction("Index", "Workout");
        }
    }
}
