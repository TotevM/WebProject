using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessApp.ViewModels;
using FitnessApp.Data.Models;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IDietService
    {
        Task<List<MyDietsIndexView>> MyDietsAsync(string userId);//completed
        Task<List<DietIndexView>> DefaultDietsAsync(string userId); //completed
        Task<List<DietDetailsView>?> DietDetailsAsync(Guid dietId);//completed
        Task<RecipeDetailsInDiet> RecipeDetailsInDietAsync(Guid recipeId, Guid dietId);//completed
        Task RemoveFromDietAsync(Guid dietId, Guid recipeId);//completed
        Task AddRecipeToDietAsync(Guid recipeId, Guid dietId);
        Task<AddRecipeToDietViewModel?> AddRecipeToDietViewAsync(Guid recipeId, bool role);//completed
        Task AddToMyDietsAsync(Guid dietId, string userId);//completed
        Task<bool> RemoveFromMyDietsAsync(Guid dietId, string userId);//completed
        Task<List<SelectListItem>> GetDietsSelectListAsync();//--------------
        Task<bool> IsRecipeInDietAsync(Guid recipeId, Guid selectedDietId);//-------------
        Task UpdateDietMacronutrientsAsync(Guid dietId);
        Task<bool?> IsDefaultDiet(Guid id);
        Task<bool> RecipeExists(Guid recipeId);
        Task<bool> DietExists(Guid dietId);
    }
}
