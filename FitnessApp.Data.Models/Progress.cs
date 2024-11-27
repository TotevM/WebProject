using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.Common.EntityValidationConstants.ProgressValidation;

namespace FitnessApp.Data.Models
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Comment("The time the progress was entered")]
        public DateTime Date { get; set; }

        [Required]
        [Range(WeightMin, WeightMax)]
        [Comment("The weight entered")]
        public decimal Weight { get; set; }
        [Required]
        [Range(HeightMin, HeightMax)]
        [Comment("The height entered")]
        public int Height { get; set; }
        [Required]
        [Comment("The user who entered the progress data")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
