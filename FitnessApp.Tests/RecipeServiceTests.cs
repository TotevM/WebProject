using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Data.Models;
using FitnessApp.Services;
using FitnessApp.Common.Enumerations;
using FitnessApp.ViewModels.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Tests
{
    [TestFixture]
    public class RecipeServiceTests
    {
        private Mock<IRepository<Recipe, Guid>> _mockRecipeRepository;
        private Mock<IRepository<Diet, Guid>> _mockDietRepository;
        private Mock<IRepository<DietRecipe, object>> _mockDietRecipeRepository;
        private RecipeService _recipeService;
        private string _testUserId;

        [SetUp]
        public void Setup()
        {
            _mockRecipeRepository = new Mock<IRepository<Recipe, Guid>>();
            _mockDietRepository = new Mock<IRepository<Diet, Guid>>();
            _mockDietRecipeRepository = new Mock<IRepository<DietRecipe, object>>();
            _testUserId = Guid.NewGuid().ToString();

            _recipeService = new RecipeService(
                _mockRecipeRepository.Object,
                _mockDietRepository.Object,
                _mockDietRecipeRepository.Object
            );
        }


        //[Test]
        //public async Task UpdateRecipe_ValidInput_UpdatesRecipeCorrectly()
        //{
        //    // Arrange
        //    var originalRecipe = new Recipe
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Original Recipe",
        //        Preparation = "Old preparation",
        //        Ingredients = "Old ingredients",
        //        ImageUrl = "old-image.jpg",
        //        Calories = 100,
        //        Proteins = 10,
        //        Carbohydrates = 20,
        //        Fats = 5
        //    };
        //    var goal = Goal.Health;
        //    var updateModel = new RecipeEditViewModel
        //    {
        //        RecipeName = "Updated Recipe",
        //        Preparation = "New preparation steps",
        //        Ingredients = "New ingredients list",
        //        ImageUrl = "new-image.jpg",
        //        Calories = 150,
        //        Protein = 15,
        //        Carbohydrates = 25,
        //        Fats = 8
        //    };

        //    // Setup repository update method
        //    _mockRecipeRepository
        //        .Setup(repo => repo.UpdateAsync(It.IsAny<Recipe>()))
        //        .Returns((Task<bool>)Task.CompletedTask);

        //    // Act
        //    await _recipeService.UpdateRecipe(originalRecipe, updateModel, goal);

        //    // Assert
        //    _mockRecipeRepository.Verify(repo => repo.UpdateAsync(It.Is<Recipe>(r =>
        //        r.Name == updateModel.RecipeName &&
        //        r.Preparation == updateModel.Preparation &&
        //        r.Ingredients == updateModel.Ingredients &&
        //        r.ImageUrl == updateModel.ImageUrl &&
        //        r.Goal == goal &&
        //        r.Calories == updateModel.Calories &&
        //        r.Proteins == updateModel.Protein &&
        //        r.Carbohydrates == updateModel.Carbohydrates &&
        //        r.Fats == updateModel.Fats
        //    )), Times.Once);
        //}

        //[Test]
        //public void UpdateRecipe_NullCalories_ThrowsArgumentException()
        //{
        //    // Arrange
        //    var recipe = new Recipe
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Original Recipe",
        //        Preparation = "Old preparation",
        //        Ingredients = "Old ingredients",
        //        ImageUrl = "old-image.jpg",
        //        Calories = 100,
        //        Proteins = 10,
        //        Carbohydrates = 20,
        //        Fats = 5
        //    };
        //    var updateModel = new RecipeEditViewModel
        //    {
        //        RecipeName = "Test Recipe",
        //        Calories = null  // Null value
        //    };
        //    var goal = Goal.Health;

        //    // Act & Assert
        //    Assert.ThrowsAsync<ArgumentException>(
        //        async () => await _recipeService.UpdateRecipe(recipe, updateModel, goal)
        //    );
        //}

        [Test]
        public void UpdateRecipe_NullProtein_ThrowsInvalidOperationException()
        {
            // Arrange
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = "Original Recipe",
                Preparation = "Old preparation",
                Ingredients = "Old ingredients",
                ImageUrl = "old-image.jpg",
                Calories = 100,
                Proteins = 10,
                Carbohydrates = 20,
                Fats = 5
            };
            var updateModel = new RecipeEditViewModel
            {
                RecipeName = "Test Recipe",
                Calories = 100,
                Protein = null  // Null value
            };
            var goal = Goal.Health;

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await _recipeService.UpdateRecipe(recipe, updateModel, goal)
            );
        }











        [Test]
        public async Task UpdateRecipe_RepositoryUpdateFails_PropagatesException()
        {
            // Arrange
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = "Original Recipe",
                Preparation = "Old preparation",
                Ingredients = "Old ingredients",
                ImageUrl = "old-image.jpg",
                Calories = 100,
                Proteins = 10,
                Carbohydrates = 20,
                Fats = 5
            };
            var updateModel = new RecipeEditViewModel
            {
                RecipeName = "Test Recipe",
                Calories = 100,
                Protein = 10,
                Carbohydrates = 20,
                Fats = 5
            };
            var goal = new Goal();

            // Setup repository to throw an exception
            _mockRecipeRepository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Recipe>()))
                .ThrowsAsync(new Exception("Database update failed"));

            // Act & Assert
            Assert.ThrowsAsync<Exception>(
                async () => await _recipeService.UpdateRecipe(recipe, updateModel, goal)
            );
        }


        [Test]
        public void DeleteView_ShouldMapRecipeToDeleteRecipeView()
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = "Test Recipe",
                Calories = 400,
                Proteins = 25,
                Carbohydrates = 50,
                Fats = 10
            };

            var expectedView = new DeleteRecipeView
            {
                Id = recipe.Id.ToString(),
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl
            };

            var result = _recipeService.DeleteView(recipe);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedView.Id, result.Id);
            Assert.AreEqual(expectedView.Name, result.Name);
            Assert.AreEqual(expectedView.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task GetRecipeAsync_ShouldReturnRecipe_WhenRecipeExists()
        {
            var recipeId = Guid.NewGuid();
            var expectedRecipe = new Recipe
            {
                Id = recipeId,
                Name = "Test Recipe",
                Calories = 400,
                Proteins = 25,
                Carbohydrates = 50,
                Fats = 10
            };

            _mockRecipeRepository
                .Setup(repo => repo.GetByIdAsync(recipeId))
                .ReturnsAsync(expectedRecipe);

            var result = await _recipeService.GetRecipeAsync(recipeId);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedRecipe, result);
            _mockRecipeRepository.Verify(repo => repo.GetByIdAsync(recipeId), Times.Once);
        }


        [Test]
        public async Task UpdateDietsAsync_ShouldUpdateDietsWithCorrectMacros()
        {
            var recipeId = Guid.NewGuid();
            var dietId = Guid.NewGuid();
            var diets = new List<Diet>
            {
                new Diet
                {
                    Id = dietId,
                    DietsRecipes = new List<DietRecipe>
                    {
                        new DietRecipe
                        {
                            Recipe = new Recipe { Id = recipeId, Calories = 300, Proteins = 20, Carbohydrates = 50, Fats = 10 },
                            RecipeId = recipeId,
                            DietId = dietId
                        },
                        new DietRecipe
                        {
                            Recipe = new Recipe { Id = Guid.NewGuid(), Calories = 200, Proteins = 15, Carbohydrates = 30, Fats = 5 },
                            RecipeId = Guid.NewGuid(),
                            DietId = dietId
                        }
                    }
                }
            };

            _mockDietRepository
                .Setup(repo => repo.GetAllAttached())
                .Returns(diets.AsQueryable());

            _mockDietRepository
                .Setup(repo => repo.UpdateAsync(It.IsAny<Diet>()))
                .ReturnsAsync(true);

            await _recipeService.UpdateDietsAsync(recipeId);

            foreach (var diet in diets)
            {
                Assert.AreEqual(500, diet.Calories);
                Assert.AreEqual(35, diet.Proteins);
                Assert.AreEqual(80, diet.Carbohydrates);
                Assert.AreEqual(15, diet.Fats);

                _mockDietRepository.Verify(repo => repo.UpdateAsync(diet), Times.Once);
            }
        }


        [Test]
        public void AddRecipe_ReturnsCorrectViewModel()
        {
            // Act
            var result = _recipeService.AddRecipe();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<AddRecipeView>(result);
            Assert.AreEqual(Enum.GetValues(typeof(Goal)).Length, result.Goals.Count);
        }

        [Test]
        public async Task AddRecipeAsync_SuccessfullyAddsRecipe()
        {
            var model = new AddRecipeView
            {
                RecipeName = "Healthy Protein Salad",
                Preparation = "Mix all ingredients and serve chilled",
                Ingredients = "Chicken, Lettuce, Tomatoes, Olive Oil",
                ImageUrl = "http://test.com/healthy-salad.jpg",
                Calories = 300,
                Protein = 25,
                Carbohydrates = 15,
                Fats = 10
            };
            var goal = Goal.Health;

            await _recipeService.AddRecipeAsync(model, goal, _testUserId);

            _mockRecipeRepository.Verify(
                r => r.AddAsync(It.Is<Recipe>(
                    rec => rec.Name == model.RecipeName &&
                           rec.Goal == goal &&
                           rec.UserID == _testUserId &&
                           rec.Calories == 300 &&
                           rec.Proteins == 25 &&
                           rec.Carbohydrates == 15 &&
                           rec.Fats == 10
                )),
                Times.Once
            );
        }

        [Test]
        public async Task EditView_ReturnsCorrectViewModel()
        {
            var recipeId = Guid.NewGuid();
            var recipe = new Recipe
            {
                Id = recipeId,
                Name = "Protein Smoothie",
                Goal = Goal.MassGain,
                Preparation = "Blend all ingredients",
                Ingredients = "Protein Powder, Banana, Milk",
                ImageUrl = "http://test.com/smoothie.jpg",
                Calories = 400,
                Proteins = 30,
                Carbohydrates = 40,
                Fats = 12
            };

            _mockRecipeRepository.Setup(r => r.GetByIdAsync(recipeId)).ReturnsAsync(recipe);

            var result = await _recipeService.EditView(recipeId);

            Assert.IsNotNull(result);
            Assert.AreEqual(recipeId.ToString(), result.Id);
            Assert.AreEqual(recipe.Name, result.RecipeName);
            Assert.AreEqual(recipe.Goal.ToString(), result.Goal);
            Assert.AreEqual(recipe.Calories, result.Calories);
        }

        [Test]
        public void RecipeDetailsView_MapCorrectly()
        {
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = "Vegetable Stir Fry",
                Calories = 250,
                Proteins = 20,
                Carbohydrates = 30,
                Fats = 8,
                Ingredients = "Mixed Vegetables, Tofu, Soy Sauce",
                Preparation = "Stir fry vegetables and tofu",
                ImageUrl = "http://test.com/stir-fry.jpg",
                UserID = _testUserId,
                Goal = Goal.Health
            };

            var result = _recipeService.RecipeDetailsView(recipe);

            Assert.IsNotNull(result);
            Assert.AreEqual(recipe.Id.ToString(), result.RecipeId);
            Assert.AreEqual(recipe.Name, result.Name);
            Assert.AreEqual(recipe.Calories, result.Calories);
            Assert.AreEqual(recipe.Proteins, result.Protein);
        }
    }
}