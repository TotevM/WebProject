using System.ComponentModel.DataAnnotations;
using static FitnessApp.Common.EntityValidationConstants.FoodValidation;

namespace FitnessApp.Data.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [MinLength(FoodNameMinLength)]
        [MaxLength(FoodNameMaxLength)]
        public required string Name { get; set; }

        [Range(0, CalsMax)]
        public required int Calories { get; set; }
        [Range(0, ProteinMax)]
        public required int Protein { get; set; }
        [Range(0, CarbsMax)]
        public required int Carbs { get; set; }
        [Range(0, FatsMax)]
        public required int Fats { get; set; }
        public virtual ICollection<DietFood> DietsFoods { get; set; } = new HashSet<DietFood>();

    }
}
