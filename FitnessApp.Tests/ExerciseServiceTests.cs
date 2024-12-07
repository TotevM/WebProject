using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FitnessApp.Tests
{
    [TestFixture]
    public class ExerciseServiceTests
    {
        private Mock<IRepository<Exercise, Guid>> _mockExerciseRepo;
        private Mock<IRepository<WorkoutExercise, object>> _mockWorkoutExerciseRepo;
        private IExerciseService _exerciseService;

        [SetUp]
        public void Setup()
        {
            _mockExerciseRepo = new Mock<IRepository<Exercise, Guid>>();
            _mockWorkoutExerciseRepo = new Mock<IRepository<WorkoutExercise, object>>();
            _exerciseService = new ExerciseService(_mockExerciseRepo.Object, _mockWorkoutExerciseRepo.Object);
        }

        [Test]
        public async Task GetExerciseByIdAsync_ShouldReturnExercise_WhenExerciseExists()
        {
            var exerciseGuid = Guid.NewGuid();
            var expectedExercise = new Exercise
            {
                Id = exerciseGuid,
                Name = "Push Up",
                Difficulty = Difficulty.Intermediate,
                MuscleGroup = MuscleGroup.Chest,
                ImageUrl = "pushup_image.jpg",
                IsDeleted = false,
                CreatedOn = DateTime.Now
            };

            _mockExerciseRepo.Setup(repo => repo.GetByIdAsync(exerciseGuid))
                .ReturnsAsync(expectedExercise);

            var result = await _exerciseService.GetExerciseByIdAsync(exerciseGuid);

            Assert.NotNull(result);
            Assert.AreEqual(expectedExercise.Id, result?.Id);
            Assert.AreEqual(expectedExercise.Name, result?.Name);
            Assert.AreEqual(expectedExercise.Difficulty, result?.Difficulty);
            Assert.AreEqual(expectedExercise.MuscleGroup, result?.MuscleGroup);
            Assert.AreEqual(expectedExercise.ImageUrl, result?.ImageUrl);
            Assert.AreEqual(expectedExercise.IsDeleted, result?.IsDeleted);
        }

        [Test]
        public async Task GetExerciseByIdAsync_ShouldReturnNull_WhenExerciseDoesNotExist()
        {
            var exerciseGuid = Guid.NewGuid();

            _mockExerciseRepo.Setup(repo => repo.GetByIdAsync(exerciseGuid))
                .ReturnsAsync((Exercise)null);

            var result = await _exerciseService.GetExerciseByIdAsync(exerciseGuid);

            Assert.IsNull(result);
        }

        [Test]
        public async Task AddExercise_ShouldCallAddAsyncOnRepository()
        {
            var model = new AddExerciseViewModel { ExerciseName = "Push Up", ImageUrl = "image.jpg" };
            var difficulty = Difficulty.Beginner;
            var muscleGroup = MuscleGroup.Chest;

            await _exerciseService.AddExercise(model, difficulty, muscleGroup);

            _mockExerciseRepo.Verify(repo => repo.AddAsync(It.IsAny<Exercise>()), Times.Once);
        }

        [Test]
        public void AddExerciseViewModel_ShouldReturnCorrectViewModel()
        {
            var result = _exerciseService.AddExerciseViewModel();

            Assert.NotNull(result);
            Assert.IsNotEmpty(result.Difficulties);
            Assert.IsNotEmpty(result.MuscleGroups);
        }


        [Test]
        public async Task EditExercise_ShouldUpdateExerciseProperties()
        {
            var exercise = new Exercise { Id = Guid.NewGuid(), Name = "Old Exercise", Difficulty = Difficulty.Beginner, MuscleGroup = MuscleGroup.Legs };
            var model = new AddExerciseViewModel { ExerciseName = "New Exercise", ImageUrl = "new_image.jpg" };
            var difficulty = Difficulty.Intermediate;
            var muscleGroup = MuscleGroup.Arms;

            await _exerciseService.EditExercise(exercise, model, difficulty, muscleGroup);

            Assert.AreEqual("New Exercise", exercise.Name);
            Assert.AreEqual(difficulty, exercise.Difficulty);
            Assert.AreEqual(muscleGroup, exercise.MuscleGroup);
            Assert.AreEqual("new_image.jpg", exercise.ImageUrl);
            _mockExerciseRepo.Verify(repo => repo.UpdateAsync(exercise), Times.Once);
        }


        [Test]
        public async Task GetExerciseAsync_ShouldReturnExerciseById()
        {
            var exerciseId = Guid.NewGuid();
            var exercise = new Exercise { Id = exerciseId, Name = "Push Up" };
            _mockExerciseRepo.Setup(repo => repo.GetByIdAsync(exerciseId)).Returns(Task.FromResult(exercise));

            var result = await _exerciseService.GetExerciseAsync(exerciseId);

            Assert.NotNull(result);
            Assert.AreEqual("Push Up", result?.Name);
        }

        [Test]
        public void MapToEditView_ShouldReturnCorrectViewModel()
        {
            var exercise = new Exercise { Id = Guid.NewGuid(), Name = "Push Up", Difficulty = Difficulty.Intermediate, MuscleGroup = MuscleGroup.Chest, ImageUrl = "image.jpg" };

            var result = _exerciseService.MapToEditView(exercise);

            Assert.NotNull(result);
            Assert.AreEqual("Push Up", result.ExerciseName);
            Assert.AreEqual(Difficulty.Intermediate.ToString(), result.Difficulty);
            Assert.AreEqual(MuscleGroup.Chest.ToString(), result.MuscleGroup);
        }

        [Test]
        public async Task SetExerciseActivityAsync_ShouldUpdateExerciseActivity()
        {
            var exercise = new Exercise { Id = Guid.NewGuid(), IsDeleted = false };
            var isDeleted = true;

            await _exerciseService.SetExerciseActivityAsync(exercise, isDeleted);

            Assert.AreEqual(isDeleted, exercise.IsDeleted);
            _mockExerciseRepo.Verify(repo => repo.UpdateAsync(exercise), Times.Once);
        }
    }
}
