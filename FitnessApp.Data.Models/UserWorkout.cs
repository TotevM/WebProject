using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data.Models
{
    public class UserWorkout
    {
        [Comment("The Id of the workout")]
        public Guid WorkoutId { get; set; }

        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; } = null!;

        [Comment("The Id of the user")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Number of sets")]
        public int Sets { get; set; }
        [Required]
        [Comment("Number of repetitions")]
        public int Repetitions { get; set; }
    }
}
