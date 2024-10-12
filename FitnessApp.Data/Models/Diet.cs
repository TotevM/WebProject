using System.ComponentModel.DataAnnotations;
using static FitnessApp.Web.Common.EntityValidationConstants.DietValidation;

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

        public virtual ICollection<DietFood> DietsFoods { get; set; } = new HashSet<DietFood>();

    }
}
