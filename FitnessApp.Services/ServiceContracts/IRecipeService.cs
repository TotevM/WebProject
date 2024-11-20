using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels.RecipeModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IRecipeService
    {
        Task<List<RecipesIndexView>> DisplayDietsAsync(Goal? goal = null);
        AddRecipeView AddRecipe();
        Task AddRecipeAsync(AddRecipeView model, Goal goal, string userId);
        Task<Recipe?> GetRecipeAsync(Guid id);
        Task UpdateRecipe(Recipe recipe, RecipeEditViewModel model, Goal goal);
        Task<RecipeEditViewModel?> EditView(Guid id);
        Task UpdateDietsAsync(Guid id);
        DeleteRecipeView DeleteView(Recipe recipe);
        RecipeDetailsViewModel RecipeDetailsView(Recipe recipe);
        Task SoftDeleteRecipe(Recipe recipe);
        Task DeleteDietRecipeRelationAsync(Guid id);

        //bool IsGuidValid(string? id, ref Guid parsedGuid);

    }
}
