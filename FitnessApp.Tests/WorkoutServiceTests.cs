using System.Linq.Expressions;
using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services;
using FitnessApp.ViewModels;
using Moq;
using NUnit.Framework;

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
        public async Task RemoveFromMyWorkoutsAsync_WorkoutExists_RemovesWorkout()
        {
            var _testWorkoutId = Guid.NewGuid();
            var _testUserId = Guid.NewGuid().ToString();

            var userWorkoutRecord = new UserWorkout
            {
                UserId = _testUserId,
                WorkoutId = _testWorkoutId
            };

            _userWorkoutRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserWorkout, bool>>>()))
                .ReturnsAsync(userWorkoutRecord);

            var result = await _workoutService.RemoveFromMyWorkoutsAsync(_testWorkoutId, _testUserId);

            Assert.IsTrue(result);

            _userWorkoutRepositoryMock.Verify(x => x.DeleteAsync(userWorkoutRecord), Times.Once);
        }


        [Test]
        public async Task RemoveFromDefaultWorkoutsAsync_WorkoutExists_ShouldDeleteWorkout()
        {
            var workoutGuid = Guid.NewGuid();
            var workout = new Workout { Id = workoutGuid };

            _workoutRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(It.Is<Expression<Func<Workout, bool>>>(
                    f => f.Compile()(workout))))
                .ReturnsAsync(workout);

            await _workoutService.RemoveFromDefaultWorkoutsAsync(workoutGuid);

            _workoutRepositoryMock.Verify(
                x => x.DeleteAsync(It.Is<Workout>(w => w.Id == workoutGuid)),
                Times.Once);
        }

        [Test]
        public async Task RemoveFromDefaultWorkoutsAsync_WorkoutNotFound_ShouldNotDeleteAnything()
        {
            var workoutGuid = Guid.NewGuid();

            _workoutRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<Workout, bool>>>()))
                .ReturnsAsync((Workout)null);

            await _workoutService.RemoveFromDefaultWorkoutsAsync(workoutGuid);

            _workoutRepositoryMock.Verify(
                x => x.DeleteAsync(It.IsAny<Workout>()),
                Times.Never);
        }

        [Test]
        public async Task RemoveFromDefaultWorkoutsAsync_RepositoryThrowsException_ShouldPropagateException()
        {
            var workoutGuid = Guid.NewGuid();
            var workout = new Workout { Id = workoutGuid };

            _workoutRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(It.Is<Expression<Func<Workout, bool>>>(
                    f => f.Compile()(workout))))
                .ReturnsAsync(workout);

            _workoutRepositoryMock
                .Setup(x => x.DeleteAsync(It.Is<Workout>(w => w.Id == workoutGuid)))
                .ThrowsAsync(new Exception("Database error"));

            var exception = Assert.ThrowsAsync<Exception>(
                async () => await _workoutService.RemoveFromDefaultWorkoutsAsync(workoutGuid)
            );
            Assert.That(exception.Message, Is.EqualTo("Database error"));
        }

        [Test]
        public async Task IsExerciseInWorkoutAsync_ShouldReturnTrue_WhenExerciseExistsInWorkout()
        {
            var workoutId = Guid.NewGuid();
            var exerciseId = Guid.NewGuid();
            var workoutExercise = new WorkoutExercise { WorkoutId = workoutId, ExerciseId = exerciseId };

            _workoutExerciseRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<WorkoutExercise, bool>>>()))
                .ReturnsAsync(workoutExercise);

            var result = await _workoutService.IsExerciseInWorkoutAsync(workoutId, exerciseId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsExerciseInWorkoutAsync_ShouldReturnFalse_WhenExerciseDoesNotExistInWorkout()
        {
            var workoutId = Guid.NewGuid();
            var exerciseId = Guid.NewGuid();

            _workoutExerciseRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<WorkoutExercise, bool>>>()))
                .ReturnsAsync((WorkoutExercise)null);

            var result = await _workoutService.IsExerciseInWorkoutAsync(workoutId, exerciseId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task WorkoutExist_ShouldReturnTrue_WhenWorkoutExists()
        {
            var workoutId = Guid.NewGuid();
            var workout = new Workout { Id = workoutId };

            _workoutRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Workout, bool>>>()))
                .ReturnsAsync(workout);

            var result = await _workoutService.WorkoutExist(workoutId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task WorkoutExist_ShouldReturnFalse_WhenWorkoutDoesNotExist()
        {
            var workoutId = Guid.NewGuid();

            _workoutRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Workout, bool>>>()))
                .ReturnsAsync((Workout)null);

            var result = await _workoutService.WorkoutExist(workoutId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task RemoveExerciseFromWorkout_ShouldReturnTrue_WhenExerciseExists()
        {
            var workoutId = Guid.NewGuid();
            var exerciseId = Guid.NewGuid();
            var workoutExercise = new WorkoutExercise { WorkoutId = workoutId, ExerciseId = exerciseId };

            _workoutExerciseRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<WorkoutExercise, bool>>>()))
                .ReturnsAsync(workoutExercise);

            var result = await _workoutService.RemoveExerciseFromWorkout(exerciseId, workoutId);

            Assert.IsTrue(result);
            _workoutExerciseRepositoryMock.Verify(repo => repo.DeleteAsync(workoutExercise), Times.Once);
        }

        [Test]
        public async Task RemoveExerciseFromWorkout_ShouldReturnFalse_WhenExerciseDoesNotExist()
        {
            var workoutId = Guid.NewGuid();
            var exerciseId = Guid.NewGuid();

            _workoutExerciseRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<WorkoutExercise, bool>>>()))
                .ReturnsAsync((WorkoutExercise)null);

            var result = await _workoutService.RemoveExerciseFromWorkout(exerciseId, workoutId);

            Assert.IsFalse(result);
            _workoutExerciseRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<WorkoutExercise>()), Times.Never);
        }

        [Test]
        public async Task GetWorkoutAsync_ShouldReturnWorkout_WhenWorkoutExists()
        {
            var workoutId = Guid.NewGuid();
            var workout = new Workout { Id = workoutId, Name = "Test Workout" };

            _workoutRepositoryMock
                .Setup(repo => repo.GetByIdAsync(workoutId))
                .ReturnsAsync(workout);

            var result = await _workoutService.GetWorkoutAsync(workoutId);

            Assert.IsNotNull(result);
            Assert.AreEqual(workoutId, result.Id);
            _workoutRepositoryMock.Verify(repo => repo.GetByIdAsync(workoutId), Times.Once);
        }

        [Test]
        public async Task AddUserWorkoutAsync_ShouldReturnFalse_WhenUserWorkoutAlreadyExists()
        {
            var workoutId = Guid.NewGuid();
            var userId = "user123";
            var existingRecord = new UserWorkout { WorkoutId = workoutId, UserId = userId };

            _userWorkoutRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<UserWorkout, bool>>>()))
                .ReturnsAsync(existingRecord);

            var result = await _workoutService.AddUserWorkoutAsync(workoutId, userId);

            Assert.IsFalse(result); 
        }

        [Test]
        public async Task AddUserWorkoutAsync_ShouldReturnTrue_WhenUserWorkoutDoesNotExist()
        {
            var workoutId = Guid.NewGuid();
            var userId = "user123";

            _userWorkoutRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<UserWorkout, bool>>>()))
                .ReturnsAsync((UserWorkout?)null);

            _userWorkoutRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<UserWorkout>()))
                .Returns(Task.CompletedTask);

            var result = await _workoutService.AddUserWorkoutAsync(workoutId, userId);

            Assert.IsTrue(result); 
            _userWorkoutRepositoryMock.Verify(repo => repo.AddAsync(It.Is<UserWorkout>(uw => uw.UserId == userId && uw.WorkoutId == workoutId)), Times.Once);
        }

        [Test]
        public async Task AddWorkoutsExercisesToWorkout_ShouldCallAddAsync_WhenValidWorkoutAndExerciseGuid()
        {
            var workout = new Workout { Id = Guid.NewGuid(), Name = "Strength Training", UserID = "user123" };
            var exerciseGuid = Guid.NewGuid();

            await _workoutService.AddWorkoutsExercisesToWorkout(workout, exerciseGuid);

            _workoutExerciseRepositoryMock.Verify(repo => repo.AddAsync(It.Is<WorkoutExercise>(we =>
                we.WorkoutId == workout.Id && we.ExerciseId == exerciseGuid)), Times.Once);
        }

        [Test]
        public async Task RemoveFromMyWorkoutsAsync_ShouldReturnFalse_WhenUserWorkoutDoesNotExist()
        {
            var workoutId = Guid.NewGuid();
            var userId = "user123";

            Expression<Func<UserWorkout, bool>> filter = uw => uw.UserId == userId && uw.WorkoutId == workoutId;

            _userWorkoutRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.Is<Expression<Func<UserWorkout, bool>>>(e => e.Body.ToString() == filter.Body.ToString())))
                .Returns(Task.FromResult<UserWorkout?>(null));

            var result = await _workoutService.RemoveFromMyWorkoutsAsync(workoutId, userId);

            Assert.IsFalse(result);
            _userWorkoutRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<UserWorkout>()), Times.Never);
        }

        [Test]
        public async Task CreateAndReturnWorkout_ShouldCreateWorkoutAndReturnIt()
        {
            var workoutDto = new WorkoutCreationViewModel
            {
                WorkoutName = "New Workout",
                UserId = "user123"
            };

            _workoutRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Workout>())).Returns(Task.CompletedTask);

            var result = await _workoutService.CreateAndReturnWorkout(workoutDto);

            Assert.NotNull(result);
            Assert.AreEqual(workoutDto.WorkoutName, result.Name);
            Assert.AreEqual(workoutDto.UserId, result.UserID);
            Assert.AreNotEqual(Guid.Empty, result.Id);
        }

        [Test]
        public async Task ExerciseExist_ShouldReturnTrue_WhenExerciseExists()
        {
            var exerciseId = Guid.NewGuid();
            var exercise = new Exercise { Id = exerciseId, Name = "Push Up" };

            _exerciseRepositoryMock.Setup(repo => repo.GetByIdAsync(exerciseId)).ReturnsAsync(exercise);

            var result = await _workoutService.ExerciseExist(exerciseId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExerciseExist_ShouldReturnFalse_WhenExerciseDoesNotExist()
        {
            var exerciseId = Guid.NewGuid();

            _exerciseRepositoryMock.Setup(repo => repo.GetByIdAsync(exerciseId)).ReturnsAsync((Exercise?)null);

            var result = await _workoutService.ExerciseExist(exerciseId);

            Assert.IsFalse(result);
        }
    }
}
