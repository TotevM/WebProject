using System.ComponentModel.DataAnnotations;

namespace FitnessApp.ViewModels.RecipeModels;


public class DeleteRecipeView
{
    [Required]
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; } = null!;
}
