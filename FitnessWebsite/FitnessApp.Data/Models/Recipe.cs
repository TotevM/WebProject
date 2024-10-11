namespace FitnessApp.Web.FitnessApp.Data.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }
        public string Preparation { get; set; }

        public int GoalId { get; set; }
    }
}
