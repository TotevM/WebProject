using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using FitnessApp.ViewModels.Workout;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IWorkoutService
    {
        Task<List<MyWorkoutsView>> MyWorkouts(string userId);
        Task<List<MyWorkoutsView>> DefaultWorkouts(string? userId);
        Task<bool> AddUserWorkoutAsync(Guid workoutId, string userId);
        Task<bool> RemoveFromMyWorkoutsAsync(Guid workoutId, string userId);
        Task<List<ExerciseViewModel>> GetAllExercisesModelAsync();
        Task<bool> ExerciseExist(Guid exerciseGuid);
        Task<bool> WorkoutExist(Guid workoutGuid);
        Task<Workout> CreateAndReturnWorkout(WorkoutCreationViewModel workoutDto);
        Task AddWorkoutsExercisesToWorkout(Workout workout, Guid exerciseGuid);
        //Task<List<MyWorkoutsView>> DefaultWorkoutsForTrainers(string userId);
        Task<Workout?> GetWorkoutAsync(Guid workoutGuid);
        Task RemoveFromDefaultWorkoutsAsync(Guid workoutGuid);
        Task<bool> RemoveExerciseFromWorkout(Guid exerciseId, Guid workoutId);
        Task<bool> IsExerciseInWorkoutAsync(Guid workoutId, Guid selectedExerciseId);
        Task<List<SelectListItem>> GetExercisesSelectListAsync();
    }
}
