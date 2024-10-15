using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public required string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser User { get; set; }
    }
}
