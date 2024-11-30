using System.ComponentModel.DataAnnotations;
using static FitnessApp.Common.EntityValidationConstants.WorkoutValidation;

namespace FitnessApp.ViewModels
{
    public class WorkoutCreationViewModel
    {
        [Required(ErrorMessage = "Workout Name is required")]
        [MinLength(WorkoutNameMinLength, ErrorMessage = "Workout Name is too short")]
        [MaxLength(WorkoutNameMaxLength, ErrorMessage = "Workout Name is too long")]
        public string WorkoutName { get; set; } = null!;

        [Required(ErrorMessage = "Please select at least one exercise")]
        public List<string> SelectedExerciseIds { get; set; } = null!;
    }
}
