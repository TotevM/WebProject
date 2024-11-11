namespace FitnessApp.ViewModels
{
    public class DietDetailsView
    {
        public Guid RecipeId { get; set; }
        public Guid DietId { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Calories { get; set; }
        public int? Protein { get; set; }
        public int? Carbohydrates { get; set; }
        public int? Fats { get; set; }
    }
}