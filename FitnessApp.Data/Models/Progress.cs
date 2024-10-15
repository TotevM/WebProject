using System.ComponentModel.DataAnnotations;
using static FitnessApp.Common.EntityValidationConstants.ProgressValidation;

namespace FitnessApp.Data.Models
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }
        public required DateTime Date { get; set; }

        [Range(WeightMin, WeightMax)]
        public required decimal Weight { get; set; }
        [Range(HeightMin, HeightMax)]
        public required int Height { get; set; }

        public required string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
