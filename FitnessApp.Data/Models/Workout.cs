using System.ComponentModel.DataAnnotations;
using FitnessApp.Data.Models.Enumerations;
using static FitnessApp.Web.Common.EntityValidationConstants.WorkoutValidation;


namespace FitnessApp.Data.Models
{
    public class Workout
    {
        [Key]
        public Guid Id { get; set; }
        [MinLength(WorkoutNameMinLength)]
        [MaxLength(WorkoutNameMaxLength)]
        public required string Name { get; set; }
        [Range(typeof(decimal), WorkoutMinPrice, WorkoutMaxPrice)]
        public required decimal Price { get; set; }
        public required MuscleGroup MuscleGroup { get; set; }
        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
    }
}
