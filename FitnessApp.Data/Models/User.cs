using System.ComponentModel.DataAnnotations;
using FitnessApp.Data.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using static FitnessApp.Web.Common.EntityValidationConstants.UserValidation;

namespace FitnessApp.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        [Key]
        public override Guid Id { get; set; }

        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        public required string Name { get; set; }
        public override required string Email { get; set; }

        public required Gender Gender { get; set; }

        public required Goal Goal { get; set; }

        public required bool IsDeactivated { get; set; }

        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
    }
}
