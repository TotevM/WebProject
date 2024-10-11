namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class UserWorkout
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Guid WorkoutId { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
