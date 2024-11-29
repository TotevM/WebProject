using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data.Models
{
    public class UserDiet
    {
        [Comment("The Id of the diet")]
        public Guid DietId { get; set; }

        [ForeignKey(nameof(DietId))]
        public virtual Diet Diet { get; set; } = null!;

        [Comment("The Id of the diet creator")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;
    }
}