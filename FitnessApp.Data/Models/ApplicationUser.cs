using System.ComponentModel.DataAnnotations;
using FitnessApp.Data.Models.Enumerations;
using Microsoft.AspNetCore.Identity;
using static FitnessApp.Common.EntityValidationConstants.UserValidation;

namespace FitnessApp.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        //[MinLength(UsernameMinLength)]
        //[MaxLength(UsernameMaxLength)]
        //public override string? UserName { get; set; }
        public required Gender Gender { get; set; }

        //public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
        //public virtual ICollection<UserDiet> UsersDiets { get; set; } = new HashSet<UserDiet>();
        //public virtual ICollection<UserRecipe> UsersRecipes { get; set; } = new HashSet<UserRecipe>();
    }
}
