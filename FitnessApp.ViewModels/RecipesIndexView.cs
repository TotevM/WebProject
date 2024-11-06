using System.ComponentModel.DataAnnotations;

namespace FitnessApp.ViewModels
{
    public class RecipesIndexView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; } = null!;
        public string? UserID { get; set; }
    }
}
