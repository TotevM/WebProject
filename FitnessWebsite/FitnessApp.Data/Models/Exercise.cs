using FitnessApp.Web.FitnessApp.Data.Models.Enumerations;

namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Difficulty Difficulty { get; set; }
        public virtual ICollection<WorkoutExercise> WorkoutsExercises { get; set; } = new HashSet<WorkoutExercise>();
    }
}
