using System.ComponentModel.DataAnnotations.Schema;
using FitnessApp.Data.Models;

namespace FitnessApp.Data.Models
{
    public class DietFood
    {
        public required Guid DietId { get; set; }
        [ForeignKey(nameof(DietId))] public virtual Diet Diet { get; set; } = null!;
        public required int FoodId { get; set; }
        [ForeignKey(nameof(FoodId))]
        public virtual Food Food { get; set; } = null!;
    }
}
