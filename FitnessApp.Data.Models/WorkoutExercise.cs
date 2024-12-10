using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data.Models
{
    public class WorkoutExercise
    {
        [Comment("The Id of the workout")]
        public Guid WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public virtual Workout Workout { get; set; } = null!;

        [Comment("The Id of the exercise")]
        public Guid ExerciseId { get; set; }
        [ForeignKey(nameof(ExerciseId))]

        [Required]
        [Comment("Does exercise-workout relationship exist")]
        public bool IsDeleted { get; set; }
		public virtual Exercise Exercise { get; set; } = null!;
    }
}
