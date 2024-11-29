using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessApp.ViewModels.RecipeModels
{
    public class AddRecipeToDietViewModel
    {
        public string RecipeId { get; set; } = null!;
        public IEnumerable<SelectListItem>? Diets { get; set; }
        public string SelectedDietId { get; set; } = null!;
    }
}