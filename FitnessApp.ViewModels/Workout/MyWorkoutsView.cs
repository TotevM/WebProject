namespace FitnessApp.ViewModels.Workout
{
    public class MyWorkoutsView
    {
        public string Id { get; set; } = null!;
        public required string Name { get; set; }
        public string? UserId { get; set; }
        public IEnumerable<ExercisesInMyWorkoutsView> Exercises { get; set; } = new List<ExercisesInMyWorkoutsView>();
    }
}
