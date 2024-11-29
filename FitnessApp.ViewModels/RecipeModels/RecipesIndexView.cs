using System.ComponentModel.DataAnnotations;

namespace FitnessApp.ViewModels.RecipeModels
{
    public class RecipesIndexView
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
        public string? UserID { get; set; }
    }
}
