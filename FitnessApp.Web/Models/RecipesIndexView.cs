using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Web.Models
{
    public class RecipesIndexView
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; } = null!;
        public string? UserID { get; set; }
    }
}
