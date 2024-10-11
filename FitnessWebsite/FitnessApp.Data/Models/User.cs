using System.ComponentModel.DataAnnotations;
using FitnessApp.Web.FitnessApp.Data.Models.Enumerations;

namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[MinLength()]
        //[MaxLength()]
        public string Name { get; set; } = null!;


        [Required]
        public string Email { get; set; } = null!;

        [Required]
        //[MinLength()]
        //[MaxLength()]
        public string Password { get; set; } = null!;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Goal Goal { get; set; }

        [Required]
        public bool IsDeactivated { get; set; }

        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
    }
}
