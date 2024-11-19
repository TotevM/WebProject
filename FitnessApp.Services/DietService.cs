using System.Security.Claims;
using System.Web.Mvc;
using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class DietService : BaseService, IDietService
    {
        private readonly IRepository<Diet, Guid> dietRepository;
        private readonly IRepository<Recipe, Guid> recipeRepository;
        private readonly IRepository<DietRecipe, object> dietRecipeRepository;
        private readonly IRepository<UserDiet, object> userDietRepository;

        public DietService(UserManager<ApplicationUser> user, IRepository<Diet, Guid> dietRepository, IRepository<Recipe, Guid> recipeRepository, IRepository<DietRecipe, object> dietRecipeRepository, IRepository<UserDiet, object> userDietRepository)
        {
            this.dietRepository = dietRepository;
            this.recipeRepository = recipeRepository;
            this.dietRecipeRepository = dietRecipeRepository;
            this.userDietRepository = userDietRepository;
        }

        public Task<List<SelectListItem>> AddRecipeToDietAsync(Guid recipeId)
        {
            throw new NotImplementedException();
        }

        public Task AddRecipeToDietAsync(AddRecipeToDietViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task AddToMyDietsAsync(Guid dietId, string userId)
        {
            var model = new UserDiet
            {
                UserId = userId,
                DietId = dietId,
            };
            await userDietRepository.AddAsync(model);
        }//completed

        public async Task<List<DietIndexView>> DefaultDietsAsync(string userId)
        {
            var diets = await dietRepository.GetAllAttached()
                .Where(d => !d.UserDiets.Any(ud => ud.UserId == userId) && d.UserID == null)
                .Select(diet => new DietIndexView
                {
                    DietId = diet.Id,
                    Name = diet.Name,
                    Description = diet.Description,
                    ImageUrl = diet.ImageUrl,
                    Calories = diet.Calories,
                    Protein = diet.Protein,
                    Carbohydrates = diet.Carbohydrates,
                    Fats = diet.Fats
                }).ToListAsync();

            return diets;
        }//completed

        public async Task<List<DietDetailsView>> DietDetailsAsync(Guid dietId)
        {
            var recipes = await recipeRepository.GetAllAttached().Where(r => r.DietsRecipes.Any(d => d.DietId == dietId))
                .Select(recipe => new DietDetailsView
                {
                    DietId = dietId,
                    RecipeId = recipe.Id,
                    Name = recipe.Name,
                    ImageUrl = recipe.ImageUrl,
                    Calories = recipe.Calories,
                    Protein = recipe.Protein,
                    Carbohydrates = recipe.Carbohydrates,
                    Fats = recipe.Fats
                }).ToListAsync();

            return recipes;
        }//completed

        public async Task<List<MyDietsIndexView>> MyDietsAsync(string userId)
        {
            var diets = await dietRepository.GetAllAttached()
                .Where(d => d.UserDiets.Any(ud => ud.UserId == userId))
                .Select(diet => new MyDietsIndexView
                {
                    DietId = diet.Id,
                    Name = diet.Name,
                    Description = diet.Description,
                    ImageUrl = diet.ImageUrl,
                    Calories = diet.Calories,
                    Protein = diet.Protein,
                    Carbohydrates = diet.Carbohydrates,
                    Fats = diet.Fats
                }).ToListAsync();

            return diets;
        }//completed

        public async Task<RecipeDetailsInDiet> RecipeDetailsInDietAsync(Guid recipeId, Guid dietId)
        {
            var recipe = await recipeRepository.GetByIdAsync(recipeId);

            if (recipe == null)
            {
                return null!;
            }

            RecipeDetailsInDiet viewModel = new RecipeDetailsInDiet
            {
                DietId = dietId,
                RecipeId = recipeId,
                Name = recipe.Name,
                Calories = recipe.Calories,
                Protein = recipe.Protein,
                Carbohydrates = recipe.Carbohydrates,
                Fats = recipe.Fats,
                ImageUrl = recipe.ImageUrl!,
                Ingredients = recipe.Ingredients,
                Preparation = recipe.Preparation
            };

            return viewModel;
        }//completed

        public async Task RemoveFromDietAsync(Guid dietId, Guid recipeId)
        {
            var toRemove = dietRecipeRepository.GetAllAttached()
                .Where(x => x.RecipeId == recipeId && x.DietId == dietId)
            .FirstOrDefault();

            if (toRemove != null)
            {
                await dietRecipeRepository.DeleteAsync(toRemove);

                var diet = await dietRepository.GetByIdAsync(dietId);

                if (diet != null)
                {
                    diet.Calories = diet.DietsRecipes.Sum(df => df.Recipe.Calories);
                    diet.Protein = diet.DietsRecipes.Sum(df => df.Recipe.Protein);
                    diet.Carbohydrates = diet.DietsRecipes.Sum(df => df.Recipe.Carbohydrates);
                    diet.Fats = diet.DietsRecipes.Sum(df => df.Recipe.Fats);
                }
                await dietRepository.UpdateAsync(diet!);
            }
        }//completed

        public async Task<bool> RemoveFromMyDietsAsync(Guid dietId, string userId)
        {
            var record = userDietRepository.GetAllAttached()
                .Where(ud => ud.UserId == userId && ud.DietId == dietId)
                .FirstOrDefault();

            if (record == null)
            {
                return false!;
            }

            await userDietRepository.DeleteAsync(record!);
            return true;
        }//completed
    }
}
