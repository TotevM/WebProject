using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using FitnessApp.ViewModels.Workout;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IWorkoutService
    {
        Task<List<MyWorkoutsView>> MyWorkouts(string userId);
        Task<List<MyWorkoutsView>> DefaultWorkouts(string userId);
        Task<bool> AddUserWorkoutAsync(Guid workoutId, string userId);
        Task<bool> RemoveFromMyWorkoutsAsync(Guid workoutId, string userId);
        Task<List<ExerciseViewModel>> GetAllExercisesModelAsync();
        Task<bool> ExerciseExist(Guid exerciseGuid);
        Task<Workout> CreateAndReturnWorkout(WorkoutCreationViewModel workoutDto);
        Task AddWorkoutsExercisesToWorkout(Workout workout, Guid exerciseGuid);
        public Task<List<MyWorkoutsView>> DefaultWorkoutsForTrainers(string userId);
    }
}
