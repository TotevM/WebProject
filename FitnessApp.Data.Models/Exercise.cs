using System.ComponentModel.DataAnnotations;
using FitnessApp.Common.Enumerations;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.Common.EntityValidationConstants.ExerciseValidation;


namespace FitnessApp.Data.Models
{
    public class Exercise
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(ExerciseNameMinLength)]
        [MaxLength(ExerciseNameMaxLength)]
        [Comment("The name of the exercise")]
        public string Name { get; set; }
        [Required]
        [Comment("The difficulty of the exercise")]
        public Difficulty Difficulty { get; set; }

        [Required]
        [Comment("The time the exercise was created on")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Comment("The muscle group the exercise targets")]
        public MuscleGroup MuscleGroup { get; set; }

        [Comment("The image URL of the exercise")]
        public string? ImageUrl { get; set; }

        [Comment("Is the exercise active or deleted")]
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
    }
}
