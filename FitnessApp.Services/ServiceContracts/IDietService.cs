using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessApp.ViewModels;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels.RecipeModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IDietService
    {
        Task<List<MyDietsIndexView>> MyDietsAsync(string userId);
        Task<List<DietDetailsView>?> DietDetailsAsync(Guid dietId);
        //Task<RecipeDetailsInDiet> RecipeDetailsInDietAsync(Guid recipeId, Guid dietId);
        Task RemoveFromDietAsync(Guid dietId, Guid recipeId);
        Task AddRecipeToDietAsync(Guid recipeId, Guid dietId);
        //Task<AddRecipeToDietViewModel?> AddRecipeToDietViewAsync(Guid recipeId, bool role);
        Task AddToMyDietsAsync(Guid dietId, string userId);
        Task<bool> RemoveFromMyDietsAsync(Guid dietId, string userId);
        Task<List<SelectListItem>> GetDietsSelectListAsync();
        Task<bool> IsRecipeInDietAsync(Guid recipeId, Guid selectedDietId);
        Task UpdateDietMacronutrientsAsync(Guid dietId);
        Task<bool?> IsDefaultDiet(Guid id);
        Task<bool> RecipeExists(Guid recipeId);
        Task<bool> DietExists(Guid dietId);
        Task<List<RecipeViewModel>> GetAllRecipeModelAsync();
        Task<Diet> CreateAndReturnDiet(DietCreationViewModel dietDto);
        Task AddDietsRecipesToDiet(Diet diet, Guid recipeGuid);
        Task<bool> AddUserDietAsync(Guid dietGuid, string userId);
        Task<List<DietIndexView>> DefaultDietsAsync(string? userId);
        Task DeleteDefaultDiet(Guid dietId);
    }
}