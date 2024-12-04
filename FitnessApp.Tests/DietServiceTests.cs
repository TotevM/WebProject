using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using EntityFrameworkCore.Testing.Moq;
using MockQueryable.Moq;
using FitnessApp.Common.Enumerations;
using FitnessApp.Services.ServiceContracts;
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
        public async Task RemoveFromMyDietsAsync_NonExistingRecord_ReturnsFalse()
        {
            // Arrange
            var dietId = Guid.NewGuid();
            var userId = "test-user-id";

            // Setup the repository to return null when queried
            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserDiet, bool>>>()))
                .ReturnsAsync((UserDiet)null);

            // Act
            var result = await _dietService.RemoveFromMyDietsAsync(dietId, userId);

            // Assert
            Assert.IsFalse(result);
            _userDietRepositoryMock.Verify(
                repo => repo.DeleteAsync(It.IsAny<UserDiet>()),
                Times.Never);
        }

        [Test]
        public async Task RemoveFromMyDietsAsync_RepositoryThrowsException_ExceptionPropagated()
        {
            // Arrange
            var dietId = Guid.NewGuid();
            var userId = "test-user-id";
            var userDietRecord = new UserDiet { UserId = userId, DietId = dietId };

            // Setup the repository to throw an exception when first queried
            _userDietRepositoryMock
                .Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<Expression<Func<UserDiet, bool>>>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(
                async () => await _dietService.RemoveFromMyDietsAsync(dietId, userId)
            );
        }





        [Test]
        public async Task RemoveFromDietAsync_ShouldNotRemove_WhenDietRecipeDoesNotExist()
        {
            // Arrange
            var dietId = Guid.NewGuid();
            var recipeId = Guid.NewGuid();

            // Mock repository methods
            _dietRecipeRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<Func<DietRecipe, bool>>>()))
                .ReturnsAsync((DietRecipe?)null);

            // Act
            await _dietService.RemoveFromDietAsync(dietId, recipeId);

            // Assert
            _dietRecipeRepositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<DietRecipe>()), Times.Never);
            _dietRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Diet>()), Times.Never);
        }



        //[Test]
        //public async Task UpdateDietMacronutrientsAsync_ShouldUpdateDietWhenDietExists()
        //{
        //    // Arrange
        //    var dietId = Guid.NewGuid();
        //    var diet = new Diet
        //    {
        //        Id = dietId,
        //        DietsRecipes = new List<DietRecipe>
        //    {
        //        new DietRecipe { RecipeId = Guid.NewGuid(),Recipe = new Recipe { Calories = 200, Proteins = 10, Carbohydrates = 30, Fats = 10 }, DietId = dietId},
        //        new DietRecipe { RecipeId = Guid.NewGuid(),Recipe = new Recipe { Calories = 150, Proteins = 5, Carbohydrates = 25, Fats = 8 }, DietId = dietId}
        //    }
        //    };

        //    // Mock GetByIdAsync to return the existing diet
        //    _dietRepositoryMock.Setup(repo => repo.GetByIdAsync(dietId)).ReturnsAsync(diet);

        //    // Mock UpdateAsync to verify that it gets called
        //    _dietRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Diet>())).Returns((Task<bool>)Task.CompletedTask);

        //    // Act
        //    await _dietService.UpdateDietMacronutrientsAsync(dietId);

        //    // Assert
        //    // Verify that UpdateAsync was called
        //    _dietRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Diet>()), Times.Once);

        //    // Verify that the macronutrient values are updated correctly
        //    Assert.AreEqual(350, diet.Calories);       // 200 + 150
        //    Assert.AreEqual(15, diet.Proteins);         // 10 + 5
        //    Assert.AreEqual(55, diet.Carbohydrates);   // 30 + 25
        //    Assert.AreEqual(18, diet.Fats);            // 10 + 8
        //}

        [Test]
        public async Task UpdateDietMacronutrientsAsync_ShouldNotUpdate_WhenDietDoesNotExist()
        {
            // Arrange
            var dietId = Guid.NewGuid();

            // Mock GetByIdAsync to return null (diet does not exist)
            _dietRepositoryMock.Setup(repo => repo.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            // Act
            await _dietService.UpdateDietMacronutrientsAsync(dietId);

            // Assert
            // Verify that UpdateAsync was never called since the diet doesn't exist
            _dietRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Diet>()), Times.Never);
        }





        [Test]
        public async Task RecipeExists_ShouldReturnFalse_WhenRecipeDoesNotExist()
        {
            // Arrange
            var recipeId = Guid.NewGuid();

            // Mock the GetByIdAsync to return null (indicating the recipe does not exist)
            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync((Recipe?)null);

            // Act
            var result = await _dietService.RecipeExists(recipeId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task RecipeExists_ShouldReturnTrue_WhenRecipeExists()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var existingRecipe = new Recipe { Id = recipeId, Name = "Test Recipe", Ingredients = "Test Ingredients", Preparation = "Test Preparation", Calories = 3, Carbohydrates = 3,Proteins = 3,Fats = 3};

            // Mock the GetByIdAsync to return a valid Recipe object
            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync(existingRecipe);

            // Act
            var result = await _dietService.RecipeExists(recipeId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DietExists_ShouldReturnFalse_WhenDietDoesNotExist()
        {
            // Arrange
            var dietId = Guid.NewGuid();

            // Mock the GetByIdAsync to return null (indicating the diet does not exist)
            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            // Act
            var result = await _dietService.DietExists(dietId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task DietExists_ShouldReturnTrue_WhenDietExists()
        {
            // Arrange
            var dietId = Guid.NewGuid();
            var existingDiet = new Diet { Id = dietId, Name = "Test Diet" };

            // Mock the GetByIdAsync to return a valid Diet object
            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(existingDiet);

            // Act
            var result = await _dietService.DietExists(dietId);

            // Assert
            Assert.IsTrue(result);
        }






        [Test]
        public async Task RecipeDetailsInDietAsync_ShouldReturnNull_WhenRecipeDoesNotExist()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            _recipeRepositoryMock.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync((Recipe?)null);
            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(new Diet());

            // Act
            var result = await _dietService.RecipeDetailsInDietAsync(recipeId, dietId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task RecipeDetailsInDietAsync_ShouldReturnNull_WhenDietDoesNotExist()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            // Mock RecipeRepository to return a recipe object
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
                Goal = Goal.WeightLoss // Assuming "Goal" is an enum or class
            });

            // Mock DietRepository to return null (indicating diet doesn't exist)
            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            // Act
            var result = await _dietService.RecipeDetailsInDietAsync(recipeId, dietId);

            // Assert
            Assert.IsNull(result);
        }


        [Test]
        public async Task RecipeDetailsInDietAsync_ShouldReturnRecipeDetailsInDiet_WhenRecipeAndDietExist()
        {
            // Arrange
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

            // Act
            var result = await _dietService.RecipeDetailsInDietAsync(recipeId, dietId);

            // Assert
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
            // Arrange
            var dietId = Guid.NewGuid();

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync((Diet?)null);

            // Act
            var result = await _dietService.IsDefaultDiet(dietId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task IsDefaultDiet_ShouldReturnTrue_WhenDietIsDefault()
        {
            // Arrange
            var dietId = Guid.NewGuid();
            var diet = new Diet { Id = dietId, UserID = null };

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(diet);

            // Act
            var result = await _dietService.IsDefaultDiet(dietId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsDefaultDiet_ShouldReturnFalse_WhenDietIsNotDefault()
        {
            // Arrange
            var dietId = Guid.NewGuid();
            var diet = new Diet { Id = dietId, UserID = "User123" };

            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(diet);

            // Act
            var result = await _dietService.IsDefaultDiet(dietId);

            // Assert
            Assert.IsFalse(result);
        }





        [Test]
        public async Task GetDietsSelectListAsync_ShouldReturnSelectListItems()
        {
            // Arrange
            var diets = new List<Diet>
            {
                new Diet { Id = Guid.NewGuid(), Name = "Diet 1" },
                new Diet { Id = Guid.NewGuid(), Name = "Diet 2" },
                new Diet { Id = Guid.NewGuid(), Name = "Diet 3" }
            };

            _dietRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(diets.AsQueryable().BuildMockDbSet().Object);

            // Act
            var result = await _dietService.GetDietsSelectListAsync();

            // Assert
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
            // Arrange
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

            // Mocking the repositories
            _dietRepositoryMock.Setup(r => r.GetByIdAsync(dietId)).ReturnsAsync(diet);
            _recipeRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(new List<Recipe> { recipe }.AsQueryable().BuildMockDbSet().Object);

            // Act
            var result = await _dietService.DietDetailsAsync(dietId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Test Recipe", result[0].Name);
        }


        [Test]
        public async Task MyDietsAsync_ShouldReturnDietsForSpecificUser()
        {
            // Arrange
            var userId = "user123";

            var diets = new List<Diet>
            {
                new Diet { Id = Guid.NewGuid(), Name = "Diet 1", UserDiets = new List<UserDiet> { new UserDiet { UserId = userId } } },
                new Diet { Id = Guid.NewGuid(), Name = "Diet 2", UserDiets = new List<UserDiet> { new UserDiet { UserId = userId } } }
            };

            _dietRepositoryMock.Setup(r => r.GetAllAttached()).Returns(diets.AsQueryable().BuildMockDbSet().Object);

            // Act
            var result = await _dietService.MyDietsAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task IsRecipeInDietAsync_ShouldReturnTrueIfRecipeExistsInDiet()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            var dietRecipes = new List<DietRecipe>
            {
                new DietRecipe { DietId = dietId, RecipeId = recipeId }
            };

            _dietRecipeRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(dietRecipes.AsQueryable().BuildMockDbSet().Object);

            // Act
            var result = await _dietService.IsRecipeInDietAsync(recipeId, dietId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsRecipeInDietAsync_ShouldReturnFalseIfRecipeDoesNotExistInDiet()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();

            _dietRecipeRepositoryMock.Setup(r => r.GetAllAttached())
                .Returns(new List<DietRecipe>().AsQueryable().BuildMockDbSet().Object);

            // Act
            var result = await _dietService.IsRecipeInDietAsync(recipeId, dietId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task AddRecipeToDietAsync_ShouldAddDietRecipe()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();
            var dietRecipe = new DietRecipe { DietId = dietId, RecipeId = recipeId };

            _dietRecipeRepositoryMock.Setup(r => r.AddAsync(It.IsAny<DietRecipe>())).Returns(Task.CompletedTask);

            // Act
            await _dietService.AddRecipeToDietAsync(recipeId, dietId);

            // Assert
            _dietRecipeRepositoryMock.Verify(r => r.AddAsync(It.Is<DietRecipe>(dr => dr.DietId == dietId && dr.RecipeId == recipeId)), Times.Once);
        }

        [Test]
        public async Task AddRecipeToDietViewAsync_ShouldReturnNullIfRecipeNotFound()
        {
            // Arrange
            var recipeId = Guid.NewGuid();
            _recipeRepositoryMock.Setup(r => r.GetById(recipeId)).Returns((Recipe)null);

            // Act
            var result = await _dietService.AddRecipeToDietViewAsync(recipeId, true);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddToMyDietsAsync_ShouldAddUserDiet()
        {
            // Arrange
            var dietId = Guid.NewGuid();
            var userId = "user123";

            _userDietRepositoryMock.Setup(r => r.AddAsync(It.IsAny<UserDiet>())).Returns(Task.CompletedTask);

            // Act
            await _dietService.AddToMyDietsAsync(dietId, userId);

            // Assert
            _userDietRepositoryMock.Verify(r => r.AddAsync(It.Is<UserDiet>(ud => ud.UserId == userId && ud.DietId == dietId)), Times.Once);
        }
    }
}
