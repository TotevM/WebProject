using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class UserDiet
    {
        public Guid DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public virtual Diet Diet { get; set; } = null!;

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
    }
}