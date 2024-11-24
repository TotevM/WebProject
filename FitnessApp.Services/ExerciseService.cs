using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class ExerciseService : BaseService, IExerciseService
    {
        private readonly IRepository<Exercise, Guid> exerciseRepository;
        private readonly IRepository<WorkoutExercise, object> workoutExerciseRepository;

        public ExerciseService(IRepository<Exercise, Guid> exerciseRepository, IRepository<WorkoutExercise, object> workoutExerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
            this.workoutExerciseRepository= workoutExerciseRepository;
        }

        public async Task ChangeExerciseWorkoutsStateAsync(Guid id, bool state)
        {
            List<WorkoutExercise> workoutExercise = await workoutExerciseRepository.GetAllAttached()
                .Where(we => we.ExerciseId == id).ToListAsync();

            foreach (var we in workoutExercise)
            {
                we.IsDeleted = state;
                await workoutExerciseRepository.UpdateAsync(we);
            }
        }

        public async Task<List<ExerciseIndexView>> GetAllExercisesAsync()
        {
            var exercises = await exerciseRepository.GetAllAttached().Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.CreatedOn)
                .Select(e => new ExerciseIndexView
                {
                    Id = e.Id,
                    Name = e.Name,
                    Difficulty = e.Difficulty.ToString(),
                    ImageUrl = e.ImageUrl,
                    MuscleGroup = e.MuscleGroup.ToString()
                }).ToListAsync();

            return exercises;
        }

        public async Task<Exercise> GetExerciseAsync(Guid id)
        {
            var exercise = await exerciseRepository.GetByIdAsync(id);
            return exercise;
        }

        public async Task<List<ExerciseIndexView>> GetInactiveExercisesAsync()
        {
            var exercises = await exerciseRepository.GetAllAttached().Where(e => e.IsDeleted)
                .OrderByDescending(e => e.CreatedOn)
                .Select(e => new ExerciseIndexView
                {
                    Id = e.Id,
                    Name = e.Name,
                    Difficulty = e.Difficulty.ToString(),
                    ImageUrl = e.ImageUrl,
                    MuscleGroup = e.MuscleGroup.ToString()
                }).ToListAsync();

            return exercises;
        }

        public async Task RestoreAll()
        {
            var exercises = await exerciseRepository.GetAllAttached().Where(x => x.IsDeleted).ToListAsync();

            foreach (var exercise in exercises)
            {
                exercise.IsDeleted = false;
                await exerciseRepository.UpdateAsync(exercise);
            }
        }

        public async Task SetExerciseActivityAsync(Exercise exercise, bool isDeleted)
        {
            exercise.IsDeleted = isDeleted;
            await exerciseRepository.UpdateAsync(exercise);
        }
    }
}
