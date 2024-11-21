using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels.Workout;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository<Workout, Guid> workoutRepository;
        private readonly IRepository<Exercise, Guid> exerciseRepository;
        private readonly IRepository<UserWorkout, object> userWorkoutRepository;

        public WorkoutService(IRepository<Workout, Guid> workoutRepository, IRepository<Exercise, Guid> exerciseRepository, IRepository<UserWorkout, object> userWorkoutRepository)
        {
            this.workoutRepository = workoutRepository;
            this.exerciseRepository = exerciseRepository;
            this.userWorkoutRepository = userWorkoutRepository;
        }

        public async Task<bool> AddUserWorkoutAsync(Guid workoutId, string userId)
        {
            var record = await userWorkoutRepository.GetAllAttached().Where(x => x.UserId == userId && x.WorkoutId == workoutId).FirstOrDefaultAsync();
            
            if (record != null)
            {
                return false;
            }

            var entry = new UserWorkout
            {
                WorkoutId = workoutId,
                UserId = userId!
            };

            await userWorkoutRepository.AddAsync(entry);
            return true;
        }

        public async Task<List<MyWorkoutsView>> DefaultWorkouts(string userId)
        {
            var workouts = await workoutRepository.GetAllAttached()
                .Where(w => w.UserID == null && !w.UsersWorkouts.Any(u => u.UserId == userId))
                .OrderByDescending(u => u.CreatedOn)
                .Select(w => new MyWorkoutsView
                {
                    Id = w.Id,
                    Name = w.Name,
                    Exercises = exerciseRepository.GetAllAttached()
                    .Where(e => e.WorkoutsExercises.Any(x => x.WorkoutId == w.Id && !x.IsDeleted))
                    .Select(x => new ExercisesInMyWorkoutsView
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToList()
                })
                .ToListAsync();

            return workouts;
        }

        public async Task<List<MyWorkoutsView>> MyWorkouts(string userId)
        {
            List<MyWorkoutsView> workouts = await workoutRepository.GetAllAttached()
                .Where(w => w.UsersWorkouts.Any(u => u.UserId == userId))
                .OrderByDescending(u => u.CreatedOn)
                .Select(w => new MyWorkoutsView
                {
                    Id = w.Id,
                    Name = w.Name,
                    Exercises = exerciseRepository.GetAllAttached()
                    .Where(e => e.WorkoutsExercises.Any(x => x.WorkoutId == w.Id && !x.IsDeleted))
                    .Select(x => new ExercisesInMyWorkoutsView
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList()
                }).ToListAsync();

            return workouts;
        }

        public async Task<bool> RemoveFromMyWorkoutsAsync(Guid workoutId, string userId)
        {
            //Check if userworkout already exists

            var record = await userWorkoutRepository.GetAllAttached()
                .Where(uw => uw.UserId == userId && uw.WorkoutId == workoutId)
                .FirstOrDefaultAsync();

            if (record == null)
            {
                return false;
            }

            await userWorkoutRepository.DeleteAsync(record);
            return true;
        }
    }
}
