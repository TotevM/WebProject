using System.ComponentModel.DataAnnotations;
using FitnessApp.Common.Enumerations;

namespace FitnessApp.ViewModels
{
    public class AddExerciseViewModel
    {
        public string? Id { get; set; }
        [Required]
        public string ExerciseName { get; set; } = null!;
        [Required]
        public string Difficulty { get; set; } = null!;
        [Required]
        public string MuscleGroup { get; set; } = null!;

        [RegularExpression(@"^(https?:\/\/.*\.(jpg|jpeg|png|gif|bmp|webp))$",
ErrorMessage = "Enter a valid image URL or leave it blank!")]
        public string? ImageUrl { get; set; }

        public ICollection<Difficulty> Difficulties { get; set; } = new List<Difficulty>();
        public ICollection<MuscleGroup> MuscleGroups { get; set; } = new List<MuscleGroup>();
    }
}
