using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FitnessApp.ViewModels;
using System.Linq.Expressions;

namespace FitnessApp.Tests
{
    [TestFixture]
    public class WorkoutServiceTests
    {
        private Mock<IRepository<Workout, Guid>> _workoutRepositoryMock;
        private Mock<IRepository<Exercise, Guid>> _exerciseRepositoryMock;
        private Mock<IRepository<UserWorkout, object>> _userWorkoutRepositoryMock;
        private Mock<IRepository<WorkoutExercise, object>> _workoutExerciseRepositoryMock;
        private WorkoutService _workoutService;

        [SetUp]
        public void SetUp()
        {
            _workoutRepositoryMock = new Mock<IRepository<Workout, Guid>>();
            _exerciseRepositoryMock = new Mock<IRepository<Exercise, Guid>>();
            _userWorkoutRepositoryMock = new Mock<IRepository<UserWorkout, object>>();
            _workoutExerciseRepositoryMock = new Mock<IRepository<WorkoutExercise, object>>();

            _workoutService = new WorkoutService(
                _workoutRepositoryMock.Object,
                _exerciseRepositoryMock.Object,
                _userWorkoutRepositoryMock.Object,
                _workoutExerciseRepositoryMock.Object
            );
        }

        [Test]
        public async Task AddUserWorkoutAsync_ShouldReturnFalse_WhenUserWorkoutAlreadyExists()
        {
            // Arrange
            var workoutId = Guid.NewGuid();
            var userId = "user123";
            var existingRecord = new UserWorkout { WorkoutId = workoutId, UserId = userId };

            // Mock the repository to return an existing UserWorkout
            _userWorkoutRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<UserWorkout, bool>>>()))
                .ReturnsAsync(existingRecord);

            // Act
            var result = await _workoutService.AddUserWorkoutAsync(workoutId, userId);

            // Assert
            Assert.IsFalse(result); // Should return false since the record exists
        }

        [Test]
        public async Task AddUserWorkoutAsync_ShouldReturnTrue_WhenUserWorkoutDoesNotExist()
        {
            // Arrange
            var workoutId = Guid.NewGuid();
            var userId = "user123";

            // Mock the repository to return null (no existing record)
            _userWorkoutRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<UserWorkout, bool>>>()))
                .ReturnsAsync((UserWorkout?)null);

            // Mock the AddAsync to return a completed task
            _userWorkoutRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<UserWorkout>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _workoutService.AddUserWorkoutAsync(workoutId, userId);

            // Assert
            Assert.IsTrue(result); // Should return true since no record exists
            _userWorkoutRepositoryMock.Verify(repo => repo.AddAsync(It.Is<UserWorkout>(uw => uw.UserId == userId && uw.WorkoutId == workoutId)), Times.Once);
        }




        [Test]
        public async Task AddWorkoutsExercisesToWorkout_ShouldCallAddAsync_WhenValidWorkoutAndExerciseGuid()
        {
            // Arrange
            var workout = new Workout { Id = Guid.NewGuid(), Name = "Strength Training", UserID = "user123" };
            var exerciseGuid = Guid.NewGuid();

            // Act
            await _workoutService.AddWorkoutsExercisesToWorkout(workout, exerciseGuid);

            // Assert
            _workoutExerciseRepositoryMock.Verify(repo => repo.AddAsync(It.Is<WorkoutExercise>(we =>
                we.WorkoutId == workout.Id && we.ExerciseId == exerciseGuid)), Times.Once);
        }






        [Test]
        public async Task RemoveFromMyWorkoutsAsync_ShouldReturnFalse_WhenUserWorkoutDoesNotExist()
        {
            // Arrange
            var workoutId = Guid.NewGuid();
            var userId = "user123";

            // Create the Expression<Func<T, bool>> for the filter
            Expression<Func<UserWorkout, bool>> filter = uw => uw.UserId == userId && uw.WorkoutId == workoutId;

            // Mock repository methods (synchronously returning wrapped in Task)
            _userWorkoutRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.Is<Expression<Func<UserWorkout, bool>>>(e => e.Body.ToString() == filter.Body.ToString())))
                .Returns(Task.FromResult<UserWorkout?>(null));  // Simulate that no record exists.

            // Act
            var result = await _workoutService.RemoveFromMyWorkoutsAsync(workoutId, userId);

            // Assert
            Assert.IsFalse(result);
            _userWorkoutRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<UserWorkout>()), Times.Never);
        }



        [Test]
        public async Task CreateAndReturnWorkout_ShouldCreateWorkoutAndReturnIt()
        {
            // Arrange
            var workoutDto = new WorkoutCreationViewModel
            {
                WorkoutName = "New Workout",
                UserId = "user123"
            };

            // Mock AddAsync to simulate adding the workout (no actual repository interaction)
            _workoutRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Workout>())).Returns(Task.CompletedTask);

            // Act
            var result = await _workoutService.CreateAndReturnWorkout(workoutDto);

            // Assert
            Assert.NotNull(result);  // Ensure the result is not null
            Assert.AreEqual(workoutDto.WorkoutName, result.Name);  // Ensure the Name matches
            Assert.AreEqual(workoutDto.UserId, result.UserID);  // Ensure the UserId matches
            Assert.AreNotEqual(Guid.Empty, result.Id);  // Ensure a valid GUID is assigned
        }



        //[Test]
        //public async Task AddUserWorkoutAsync_ShouldReturnFalse_WhenUserWorkoutAlreadyExists()
        //{
        //    // Arrange
        //    var workoutId = Guid.NewGuid();
        //    var userId = "user123";
        //    var existingRecord = new UserWorkout { WorkoutId = workoutId, UserId = userId };

        //    // Mock the GetAllAttached method to return a collection containing the existing user-workout record
        //    _userWorkoutRepositoryMock.Setup(repo => repo.GetAllAttached())
        //        .Returns(new List<UserWorkout> { existingRecord }.AsQueryable()); // Convert list to IQueryable

        //    // Act
        //    var result = await _workoutService.AddUserWorkoutAsync(workoutId, userId);

        //    // Assert
        //    Assert.IsFalse(result);  // Expecting false because the user-workout already exists
        //}











        [Test]
        public async Task ExerciseExist_ShouldReturnTrue_WhenExerciseExists()
        {
            // Arrange
            var exerciseId = Guid.NewGuid();
            var exercise = new Exercise { Id = exerciseId, Name = "Push Up" };

            _exerciseRepositoryMock.Setup(repo => repo.GetByIdAsync(exerciseId)).ReturnsAsync(exercise);

            // Act
            var result = await _workoutService.ExerciseExist(exerciseId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExerciseExist_ShouldReturnFalse_WhenExerciseDoesNotExist()
        {
            // Arrange
            var exerciseId = Guid.NewGuid();

            _exerciseRepositoryMock.Setup(repo => repo.GetByIdAsync(exerciseId)).ReturnsAsync((Exercise?)null);

            // Act
            var result = await _workoutService.ExerciseExist(exerciseId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
