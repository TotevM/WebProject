using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
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

        public async Task<AddRecipeToDietViewModel?> AddRecipeToDietViewAsync(Guid recipeId, bool role)
        {
            var recipe = recipeRepository.GetById(recipeId);

            if (recipe == null)
            {
                return null;
            }
            List<SelectListItem> diets = null!;
            if (role)
            {
              diets = await dietRepository.GetAllAttached()
    .Where(x => x.UserID == null)
   .Select(d => new SelectListItem
   {
       Value = d.Id.ToString(),
       Text = d.Name
   })
   .ToListAsync();
            }
            else
            {
        diets = await dietRepository.GetAllAttached()
                .Where(x => x.UserID != null)
               .Select(d => new SelectListItem
               {
                   Value = d.Id.ToString(),
                   Text = d.Name
               })
               .ToListAsync();
            }

            AddRecipeToDietViewModel viewModel = new AddRecipeToDietViewModel
            {
                RecipeId = recipeId.ToString(),
                Diets = diets
            };

            return viewModel;
        }//completed

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
                    DietId = diet.Id.ToString(),
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
                    Protein = recipe.Protein,
                    Carbohydrates = recipe.Carbohydrates,
                    Fats = recipe.Fats
                }).ToListAsync();
            ;

            return recipes;
        }//completed

        public async Task<bool> DietExists(Guid dietId)
        {
            var diet = await dietRepository.GetByIdAsync(dietId);

            if (diet==null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<SelectListItem>> GetDietsSelectListAsync()
        {
            return await dietRepository.GetAllAttached()
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
            return await dietRecipeRepository.GetAllAttached().AsNoTracking()
                        .AnyAsync(dr => dr.DietId == selectedDietId && dr.RecipeId == recipeId);
        }

        public async Task<List<MyDietsIndexView>> MyDietsAsync(string userId)
        {
            var diets = await dietRepository.GetAllAttached()
                .Where(d => d.UserDiets.Any(ud => ud.UserId == userId))
                .Select(diet => new MyDietsIndexView
                {
                    DietId = diet.Id.ToString(),
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
            var diet = await dietRepository.GetByIdAsync(dietId);

            if (recipe == null || diet == null)
            {
                return null!;
            }

            RecipeDetailsInDiet viewModel = new RecipeDetailsInDiet
            {
                DietId = dietId.ToString(),
                RecipeId = recipeId.ToString(),
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

        public async Task UpdateDietMacronutrientsAsync(Guid dietId)
        {
            var diet = await dietRepository.GetAllAttached()
                    .Include(d => d.DietsRecipes)
                    .ThenInclude(dr => dr.Recipe)
                    .FirstOrDefaultAsync(d => d.Id == dietId);

            if (diet != null)
            {
                diet.Calories = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Calories);
                diet.Protein = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Protein);
                diet.Carbohydrates = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Carbohydrates);
                diet.Fats = diet.DietsRecipes.Where(dr => dr.Recipe != null).Sum(dr => dr.Recipe.Fats);

                await dietRepository.UpdateAsync(diet);
            }
        }
    }
}
