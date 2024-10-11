using FitnessApp.Web.FitnessApp.Data.Models.Enumerations;

namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class Workout
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public MuscleGroup MuscleGroup { get; set; }

        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
    }
}
