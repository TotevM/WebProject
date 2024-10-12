using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.Data.Models
{
    public class UserRecipe
    {
        public required Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public required Guid RecipeId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }
    }
}
