using System.ComponentModel.DataAnnotations;
using FitnessApp.Data.Models.Enumerations;
using FitnessApp;
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
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
    }
}
