using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.Common.EntityValidationConstants.UserValidation;

namespace FitnessApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        [Comment("Username of the user")]
        public override string? UserName { get; set; }

        [Comment("Is the account deleted or not")]
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<UserDiet> UsersDiets { get; set; } = new HashSet<UserDiet>();
        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
    }
}
