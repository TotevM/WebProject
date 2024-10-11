namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class UserRecipe
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public Guid RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
