using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using FitnessApp.ViewModels.RecipeModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task AddRecipeToDietAsync(Guid recipeId, Guid dietId)
        {
            var dietRecipe = new DietRecipe
            {
                DietId = dietId,
                RecipeId = recipeId
            };
            await dietRecipeRepository.AddAsync(dietRecipe);
        }

        public async Task AddToMyDietsAsync(Guid dietId, string userId)
        {
            var model = new UserDiet
            {
                UserId = userId,
                DietId = dietId,
            };
            await userDietRepository.AddAsync(model);
        }


        public async Task<List<DietIndexView>> DefaultDietsAsync(string userId = null)
        {
            var query = dietRepository.GetAllAttached()
                .Where(d => d.UserID == null);

            if (!string.IsNullOrEmpty(userId))
            {
                query = query.Where(d => !d.UserDiets.Any(ud => ud.UserId == userId));
            }

            var diets = await query
                .Select(diet => new DietIndexView
                {
                    DietId = diet.Id.ToString(),
                    Name = diet.Name,
                    ImageUrl = diet.ImageUrl,
                    Calories = diet.Calories,
                    Protein = diet.Proteins,
                    Carbohydrates = diet.Carbohydrates,
                    Fats = diet.Fats
                }).ToListAsync();

            return diets;
        }

        public async Task DeleteDiet(Guid dietId)
        {
            var diet = await dietRepository.FirstOrDefaultAsync(x => x.Id == dietId);

            await dietRepository.DeleteAsync(diet);
        }

        public async Task<List<DietDetailsView>?> DietDetailsAsync(Guid dietId)
        {
            var dietExists = await dietRepository.GetByIdAsync(dietId);

            if (dietExists == null)
            {
                return null;
            }

            var recipes = await recipeRepository.GetAllAttached().Where(r => r.DietsRecipes.Any(d => d.DietId == dietId))
                .Select(recipe => new DietDetailsView
                {
                    DietId = dietId.ToString(),
                    RecipeId = recipe.Id.ToString(),
                    Name = recipe.Name,
                    ImageUrl = recipe.ImageUrl,
                    Calories = recipe.Calories,
                    Protein = recipe.Proteins,
                    Carbohydrates = recipe.Carbohydrates,
                    Fats = recipe.Fats,
                    UserId = dietExists.UserID
                }).ToListAsync();
            ;
            ;

            return recipes;
        }

        public async Task<bool> DietExists(Guid dietId)
        {
            var diet = await dietRepository.GetByIdAsync(dietId);

            if (diet == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<RecipeViewModel>> GetAllRecipeModelAsync()
        {
            var availableRecipes = await recipeRepository.GetAllAttached()
                .Select(r => new RecipeViewModel
                {
                    Id = r.Id.ToString(),
                    RecipeName = r.Name,
                    Goal = r.Goal.ToString(),
                    Calories = r.Calories,
                    Protein = r.Proteins,
                    Carbohydrates = r.Carbohydrates,
                    Fats = r.Fats
                }).ToListAsync();

            return availableRecipes;
        }

        public async Task<Diet> CreateAndReturnDiet(DietCreationViewModel dietDto)
        {
            var diet = new Diet
            {
                UserID = dietDto.UserId,
                Id = Guid.NewGuid(),
                Name = dietDto.DietName,
                ImageUrl = dietDto.ImageUrl
            };

            await dietRepository.AddAsync(diet);

            return diet;
        }

        public async Task AddDietsRecipesToDiet(Diet diet, Guid recipeGuid)
        {
            await dietRecipeRepository.AddAsync(new DietRecipe
            {
                RecipeId = recipeGuid,
                DietId = diet.Id
            });
        }

        public async Task<bool> AddUserDietAsync(Guid dietGuid, string userId)
        {
            var record = await userDietRepository.FirstOrDefaultAsync(x =>
                x.UserId == userId && x.DietId == dietGuid);

            if (record != null)
            {
                return false;
            }

            var entry = new UserDiet
            {
                DietId = dietGuid,
                UserId = userId
            };

            await userDietRepository.AddAsync(entry);

            return true;
        }


        public async Task<List<SelectListItem>> GetCustomDietsSelectListAsync(string userId)
        {
            return await dietRepository.GetAllAttached()
                .Where(d => d.UserID == userId)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetCustomAndDefaultDietsSelectListAsync(string userId)
        {
            return await dietRepository.GetAllAttached()
                .Where(d => d.UserID == null || d.UserID == userId)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToListAsync();
        }

        public async Task<bool?> IsDefaultDiet(Guid id)
        {
            var diet = await dietRepository.GetByIdAsync(id);

            if (diet == null)
            {
                return null;
            }

            if (diet.UserID == null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> IsRecipeInDietAsync(Guid recipeId, Guid selectedDietId)
        {
            var model = await dietRecipeRepository.FirstOrDefaultAsync(dr =>
                dr.DietId == selectedDietId && dr.RecipeId == recipeId);

            if (model == null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<MyDietsIndexView>> MyDietsAsync(string userId)
        {
            var diets = await dietRepository.GetAllAttached()
                .Where(d => d.UserDiets.Any(ud => ud.UserId == userId))
                .Select(diet => new MyDietsIndexView
                {
                    DietId = diet.Id.ToString(),
                    Name = diet.Name,
                    ImageUrl = diet.ImageUrl,
                    Calories = diet.Calories,
                    Protein = diet.Proteins,
                    Carbohydrates = diet.Carbohydrates,
                    Fats = diet.Fats
                }).ToListAsync();

            return diets;
        }

        public async Task<bool> RecipeExists(Guid recipeId)
        {
            var recipe = await recipeRepository.GetByIdAsync(recipeId);

            if (recipe == null)
            {
                return false;
            }
            return true;
        }

        public async Task RemoveFromDietAsync(Guid dietId, Guid recipeId)
        {
            DietRecipe? toRemove =
                await dietRecipeRepository.FirstOrDefaultAsync(x => x.RecipeId == recipeId && x.DietId == dietId);


            if (toRemove != null)
            {
                await dietRecipeRepository.DeleteAsync(toRemove);

                var diet = await dietRepository.GetByIdAsync(dietId);

                if (diet != null)
                {
                    diet.Calories = diet.DietsRecipes.Sum(df => df.Recipe.Calories);
                    diet.Proteins = diet.DietsRecipes.Sum(df => df.Recipe.Proteins);
                    diet.Carbohydrates = diet.DietsRecipes.Sum(df => df.Recipe.Carbohydrates);
                    diet.Fats = diet.DietsRecipes.Sum(df => df.Recipe.Fats);
                }
                await dietRepository.UpdateAsync(diet!);
            }
        }

        public async Task<bool> RemoveFromMyDietsAsync(Guid dietId, string userId)
        {
            var record = await userDietRepository.FirstOrDefaultAsync(ud => ud.UserId == userId && ud.DietId == dietId);

            if (record == null)
            {
                return false!;
            }

            await userDietRepository.DeleteAsync(record);
            return true;
        }

        public async Task UpdateDietMacronutrientsAsync(Guid dietId)
        {
            var diet = await dietRepository.GetByIdAsync(dietId);

            if (diet != null)
            {
                diet.Calories = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Calories);
                diet.Proteins = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Proteins);
                diet.Carbohydrates = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Carbohydrates);
                diet.Fats = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Fats);

                await dietRepository.UpdateAsync(diet);
            }
        }
    }
}