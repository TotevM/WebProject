using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;
using System.Linq.Expressions;

namespace FitnessApp.Tests
{
    [TestFixture]
    public class DietServiceTests
    {
        private Mock<IRepository<Diet, Guid>> _dietRepositoryMock;
        private Mock<IRepository<Recipe, Guid>> _recipeRepositoryMock;
        private Mock<IRepository<DietRecipe, object>> _dietRecipeRepositoryMock;
        private Mock<IRepository<UserDiet, object>> _userDietRepositoryMock;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;
        private DietService _dietService;
        private RecipeService _recipeService;

        [SetUp]
        public void SetUp()
        {
            _dietRepositoryMock = new Mock<IRepository<Diet, Guid>>();
            _recipeRepositoryMock = new Mock<IRepository<Recipe, Guid>>();
            _dietRecipeRepositoryMock = new Mock<IRepository<DietRecipe, object>>();
            _userDietRepositoryMock = new Mock<IRepository<UserDiet, object>>();


            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            _dietService = new DietService(
                _userManagerMock.Object,
                _dietRepositoryMock.Object,
                _recipeRepositoryMock.Object,
                _dietRecipeRepositoryMock.Object,
                _userDietRepositoryMock.Object);
        }


        [Test]
        public async Task AddUserDietAsync_WhenUserDietDoesNotExist_ShouldAddUserDietAndReturnTrue()
        {
            var dietGuid = Guid.NewGuid();
            var userId = "testUser123";

            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(
                    It.Is<System.Linq.Expressions.Expression<Func<UserDiet, bool>>>(
                        predicate => CheckUserDietPredicate(predicate, userId, dietGuid))))
                .ReturnsAsync((UserDiet)null);

            _userDietRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<UserDiet>()))
                .Returns(Task.CompletedTask);

            var result = await _dietService.AddUserDietAsync(dietGuid, userId);

            Assert.IsTrue(result);
            _userDietRepositoryMock.Verify(
                repo => repo.AddAsync(It.Is<UserDiet>(
                    ud => ud.UserId == userId && ud.DietId == dietGuid)),
                Times.Once);
        }

        [Test]
        public async Task AddUserDietAsync_WhenUserDietAlreadyExists_ShouldNotAddAndReturnFalse()
        {
            var dietGuid = Guid.NewGuid();
            var userId = "testUser123";

            var existingUserDiet = new UserDiet
            {
                UserId = userId,
                DietId = dietGuid
            };

            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(
                    It.Is<System.Linq.Expressions.Expression<Func<UserDiet, bool>>>(
                        predicate => CheckUserDietPredicate(predicate, userId, dietGuid))))
                .ReturnsAsync(existingUserDiet);

            var result = await _dietService.AddUserDietAsync(dietGuid, userId);

            Assert.IsFalse(result);
            _userDietRepositoryMock.Verify(
                repo => repo.AddAsync(It.IsAny<UserDiet>()),
                Times.Never);
        }

        [Test]
        public async Task DeleteDiet_WithValidDietId_DeletesDiet()
        {
            var testDietId = Guid.NewGuid();

            var mockDiet = new Diet
            {
                Id = testDietId,
                Name = "Test Diet",
                Calories = 1500,
                Proteins = 50,
                Carbohydrates = 200,
                Fats = 60,
                UserDiets = new List<UserDiet>()
            };

            _dietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<Diet, bool>>>()))
                .ReturnsAsync(mockDiet);

            await _dietService.DeleteDiet(testDietId);

            _dietRepositoryMock.Verify(repo => repo.FirstOrDefaultAsync(It.Is<Expression<Func<Diet, bool>>>(expr =>
                expr.Compile().Invoke(mockDiet))), Times.Once);

            _dietRepositoryMock.Verify(repo => repo.DeleteAsync(It.Is<Diet>(d => d.Id == testDietId)), Times.Once);
        }

        [Test]
        public async Task DefaultDietsAsync_WithUserId_FiltersOutUserDiets()
        {
            string testUserId = "test-user-id";

            var dietMockData = new List<Diet>
        {
            new Diet
            {
                Id = Guid.NewGuid(),
                Name = "Diet 1",
                ImageUrl = "/images/diet1.jpg",
                Calories = 1200,
                Proteins = 50,
                Carbohydrates = 150,
                Fats = 40,
                UserDiets = new List<UserDiet>
                {
                    new UserDiet { UserId = testUserId }
                }
            },
            new Diet
            {
                Id = Guid.NewGuid(),
                Name = "Diet 2",
                ImageUrl = "/images/diet2.jpg",
                Calories = 1400,
                Proteins = 60,
                Carbohydrates = 170,
                Fats = 45,
                UserDiets = new List<UserDiet>()
            }
        };

            var dietMockQueryable = dietMockData.AsQueryable().BuildMock();
            _dietRepositoryMock
                .Setup(repo => repo.GetAllAttached()).Returns(dietMockQueryable);

            var result = await _dietService.DefaultDietsAsync(testUserId);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var returnedDiet = result.First();
            Assert.AreEqual("Diet 2", returnedDiet.Name);
            Assert.AreEqual("/images/diet2.jpg", returnedDiet.ImageUrl);
            Assert.AreEqual(1400, returnedDiet.Calories);
            Assert.AreEqual(60, returnedDiet.Protein);
            Assert.AreEqual(170, returnedDiet.Carbohydrates);
            Assert.AreEqual(45, returnedDiet.Fats);
        }

        [Test]
        public async Task DefaultDietsAsync_WithoutUserId_ReturnsAllDefaultDiets()
        {
            var dietMockData = new List<Diet>
    {
        new Diet
        {
            Id = Guid.NewGuid(),
            Name = "Diet 1",
            ImageUrl = "/images/diet1.jpg",
            Calories = 1200,
            Proteins = 50,
            Carbohydrates = 150,
            Fats = 40,
            UserDiets = new List<UserDiet>()
        },
        new Diet
        {
            Id = Guid.NewGuid(),
            Name = "Diet 2",
            ImageUrl = "/images/diet2.jpg",
            Calories = 1400,
            Proteins = 60,
            Carbohydrates = 170,
            Fats = 45,
            UserDiets = new List<UserDiet>()
        }
    };

            var dietMockQueryable = dietMockData.AsQueryable().BuildMock();
            _dietRepositoryMock
                .Setup(repo => repo.GetAllAttached())
                .Returns(dietMockQueryable);

            var result = await _dietService.DefaultDietsAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Diet 1", result.First().Name);
            Assert.AreEqual("Diet 2", result.Last().Name);
        }

        [Test]
        public async Task RemoveFromMyDietsAsync_RecordExists_ShouldDeleteAndReturnTrue()
        {
            var dietId = Guid.NewGuid();
            var userId = "test-user-id";
            var userDiet = new UserDiet
            {
                UserId = userId,
                DietId = dietId
            };

            _userDietRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(It.Is<Expression<Func<UserDiet, bool>>>(
                    f => f.Compile()(userDiet))))
                .ReturnsAsync(userDiet);

            _userDietRepositoryMock
                .Setup(x => x.DeleteAsync(userDiet))
                .ReturnsAsync(true);

            var result = await _dietService.RemoveFromMyDietsAsync(dietId, userId);

            Assert.That(result, Is.True);
            _userDietRepositoryMock.Verify(
                x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserDiet, bool>>>()),
                Times.Once);
            _userDietRepositoryMock.Verify(
                x => x.DeleteAsync(It.Is<UserDiet>(ud => ud.UserId == userId && ud.DietId == dietId)),
                Times.Once);
        }

        [Test]
        public async Task IsRecipeInDietAsync_RecipeInDiet_ShouldReturnTrue()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();
            var dietRecipe = new DietRecipe
            {
                DietId = dietId,
                RecipeId = recipeId
            };

            _dietRecipeRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(It.Is<Expression<Func<DietRecipe, bool>>>(
                    f => f.Compile()(dietRecipe))))
                .ReturnsAsync(dietRecipe);

            var result = await _dietService.IsRecipeInDietAsync(recipeId, dietId);

            Assert.That(result, Is.True);
            _dietRecipeRepositoryMock.Verify(
                x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<DietRecipe, bool>>>()),
                Times.Once);
        }

        [Test]
        public async Task IsRecipeInDietAsync_RecipeNotInDiet_ShouldReturnFalse()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            _dietRecipeRepositoryMock
                .Setup(x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<DietRecipe, bool>>>()))
                .ReturnsAsync((DietRecipe)null);

            var result = await _dietService.IsRecipeInDietAsync(recipeId, dietId);

            Assert.That(result, Is.False);
            _dietRecipeRepositoryMock.Verify(
                x => x.FirstOrDefaultAsync(It.IsAny<Expression<Func<DietRecipe, bool>>>()),
                Times.Once);
        }

        [Test]
        public async Task DietDetailsAsync_DietNotFound_ShouldReturnNull()
        {
            var dietId = Guid.NewGuid();

            _dietRepositoryMock
                .Setup(x => x.GetByIdAsync(dietId))
                .ReturnsAsync((Diet)null);

            var result = await _dietService.DietDetailsAsync(dietId);

            Assert.That(result, Is.Null);
            _recipeRepositoryMock.Verify(
                x => x.GetAllAttached(),
                Times.Never);
        }

        [Test]
        public async Task AddDietsRecipesToDiet_ShouldAddDietRecipe()
        {
            var diet = new Diet
            {
                Id = Guid.NewGuid(),
                Name = "Test Diet",
                UserID = "test-user-id"
            };

            var recipeId = Guid.NewGuid();

            DietRecipe capturedDietRecipe = null;

            _dietRecipeRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<DietRecipe>()))
                .Callback<DietRecipe>(dietRecipe => capturedDietRecipe = dietRecipe)
                .Returns(Task.CompletedTask);

            await _dietService.AddDietsRecipesToDiet(diet, recipeId);

            Assert.IsNotNull(capturedDietRecipe);
            Assert.AreEqual(recipeId, capturedDietRecipe.RecipeId);
            Assert.AreEqual(diet.Id, capturedDietRecipe.DietId);

            _dietRecipeRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<DietRecipe>()), Times.Once);
        }

        [Test]
        public async Task CreateAndReturnDiet_ShouldCreateAndReturnDiet()
        {
            var dietDto = new DietCreationViewModel
            {
                UserId = "test-user-id",
                DietName = "Test Diet",
                ImageUrl = "http://example.com/diet-image.jpg"
            };

            Diet capturedDiet = null;

            _dietRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Diet>()))
                .Callback<Diet>(diet => capturedDiet = diet)
                .Returns(Task.CompletedTask);

            var result = await _dietService.CreateAndReturnDiet(dietDto);

            Assert.IsNotNull(result);
            Assert.AreEqual(dietDto.UserId, result.UserID);
            Assert.AreEqual(dietDto.DietName, result.Name);
            Assert.AreEqual(dietDto.ImageUrl, result.ImageUrl);
            Assert.AreEqual(result, capturedDiet);

            _dietRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Diet>()), Times.Once);
        }

        [Test]
        public async Task AddUserDietAsync_ShouldReturnFalse_WhenUserDietAlreadyExists()
        {
            var dietId = Guid.NewGuid();
            var userId = "test-user-id";
            var existingUserDiet = new UserDiet { DietId = dietId, UserId = userId };

            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserDiet, bool>>>()))
                .ReturnsAsync(existingUserDiet);

            var result = await _dietService.AddUserDietAsync(dietId, userId);

            Assert.IsFalse(result);
            _userDietRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<UserDiet>()), Times.Never);
        }

        [Test]
        public async Task AddUserDietAsync_ShouldReturnTrue_WhenUserDietDoesNotExist()
        {
            var dietId = Guid.NewGuid();
            var userId = "test-user-id";

            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserDiet, bool>>>()))
                .ReturnsAsync((UserDiet)null);

            _userDietRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<UserDiet>()))
                .Returns(Task.CompletedTask);

            var result = await _dietService.AddUserDietAsync(dietId, userId);

            Assert.IsTrue(result);
            _userDietRepositoryMock.Verify(repo => repo.AddAsync(It.Is<UserDiet>(ud => ud.DietId == dietId && ud.UserId == userId)), Times.Once);
        }

        [Test]
        public async Task RemoveFromMyDietsAsync_NonExistingRecord_ReturnsFalse()
        {
            var dietId = Guid.NewGuid();
            var userId = "test-user-id";

            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserDiet, bool>>>()))
                .ReturnsAsync((UserDiet)null);

            var result = await _dietService.RemoveFromMyDietsAsync(dietId, userId);

            Assert.IsFalse(result);
            _userDietRepositoryMock.Verify(
                repo => repo.DeleteAsync(It.IsAny<UserDiet>()),
                Times.Never);
        }

        [Test]
        public async Task RemoveFromMyDietsAsync_RepositoryThrowsException_ExceptionPropagated()
        {
            var dietId = Guid.NewGuid();
            var userId = "test-user-id";
            var userDietRecord = new UserDiet { UserId = userId, DietId = dietId };

            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserDiet, bool>>>()))
                .ThrowsAsync(new Exception("Database connection error"));

            Assert.ThrowsAsync<Exception>(
                async () => await _dietService.RemoveFromMyDietsAsync(dietId, userId)
            );
        }

        [Test]
        public async Task RemoveFromDietAsync_ShouldNotRemove_WhenDietRecipeDoesNotExist()
        {
            var dietId = Guid.NewGuid();
            var recipeId = Guid.NewGuid();

            _dietRecipeRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<DietRecipe, bool>>>()))
                .ReturnsAsync((DietRecipe?)null);

            await _dietService.RemoveFromDietAsync(dietId, recipeId);

            _dietRecipeRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<DietRecipe>()), Times.Never);
            _dietRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Diet>()), Times.Never);
        }

        [Test]
        public async Task UpdateDietMacronutrientsAsync_ShouldNotUpdate_WhenDietDoesNotExist()
        {
            var dietId = Guid.NewGuid();

            _dietRepositoryMock.Setup(repo => repo.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            await _dietService.UpdateDietMacronutrientsAsync(dietId);

            _dietRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Diet>()), Times.Never);
        }

        [Test]
        public async Task RecipeExists_ShouldReturnFalse_WhenRecipeDoesNotExist()
        {
            var recipeId = Guid.NewGuid();

            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync((Recipe?)null);

            var result = await _dietService.RecipeExists(recipeId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task RecipeExists_ShouldReturnTrue_WhenRecipeExists()
        {
            var recipeId = Guid.NewGuid();
            var existingRecipe = new Recipe { Id = recipeId, Name = "Test Recipe", Ingredients = "Test Ingredients", Preparation = "Test Preparation", Calories = 3, Carbohydrates = 3, Proteins = 3, Fats = 3 };

            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync(existingRecipe);

            var result = await _dietService.RecipeExists(recipeId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DietExists_ShouldReturnFalse_WhenDietDoesNotExist()
        {
            var dietId = Guid.NewGuid();

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            var result = await _dietService.DietExists(dietId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task DietExists_ShouldReturnTrue_WhenDietExists()
        {
            var dietId = Guid.NewGuid();
            var existingDiet = new Diet { Id = dietId, Name = "Test Diet" };

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(existingDiet);

            var result = await _dietService.DietExists(dietId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsDefaultDiet_ShouldReturnNull_WhenDietDoesNotExist()
        {
            var dietId = Guid.NewGuid();

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            var result = await _dietService.IsDefaultDiet(dietId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task IsDefaultDiet_ShouldReturnTrue_WhenDietIsDefault()
        {
            var dietId = Guid.NewGuid();
            var diet = new Diet { Id = dietId, UserID = null };

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(diet);

            var result = await _dietService.IsDefaultDiet(dietId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsDefaultDiet_ShouldReturnFalse_WhenDietIsNotDefault()
        {
            var dietId = Guid.NewGuid();
            var diet = new Diet { Id = dietId, UserID = "User123" };

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(diet);

            var result = await _dietService.IsDefaultDiet(dietId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task DietDetailsAsync_ShouldReturnDietDetailsViewModel()
        {
            var dietId = Guid.NewGuid();
            var recipeId = Guid.NewGuid();

            var diet = new Diet
            {
                Id = dietId,
                Name = "Test Diet",
            };

            var dietRecipe = new DietRecipe
            {
                DietId = dietId,
                RecipeId = recipeId,
            };

            var recipe = new Recipe
            {
                Id = recipeId,
                Name = "Test Recipe",
                Carbohydrates = 3,
                Proteins = 3,
                Fats = 3,
                Calories = 3,
                DietsRecipes = new List<DietRecipe> { dietRecipe },
            };

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(diet);
            _recipeRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(new List<Recipe> { recipe }.AsQueryable().BuildMockDbSet().Object);

            var result = await _dietService.DietDetailsAsync(dietId);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Test Recipe", result[0].Name);
        }

        [Test]
        public async Task MyDietsAsync_ShouldReturnDietsForSpecificUser()
        {
            var userId = "user123";

            var diets = new List<Diet>
            {
                new Diet { Id = Guid.NewGuid(), Name = "Diet 1", UserDiets = new List<UserDiet> { new UserDiet { UserId = userId } } },
                new Diet { Id = Guid.NewGuid(), Name = "Diet 2", UserDiets = new List<UserDiet> { new UserDiet { UserId = userId } } }
            };

            _dietRepositoryMock.Setup(r => r.GetAllAttached()).Returns(diets.AsQueryable().BuildMockDbSet().Object);

            var result = await _dietService.MyDietsAsync(userId);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task IsRecipeInDietAsync_ShouldReturnFalseIfRecipeDoesNotExistInDiet()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            _dietRecipeRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(new List<DietRecipe>().AsQueryable().BuildMockDbSet().Object);

            var result = await _dietService.IsRecipeInDietAsync(recipeId, dietId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddRecipeToDietAsync_ShouldAddDietRecipe()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();
            var dietRecipe = new DietRecipe { DietId = dietId, RecipeId = recipeId };

            _dietRecipeRepositoryMock.Setup(r => r.AddAsync(It.IsAny<DietRecipe>())).Returns(Task.CompletedTask);

            await _dietService.AddRecipeToDietAsync(recipeId, dietId);

            _dietRecipeRepositoryMock.Verify(r => r.AddAsync(It.Is<DietRecipe>(dr => dr.DietId == dietId && dr.RecipeId == recipeId)), Times.Once);
        }


        [Test]
        public async Task AddToMyDietsAsync_ShouldAddUserDiet()
        {
            var dietId = Guid.NewGuid();
            var userId = "user123";

            _userDietRepositoryMock.Setup(r => r.AddAsync(It.IsAny<UserDiet>())).Returns(Task.CompletedTask);

            await _dietService.AddToMyDietsAsync(dietId, userId);

            _userDietRepositoryMock.Verify(r => r.AddAsync(It.Is<UserDiet>(ud => ud.UserId == userId && ud.DietId == dietId)), Times.Once);
        }


        private bool CheckUserDietPredicate(
            System.Linq.Expressions.Expression<Func<UserDiet, bool>> predicate,
            string userId,
            Guid dietGuid)
        {
            var compiledPredicate = predicate.Compile();

            var testUserDiet = new UserDiet
            {
                UserId = userId,
                DietId = dietGuid
            };

            return compiledPredicate(testUserDiet);
        }
    }
}
