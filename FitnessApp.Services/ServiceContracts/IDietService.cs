using System.Web.Mvc;
using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IDietService
    {
        Task<List<MyDietsIndexView>> MyDietsAsync(string userId);
        Task<List<DietIndexView>> DefaultDietsAsync(string userId);
        Task<List<DietDetailsView>> DietDetailsAsync(Guid dietId);
        Task<RecipeDetailsInDiet> RecipeDetailsInDietAsync(Guid recipeId, Guid dietId);
        Task RemoveFromDietAsync(Guid dietId, Guid recipeId);
        Task<List<SelectListItem>> AddRecipeToDietAsync(Guid recipeId);
        Task AddRecipeToDietAsync(AddRecipeToDietViewModel model);
        Task AddToMyDietsAsync(Guid dietId);
        Task RemoveFromMyDietsAsync(Guid dietId);
    }
}
