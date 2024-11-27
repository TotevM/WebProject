using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data.Models
{
    public class DietRecipe
    {
        [Comment("The Id of the diet")]
        public required Guid DietId { get; set; }
        [ForeignKey(nameof(DietId))] public virtual Diet Diet { get; set; } = null!;
        [Comment("The Id of the recipe")]
        public required Guid RecipeId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
