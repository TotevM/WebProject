using System.Web.Mvc;
using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IDietService
    {
        Task<List<MyDietsIndexView>> MyDietsAsync(string userId);
        Task<List<DietIndexView>> DefaultDietsAsync();
        Task<List<DietDetailsView>> DietDetails(Guid dietId);
        Task<RecipeDetailsInDiet> RecipeDetailsInDietAsync(Guid recipeId, Guid dietId);
        Task RemoveFromDiet(Guid dietId, Guid recipeId);
        Task<List<SelectListItem>> AddRecipeToDiet(Guid recipeId);
        Task AddRecipeToDiet(AddRecipeToDietViewModel model);
        Task AddToMyDiets(Guid dietId);
        Task RemoveFromMyDiets(Guid dietId);
    }
}
