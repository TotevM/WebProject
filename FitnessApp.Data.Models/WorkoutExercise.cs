using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class WorkoutExercise
    {
        public required Guid WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; } = null!;

        public required Guid ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]

		public bool IsDeleted { get; set; }
		public virtual Exercise Exercise { get; set; } = null!;
    }
}
