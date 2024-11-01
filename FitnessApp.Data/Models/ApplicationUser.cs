using FitnessApp.Data.Models.Enumerations;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[MinLength(UsernameMinLength)]
        //[MaxLength(UsernameMaxLength)]
        //public override string? UserName { get; set; }
        public required Gender Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
