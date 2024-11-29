using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.Common.EntityValidationConstants.WorkoutValidation;


namespace FitnessApp.Data.Models
{
    public class Workout
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(WorkoutNameMinLength)]
        [MaxLength(WorkoutNameMaxLength)]
        [Comment("Name of the workout")]
        public string Name { get; set; } = null!;
        [Required]
        [Comment("The time the workout was created on")]
        public DateTime CreatedOn { get; set; }
        [Comment("The creator of the workout")]
        public string? UserID { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
		public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
	}
}
