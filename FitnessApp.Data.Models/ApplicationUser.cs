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
        [PersonalData]
        [MaxLength(FirstNameMaxLength)]
        [MinLength(FirstNameMinLength)]
        [Comment("First Name of the user")]
        public string? FirstName { get; set; }
        [PersonalData]
        [MaxLength(LastNameMaxLength)]
        [MinLength(LastNameMinLength)]
        [Comment("Last Name of the user")]
        public string? LastName { get; set; }
        [Comment("Date of birth of the user")]
        public DateTime DateOfBirth { get; set; }

        [Comment("Is the account active")]
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<UserDiet> UsersDiets { get; set; } = new HashSet<UserDiet>();
        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
    }
}
