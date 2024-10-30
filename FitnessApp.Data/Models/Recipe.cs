using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessApp.Data.Models.Enumerations;
using static FitnessApp.Common.EntityValidationConstants.RecipeValidation;

namespace FitnessApp.Data.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(RecipeNameMinLength)]
        [MaxLength(RecipeNameMaxLength)]
        public required string Name { get; set; }

        [MinLength(IngredientsNameMinLength)]
        [MaxLength(IngredientsNameMaxLength)]
        public required string Ingredients { get; set; }

        [MinLength(PreparationNameMinLength)]
        [MaxLength(PreparationNameMaxLength)]
        public required string Preparation { get; set; }

        public string? ImageUrl { get; set; } = null!;
        public required Goal Goal { get; set; }

        [Range(0, CalsMax)]
        public required int Calories { get; set; }
        [Range(0, ProteinMax)]
        public required int Protein { get; set; }
        [Range(0, CarbsMax)]
        public required int Carbs { get; set; }
        [Range(0, FatsMax)]
        public required int Fats { get; set; }
        public string? UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<DietRecipe> DietsRecipes { get; set; } = new HashSet<DietRecipe>();
    }
}
