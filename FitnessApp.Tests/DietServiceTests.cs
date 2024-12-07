using System.Linq.Expressions;
using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;

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
        public async Task RecipeDetailsInDietAsync_ShouldReturnNull_WhenRecipeDoesNotExist()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync((Recipe?)null);
            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(new Diet());

            var result = await _dietService.RecipeDetailsInDietAsync(recipeId, dietId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task RecipeDetailsInDietAsync_ShouldReturnNull_WhenDietDoesNotExist()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync(new Recipe
            {
                Id = recipeId,
                Name = "Test Recipe",
                Ingredients = "Test Ingredients",
                Preparation = "Test Preparation",
                CreatedOn = DateTime.UtcNow,
                Calories = 200,
                Proteins = 15,
                Carbohydrates = 30,
                Fats = 5,
                Goal = Goal.WeightLoss
            });

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            var result = await _dietService.RecipeDetailsInDietAsync(recipeId, dietId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task RecipeDetailsInDietAsync_ShouldReturnRecipeDetailsInDiet_WhenRecipeAndDietExist()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();
            var recipe = new Recipe
            {
                Id = recipeId,
                Name = "Test Recipe",
                Calories = 300,
                Proteins = 20,
                Carbohydrates = 50,
                Fats = 10,
                ImageUrl = "test-image-url",
                Ingredients = "Test Ingredients",
                Preparation = "Test Preparation"
            };

            var diet = new Diet
            {
                Id = dietId,
                Name = "Test Diet"
            };

            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync(recipe);
            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(diet);

            var result = await _dietService.RecipeDetailsInDietAsync(recipeId, dietId);

            Assert.IsNotNull(result);
            Assert.AreEqual(dietId.ToString(), result.DietId);
            Assert.AreEqual(recipeId.ToString(), result.RecipeId);
            Assert.AreEqual("Test Recipe", result.Name);
            Assert.AreEqual(300, result.Calories);
            Assert.AreEqual(20, result.Protein);
            Assert.AreEqual(50, result.Carbohydrates);
            Assert.AreEqual(10, result.Fats);
            Assert.AreEqual("test-image-url", result.ImageUrl);
            Assert.AreEqual("Test Ingredients", result.Ingredients);
            Assert.AreEqual("Test Preparation", result.Preparation);
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
        public async Task GetDietsSelectListAsync_ShouldReturnSelectListItems()
        {
            var diets = new List<Diet>
            {
                new Diet { Id = Guid.NewGuid(), Name = "Diet 1" },
                new Diet { Id = Guid.NewGuid(), Name = "Diet 2" },
                new Diet { Id = Guid.NewGuid(), Name = "Diet 3" }
            };

            _dietRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(diets.AsQueryable().BuildMockDbSet().Object);

            var result = await _dietService.GetDietsSelectListAsync();

            Assert.IsNotNull(result);
            Assert.AreEqual(diets.Count, result.Count);

            for (int i = 0; i < diets.Count; i++)
            {
                Assert.AreEqual(diets[i].Id.ToString(), result[i].Value);
                Assert.AreEqual(diets[i].Name, result[i].Text);
            }
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
        public async Task AddRecipeToDietViewAsync_ShouldReturnNullIfRecipeNotFound()
        {
            var recipeId = Guid.NewGuid();
            _recipeRepositoryMock.Setup(r => r.GetById(recipeId)).Returns((Recipe)null);

            var result = await _dietService.AddRecipeToDietViewAsync(recipeId, true);

            Assert.IsNull(result);
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
    }
}
