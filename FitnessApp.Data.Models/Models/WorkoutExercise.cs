using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models.Models
{
    public class WorkoutExercise
    {
        public required Guid WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; } = null!;

        public required Guid ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]
        public virtual Exercise Exercise { get; set; } = null!;
    }
}
