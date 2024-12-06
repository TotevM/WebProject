using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessApp.ViewModels
{

    public class AddExerciseToWorkoutViewModel
    {
        public string WorkoutId { get; set; } = null!;
        public IEnumerable<SelectListItem>? Exercises { get; set; }
        public string SelectedExerciseId { get; set; } = null!;
    }
}