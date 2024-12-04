namespace FitnessApp.ViewModels.ApiDTOs
{
    public class DietDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public List<string> RecipeIds { get; set; } = new();
    }
}