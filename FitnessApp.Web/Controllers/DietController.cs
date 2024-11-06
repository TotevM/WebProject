using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    public class DietController : Controller
    {
        private readonly ILogger<RecipeController> logger;
        private readonly UserManager<ApplicationUser> user;
        private readonly FitnessDBContext context;

        public DietController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
        {
            logger = _logger;
            user = _user;
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var diets = context.Diets.ToList();

            var dietViewModels = diets.Select(diet => new DietIndexView
            {
                Id = diet.Id,
                Name = diet.Name,
                Description = diet.Description,
                ImageUrl = diet.ImageUrl,
                Calories = diet.Calories,
                Protein = diet.Protein,
                Carbohydrates = diet.Carbohydrates,
                Fats = diet.Fats
            }).ToList();

            return View(dietViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var recipes = context.Recipes.Where(r => r.DietsRecipes.Any(d => d.DietId == id)).ToList();

            List<DietDetailsView> dietViewModels = recipes.Select(recipe => new DietDetailsView
            {
                Id = recipe.Id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl,
                Calories = recipe.Calories,
                Protein = recipe.Protein,
                Carbohydrates = recipe.Carbohydrates,
                Fats = recipe.Fats
            }).ToList();

            return View(dietViewModels);
        }

        public IActionResult AddToDiet()
        {
            throw new NotImplementedException();
        }
    }
}
