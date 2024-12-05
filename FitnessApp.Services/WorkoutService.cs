using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using FitnessApp.ViewModels.Workout;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository<Workout, Guid> workoutRepository;
        private readonly IRepository<Exercise, Guid> exerciseRepository;
        private readonly IRepository<UserWorkout, object> userWorkoutRepository;
        private readonly IRepository<WorkoutExercise, object> workoutExerciseRepository;

        public WorkoutService(IRepository<Workout, Guid> workoutRepository, IRepository<Exercise, Guid> exerciseRepository, IRepository<UserWorkout, object> userWorkoutRepository, IRepository<WorkoutExercise, object> workoutExerciseRepository)
        {
            this.workoutRepository = workoutRepository;
            this.exerciseRepository = exerciseRepository;
            this.userWorkoutRepository = userWorkoutRepository;
            this.workoutExerciseRepository = workoutExerciseRepository;
        }

        public async Task<bool> AddUserWorkoutAsync(Guid workoutId, string userId)
        {
            var record = await userWorkoutRepository.FirstOrDefaultAsync(x => x.UserId == userId && x.WorkoutId == workoutId)
                
                /*.GetAllAttached().Where(x => x.UserId == userId && x.WorkoutId == workoutId).FirstOrDefaultAsync()*/;
            
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

        public async Task<List<ExerciseViewModel>> GetAllExercisesModelAsync()
        {
            var availableExercises = await exerciseRepository.GetAllAttached()
                .Select(e => new ExerciseViewModel
                {
                    Id = e.Id.ToString(),
                    Name = e.Name,
                    MuscleGroup = e.MuscleGroup.ToString(),
                    Difficulty = e.Difficulty.ToString(),
                    IsDeleted = e.IsDeleted
                })
                .ToListAsync();

            return availableExercises!;
        }

        public async Task<List<MyWorkoutsView>> DefaultWorkoutsForTrainers(string userId)
        {
            var workouts = await workoutRepository.GetAllAttached()
                .Where(w => w.UserID == null)
                .OrderByDescending(u => u.CreatedOn)
                .Select(w => new MyWorkoutsView
                {
                    Id = w.Id.ToString(),
                    Name = w.Name,
                    Exercises = exerciseRepository.GetAllAttached()
                    .Where(e => e.WorkoutsExercises.Any(x => x.WorkoutId == w.Id && !x.IsDeleted))
                    .Select(x => new ExercisesInMyWorkoutsView
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name,
                        ImageUrl = x.ImageUrl
                    })
                    .ToList()
                })
                .ToListAsync();

            return workouts;
        }

        public async Task<List<MyWorkoutsView>> DefaultWorkouts(string userId)
        {
            var workouts = await workoutRepository.GetAllAttached()
                .Where(w => w.UserID == null && !w.UsersWorkouts.Any(u => u.UserId == userId))
                .OrderByDescending(u => u.CreatedOn)
                .Select(w => new MyWorkoutsView
                {
                    Id = w.Id.ToString(),
                    Name = w.Name,
                    Exercises = exerciseRepository.GetAllAttached()
                    .Where(e => e.WorkoutsExercises.Any(x => x.WorkoutId == w.Id && !x.IsDeleted))
                    .Select(x => new ExercisesInMyWorkoutsView
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name,
                        ImageUrl=x.ImageUrl
                    }).ToList()
                }).ToListAsync();

            return workouts;
        }

        public async Task<List<MyWorkoutsView>> MyWorkouts(string userId)
        {
            List<MyWorkoutsView> workouts = await workoutRepository.GetAllAttached()
                .Where(w => w.UsersWorkouts.Any(u => u.UserId == userId))
                .OrderByDescending(u => u.CreatedOn)
                .Select(w => new MyWorkoutsView
                {
                    Id = w.Id.ToString(),
                    Name = w.Name,
                    Exercises = exerciseRepository.GetAllAttached()
                    .Where(e => e.WorkoutsExercises.Any(x => x.WorkoutId == w.Id && !x.IsDeleted))
                    .Select(x => new ExercisesInMyWorkoutsView
                    {
                        Id = x.Id.ToString(),
                        Name = x.Name
                    }).ToList()
                }).ToListAsync();

            return workouts;
        }

        public async Task<bool> RemoveFromMyWorkoutsAsync(Guid workoutId, string userId)
        {
            //Check if userworkout already exists
            //tbd
            var record = await userWorkoutRepository
                .FirstOrDefaultAsync(uw => uw.UserId == userId && uw.WorkoutId == workoutId);

            if (record == null)
            {
                return false;
            }

            await userWorkoutRepository.DeleteAsync(record);
            return true;
        }

        public async Task<bool> ExerciseExist(Guid exerciseGuid)
        {
            var exercise=await exerciseRepository.GetByIdAsync(exerciseGuid);
            if (exercise==null)
            {
                return false;
            }
            return true;
        }

        public async Task<Workout> CreateAndReturnWorkout(WorkoutCreationViewModel workoutDto)
        {
            var workout = new Workout
            {
                Id = Guid.NewGuid(),
                Name = workoutDto.WorkoutName,
                UserID = workoutDto.UserId
            };

            await workoutRepository.AddAsync(workout);
            return workout;
        }

        public async Task AddWorkoutsExercisesToWorkout(Workout workout, Guid exerciseGuid)
        {
            await workoutExerciseRepository.AddAsync(new WorkoutExercise
            {
                ExerciseId = exerciseGuid,
                WorkoutId = workout.Id
            });
        }

        public async Task<Workout?> GetWorkoutAsync(Guid workoutGuid)
        {
            var model = await workoutRepository.GetByIdAsync(workoutGuid);

            return model;
        }

        public async Task RemoveFromDefaultWorkoutsAsync(Guid workoutGuid)
        {
            var usersWorkouts = await userWorkoutRepository.GetAllAttached().Where(x => x.WorkoutId == workoutGuid).ToListAsync();
            await userWorkoutRepository.RemoveRangeAsync(usersWorkouts);

            var workoutsExercises = await workoutExerciseRepository.GetAllAttached().Where(x => x.WorkoutId == workoutGuid).ToListAsync();
            await workoutExerciseRepository.RemoveRangeAsync(workoutsExercises);

            var workout = await workoutRepository.FirstOrDefaultAsync(x => x.Id == workoutGuid);
            if (workout != null)
            {
                await workoutRepository.DeleteAsync(workout);
            }
        }

        public async Task<bool> RemoveExerciseFromWorkout(Guid exerciseId, Guid workoutId)
        {
            var entry = await workoutExerciseRepository.FirstOrDefaultAsync(x => x.WorkoutId == workoutId && x.ExerciseId == exerciseId);

            if (entry == null)
            {
                return false;
            }
            await workoutExerciseRepository.DeleteAsync(entry);
            return true;
        }
    }
}
