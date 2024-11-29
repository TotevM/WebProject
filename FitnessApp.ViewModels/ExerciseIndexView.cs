namespace FitnessApp.ViewModels
{
    public class ExerciseIndexView
    {
        public string Id { get; set; } = null!;
        public required string Name { get; set; }
        public required string Difficulty { get; set; }
        public string? ImageUrl { get; set; }
        public required string MuscleGroup { get; set; }
    }
}
