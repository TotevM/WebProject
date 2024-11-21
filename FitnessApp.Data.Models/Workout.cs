using System.ComponentModel.DataAnnotations;
using static FitnessApp.Common.EntityValidationConstants.WorkoutValidation;


namespace FitnessApp.Data.Models
{
    public class Workout
    {
        [Key]
        public Guid Id { get; set; }
        [MinLength(WorkoutNameMinLength)]
        [MaxLength(WorkoutNameMaxLength)]
        public required string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
		public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
	}
}
