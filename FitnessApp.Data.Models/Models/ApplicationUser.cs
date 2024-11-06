using FitnessApp.Data.Models.Models.Enumerations;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Data.Models.Models
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
