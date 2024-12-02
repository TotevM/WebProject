namespace FitnessApp.ViewModels.ApiDTOs
{
    public class WorkoutDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<string> ExerciseIds { get; set; } = new();
    }
}
