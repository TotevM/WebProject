using System.ComponentModel.DataAnnotations;
using FitnessApp.Common.Enumerations;
using static FitnessApp.Common.EntityValidationConstants.ExerciseValidation;


namespace FitnessApp.Data.Models
{
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; }
        [MinLength(ExerciseNameMinLength)]
        [MaxLength(ExerciseNameMaxLength)]
        public required string Name { get; set; }
        public required Difficulty Difficulty { get; set; }
        public DateTime CreatedOn { get; set; }
        public required MuscleGroup MuscleGroup { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
    }
}
