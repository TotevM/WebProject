using System.ComponentModel.DataAnnotations;
using static FitnessApp.Common.EntityValidationConstants.DietValidation;

namespace FitnessApp.Data.Models
{
    public class Diet
    {

        [Key]
        public Guid Id { get; set; }

        [MinLength(DietNameMinLength)]
        [MaxLength(DietNameMaxLength)]
        public required string Name { get; set; }

        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public required string Description { get; set; } = null!;
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ImageUrl { get; set; }

        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrates { get; set; }
        public int? Fats { get; set; }

        public virtual ICollection<DietRecipe> DietsRecipes { get; set; } = new HashSet<DietRecipe>();

    }
}
