using System.ComponentModel.DataAnnotations;
using static FitnessApp.Web.Common.EntityValidationConstants.RecipeValidation;

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

        public required int GoalId { get; set; }
    }
}
