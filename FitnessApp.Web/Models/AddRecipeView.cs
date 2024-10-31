using System.ComponentModel.DataAnnotations;
using FitnessApp.Data.Models.Enumerations;
using static FitnessApp.Common.EntityValidationConstants.RecipeValidation;

namespace FitnessApp.Web.Models
{
    public class AddRecipeView
    {
        [MinLength(RecipeNameMinLength)]
        [MaxLength(RecipeNameMaxLength)]
        [Required]
        public string RecipeName { get; set; }

        [MinLength(PreparationNameMinLength)]
        [MaxLength(PreparationNameMaxLength)]
        [Required]
        public string Preparation { get; set; }

        [MinLength(IngredientsNameMinLength)]
        [MaxLength(IngredientsNameMaxLength)]
        [Required]
        public string Ingredients { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public string Goal { get; set; }

        [Range(0, CalsMax)]
        [Required]
        public int Calories { get; set; }
        [Range(0, ProteinMax)]
        [Required]
        public int Protein { get; set; }
        [Range(0, CarbsMax)]
        [Required]
        public int Carbs { get; set; }
        [Range(0, FatsMax)]
        [Required]
        public int Fats { get; set; }
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
