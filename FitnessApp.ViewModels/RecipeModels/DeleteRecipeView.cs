using System.ComponentModel.DataAnnotations;

namespace FitnessApp.ViewModels.RecipeModels;


public class DeleteRecipeView
{
    [Required]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; } = null!;
}
