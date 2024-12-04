using System.ComponentModel.DataAnnotations;
using static FitnessApp.Common.EntityValidationConstants.RecipeValidation;

namespace FitnessApp.ViewModels
{
    public class DietCreationViewModel
    {
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Diet Name is required")]
        [MinLength(RecipeNameMinLength, ErrorMessage = "Diet Name is too short")]
        [MaxLength(RecipeNameMaxLength, ErrorMessage = "Diet Name is too long")]
        public string DietName { get; set; } = null!;

        [RegularExpression(@"^(https?://.*.(jpg|jpeg|png|gif|bmp|webp))$",
            ErrorMessage = "Enter a valid image URL or leave it blank!")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Please select at least one recipe")]
        public List<string> SelectedRecipeIds { get; set; } = null!;
    }
}