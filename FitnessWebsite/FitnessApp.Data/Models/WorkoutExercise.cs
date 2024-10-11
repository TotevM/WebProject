namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class WorkoutExercise
    {
        public Guid WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }

        public Guid ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
