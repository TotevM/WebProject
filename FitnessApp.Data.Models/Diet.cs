using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.Common.EntityValidationConstants.DietValidation;

namespace FitnessApp.Data.Models
{
    public class Diet
    {

        [Key]
        public Guid Id { get; set; }

        [MinLength(DietNameMinLength)]
        [MaxLength(DietNameMaxLength)]
        [Comment("Name of the diet")]
        public required string Name { get; set; }

        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the diet")]
        public required string Description { get; set; } = null!;

        [Comment("The creator of the diet")]
        public string? UserID { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Comment("The time the diet was created on")]
        public DateTime CreatedOn { get; set; }

        [Comment("The image URL of the diet")]
        public string? ImageUrl { get; set; }

        [Comment("The calories of the diet")]
        public int Calories { get; set; }
        [Comment("The proteins of the diet")]
        public int? Proteins { get; set; }
        [Comment("The carbohydrates of the diet")]
        public int? Carbohydrates { get; set; }
        [Comment("The fats of the diet")]
        public int? Fats { get; set; }

        public virtual ICollection<DietRecipe> DietsRecipes { get; set; } = new HashSet<DietRecipe>();

        public virtual ICollection<UserDiet> UserDiets { get; set; } = new HashSet<UserDiet>();

    }
}
