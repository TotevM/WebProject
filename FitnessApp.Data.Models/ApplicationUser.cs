using System.ComponentModel.DataAnnotations;
using FitnessApp.Common.Enumerations;
using static FitnessApp.Common.EntityValidationConstants.UserValidation;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Data.Models
{
    public class ApplicationUser : IdentityUser
	{
        public required Gender Gender { get; set; }
        [MinLength(UsernameMinLength)]
        [MaxLength(UsernameMaxLength)]
        public override string? UserName { get; set; }
        public string? ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<UserDiet> UsersDiets { get; set; } = new HashSet<UserDiet>();
        public virtual ICollection<UserWorkout> UsersWorkouts { get; set; } = new HashSet<UserWorkout>();
    }
}
