namespace FitnessApp.ViewModels.RecipeModels
{
    public class RecipeViewModel
    {
        public string Id { get; set; } = null!;

        public string RecipeName { get; set; } = null!;

        public string Goal { get; set; } = null!;

        public int Calories { get; set; }

        public int Protein { get; set; }

        public int Carbohydrates { get; set; }

        public int Fats { get; set; }
    }
}