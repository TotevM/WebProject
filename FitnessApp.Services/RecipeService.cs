using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels.RecipeModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class RecipeService : IRecipeService
    {
        readonly IRepository<Recipe, Guid> recipeRepository;
        readonly IRepository<Diet, Guid> dietRepository;
        readonly IRepository<DietRecipe, object> dietRecipeRepository;

        public RecipeService(IRepository<Recipe, Guid> recipeRepository, IRepository<Diet, Guid> dietRepository, IRepository<DietRecipe, object> dietRecipeRepository)
        {
            this.recipeRepository = recipeRepository;
            this.dietRepository = dietRepository;
            this.dietRecipeRepository = dietRecipeRepository;
        }
        public AddRecipeView AddRecipe()
        {
            List<Goal> goals = Enum.GetValues(typeof(Goal))
                .Cast<Goal>()
                .ToList();


            AddRecipeView model = new AddRecipeView()
            {
                Goals = goals,
            };

            return model;
        }
        public async Task AddRecipeAsync(AddRecipeView model, Goal goal, string userId)
        {
            var recipe = new Recipe()
            {
                Id = Guid.NewGuid(),
                Name = model.RecipeName,
                CreatedOn = DateTime.Now,
                Preparation = model.Preparation,
                Ingredients = model.Ingredients,
                ImageUrl = model.ImageUrl,
                UserID = userId,
                Goal = goal,
                Calories = (int)model.Calories!,
                Proteins = (int)model.Protein!,
                Carbohydrates = (int)model.Carbohydrates!,
                Fats = (int)model.Fats!
            };

            await recipeRepository.AddAsync(recipe);
        }

        public async Task DeleteDietRecipeRelationAsync(Guid id)
        {
            var toDelete = dietRecipeRepository.GetAllAttached().Where(x => x.RecipeId == id).ToList();
            foreach (var couple in toDelete)
            {
                await dietRecipeRepository.DeleteAsync(couple);
            }
        }

        public DeleteRecipeView DeleteView(Recipe recipe)
        {
            var model = new DeleteRecipeView
            {
                Id = recipe.Id.ToString(),
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl
            };

            return model;
        }
        public async Task<List<RecipesIndexView>> DisplayDietsAsync(Goal? goal = null)
        {
            var recipesQuery = recipeRepository.GetAllAttached()
                        .Where(d => !d.IsDeleted)
                        .OrderByDescending(r => r.CreatedOn)
                        .ThenBy(d => d.Name)
                        .AsQueryable();

            if (goal.HasValue)
            {
                recipesQuery = recipesQuery.Where(r => r.Goal == goal.Value);
            }

            List<RecipesIndexView> model = await recipesQuery.Select(r => new RecipesIndexView
            {
                Id = r.Id.ToString(),
                ImageUrl = r.ImageUrl,
                Name = r.Name,
                UserID = r.UserID,
            }).ToListAsync();

            return model;
        }
        public async Task<RecipeEditViewModel?> EditView(Guid id)
        {
            List<Goal> goals = Enum.GetValues(typeof(Goal))
                        .Cast<Goal>()
                        .ToList();

            var recipe = await recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                return null;
            }

            var recipeModel = new RecipeEditViewModel
            {
                Id = id.ToString(),
                RecipeName = recipe!.Name,
                Goals = goals,
                Preparation = recipe.Preparation,
                Ingredients = recipe.Ingredients,
                ImageUrl = recipe.ImageUrl,
                Goal = recipe.Goal.ToString(),
                Calories = (int)recipe.Calories!,
                Protein = (int)recipe.Proteins!,
                Carbohydrates = (int)recipe.Carbohydrates!,
                Fats = (int)recipe.Fats!
            };

            return recipeModel;
        }
        public async Task<Recipe?> GetRecipeAsync(Guid id)
        {
            var recipe = await recipeRepository.GetByIdAsync(id);

            return recipe;
        }
        public RecipeDetailsViewModel RecipeDetailsView(Recipe recipe)
        {
            var viewModel = new RecipeDetailsViewModel
            {
                RecipeId = recipe.Id.ToString(),
                Name = recipe.Name,
                Calories = recipe.Calories,
                Protein = recipe.Proteins,
                Carbohydrates = recipe.Carbohydrates,
                Fats = recipe.Fats,
                ImageUrl = recipe.ImageUrl!,
                Ingredients = recipe.Ingredients,
                Preparation = recipe.Preparation,
                UserId = recipe.UserID!
            };
            return viewModel;
        }
        public async Task SoftDeleteRecipe(Recipe recipe)
        {
            recipe.IsDeleted = true;
            await recipeRepository.UpdateAsync(recipe);
        }

        public async Task UpdateDietsAsync(Guid id)
        {
            var diets = dietRepository.GetAllAttached().Where(d => d.DietsRecipes.Any(x => x.RecipeId == id)).ToList();

            foreach (var diet in diets)
            {
                if (diet != null)
                {
                    diet.Calories = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Calories);

                    diet.Proteins = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Proteins);

                    diet.Carbohydrates = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Carbohydrates);

                    diet.Fats = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Fats);
                }
                await dietRepository.UpdateAsync(diet!);
            }
        }
        public async Task UpdateRecipe(Recipe recipe,RecipeEditViewModel model, Goal goal)
        {
            recipe.Name = model.RecipeName;
            recipe.Preparation = model.Preparation;
            recipe.Ingredients = model.Ingredients;
            recipe.ImageUrl = model.ImageUrl;
            recipe.Goal = goal;
            recipe.Calories = (int)model.Calories!;
            recipe.Proteins = (int)model.Protein!;
            recipe.Carbohydrates = (int)model.Carbohydrates!;
            recipe.Fats = (int)model.Fats!;

            await recipeRepository.UpdateAsync(recipe);
        }
    }
}
