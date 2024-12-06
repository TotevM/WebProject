namespace FitnessApp.ViewModels
{
    public class DietDetailsView
    {
        public string RecipeId { get; set; } = null!;
        public string DietId { get; set; } = null!;
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrates { get; set; }
        public int? Fats { get; set; }

        public string? UserId { get; set; }
    }
}