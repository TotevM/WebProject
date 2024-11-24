using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using static FitnessApp.Common.EntityValidationConstants.UserValidation;

namespace FitnessApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        public override string? UserName { get; set; }

        [PersonalData]
        [MaxLength(FirstNameMaxLength)]
        [MinLength(FirstNameMinLength)]
        public string? FirstName { get; set; }
        [PersonalData]
        [MaxLength(LastNameMaxLength)]
        [MinLength(LastNameMinLength)]
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<UserDiet> UsersDiets { get; set; } = new HashSet<UserDiet>();
        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
    }
}
