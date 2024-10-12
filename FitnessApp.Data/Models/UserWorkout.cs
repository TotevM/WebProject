using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class UserWorkout
    {
        public required Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public required Guid WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]

        public virtual Workout Workout { get; set; }
    }
}
