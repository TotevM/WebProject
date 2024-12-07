using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IExerciseService
    {
        Task<List<ExerciseIndexView>> GetAllExercisesAsync(bool areDeleted);
        Task<Exercise?> GetExerciseAsync(Guid id);
        Task SetExerciseActivityAsync(Exercise exercise, bool isDeleted);
        Task ChangeExerciseWorkoutsStateAsync(Guid id, bool state);
        Task RestoreAll();
        AddExerciseViewModel AddExerciseViewModel();
        Task AddExercise(AddExerciseViewModel model, Difficulty difficulty, MuscleGroup muscleGroup);
        Task<Exercise?> GetExerciseByIdAsync(Guid exerciseGuid);
        AddExerciseViewModel MapToEditView(Exercise exercise);
        Task EditExercise(Exercise exercise, AddExerciseViewModel model, Difficulty difficulty, MuscleGroup muscleGroup);
    }
}
