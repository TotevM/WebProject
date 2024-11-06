using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class DietRecipe
    {
        public required Guid DietId { get; set; }
        [ForeignKey(nameof(DietId))] public virtual Diet Diet { get; set; } = null!;
        public required Guid RecipeId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
