using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class UserDiet
    {
        public required Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public required Guid DietId { get; set; }
        [ForeignKey(nameof(DietId))]
        public virtual Diet Diet { get; set; }
    }
}
