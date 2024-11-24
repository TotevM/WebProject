using FitnessApp.Data.Models;
using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IExerciseService
    {
        Task<List<ExerciseIndexView>> GetAllExercisesAsync();
        Task<List<ExerciseIndexView>> GetInactiveExercisesAsync();
        Task<Exercise> GetExerciseAsync(Guid id);
        Task SetExerciseActivityAsync(Exercise exercise, bool isDeleted);
        Task ChangeExerciseWorkoutsStateAsync(Guid id, bool state);
        Task RestoreAll();
    }
}
