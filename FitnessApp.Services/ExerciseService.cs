using FitnessApp.Common.Enumerations;
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

        public async Task AddExercise(AddExerciseViewModel model, Difficulty difficulty, MuscleGroup muscleGroup)
        {
            Exercise exercise = new Exercise
            {
                CreatedOn = DateTime.Now,
                Difficulty = difficulty,
                MuscleGroup = muscleGroup,
                IsDeleted = false,
                ImageUrl = model.ImageUrl,
                Name = model.ExerciseName
            };

            await exerciseRepository.AddAsync(exercise);
        }

        public AddExerciseViewModel AddExerciseViewModel()
        {
            var difficulties = Enum.GetValues(typeof(Difficulty))
                .Cast<Difficulty>()
                .ToList();

            var muscleGroups = Enum.GetValues(typeof(MuscleGroup))
                .Cast<MuscleGroup>()
                .ToList();

            var exerciseViewModel = new AddExerciseViewModel
            {
                Difficulties = difficulties,
                MuscleGroups = muscleGroups
            };

            return exerciseViewModel;
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

        public async Task EditExercise(Exercise exercise, AddExerciseViewModel model, Difficulty difficulty, MuscleGroup muscleGroup)
        {
            exercise.Difficulty = difficulty;
            exercise.Name = model.ExerciseName;
            exercise.MuscleGroup = muscleGroup;
            exercise.ImageUrl = model.ImageUrl;

            await exerciseRepository.UpdateAsync(exercise);
        }

        public async Task<List<ExerciseIndexView>> GetAllExercisesAsync()
        {
            var exercises = await exerciseRepository.GetAllAttached().Where(e => !e.IsDeleted)
                .OrderByDescending(e => e.CreatedOn)
                .Select(e => new ExerciseIndexView
                {
                    Id = e.Id.ToString(),
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

        public async Task<Exercise> GetExerciseByIdAsync(Guid exerciseGuid)
        {
            return await exerciseRepository.GetByIdAsync(exerciseGuid);
        }

        public async Task<List<ExerciseIndexView>> GetInactiveExercisesAsync()
        {
            var exercises = await exerciseRepository.GetAllAttached().Where(e => e.IsDeleted)
                .OrderByDescending(e => e.CreatedOn)
                .Select(e => new ExerciseIndexView
                {
                    Id = e.Id.ToString(),
                    Name = e.Name,
                    Difficulty = e.Difficulty.ToString(),
                    ImageUrl = e.ImageUrl,
                    MuscleGroup = e.MuscleGroup.ToString()
                }).ToListAsync();

            return exercises;
        }

        public AddExerciseViewModel MapToEditView(Exercise exercise)
        {
            var model = new AddExerciseViewModel
            {
                Id=exercise.Id.ToString(),
                ExerciseName = exercise.Name,
                Difficulty = exercise.Difficulty.ToString(),
                MuscleGroup = exercise.MuscleGroup.ToString(),
                ImageUrl = exercise.ImageUrl,
                Difficulties = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList(),
                MuscleGroups = Enum.GetValues(typeof(MuscleGroup)).Cast<MuscleGroup>().ToList()
            };

            return model;
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
