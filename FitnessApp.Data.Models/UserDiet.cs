using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class UserDiet
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public virtual Diet Diet { get; set; } = null!;

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
    }
}