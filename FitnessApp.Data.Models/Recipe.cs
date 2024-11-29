using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessApp.Common.Enumerations;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.Common.EntityValidationConstants.RecipeValidation;


namespace FitnessApp.Data.Models
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(RecipeNameMinLength)]
        [MaxLength(RecipeNameMaxLength)]
        [Comment("The name of the recipe")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(IngredientsNameMinLength)]
        [MaxLength(IngredientsNameMaxLength)]
        [Comment("The ingredients of the recipe")]
        public string Ingredients { get; set; } = null!;

        [Required]
        [MinLength(PreparationNameMinLength)]
        [MaxLength(PreparationNameMaxLength)]
        [Comment("The preparation of the recipe")]
        public string Preparation { get; set; } = null!;

        [Comment("The image URL of the recipe")]
        public string? ImageUrl { get; set; } = null!;

        [Required]
        [Comment("The goal of the recipe")]
        public Goal Goal { get; set; }

        [Required]
        [Comment("The time the recipe was created on")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Range(0, CalsMax)]
        [Comment("The calories of the recipe")]
        public int Calories { get; set; }
        [Required]
        [Range(0, ProteinMax)]
        [Comment("The proteins of the recipe")]
        public int Proteins { get; set; }
        [Required]
        [Range(0, CarbsMax)]
        [Comment("The carbohydrates of the recipe")]
        public required int Carbohydrates { get; set; }
        [Required]
        [Range(0, FatsMax)]
        [Comment("The fats of the recipe")]
        public int Fats { get; set; }
        [Comment("The creator of the recipe")]
        public string? UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual ApplicationUser? User { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<DietRecipe> DietsRecipes { get; set; } = new HashSet<DietRecipe>();
    }
}
