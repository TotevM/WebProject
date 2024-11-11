using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                DietId = id,
                RecipeId = recipe.Id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl,
                Calories = recipe.Calories,
                Protein = recipe.Protein,
                Carbohydrates = recipe.Carbohydrates,
                Fats = recipe.Fats
            }).ToList();

            return View(dietViewModels);
        }

        [HttpGet]
        public IActionResult DetailsInDiet(Guid recipeId, Guid dietId)
        {
            var recipe = context.Recipes
                .Where(r => r.Id == recipeId)
                .FirstOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }

            var viewModel = new RecipeDetailsViewModel
            {
                DietId = dietId,
                RecipeId = recipeId,
                Name = recipe.Name,
                Calories = recipe.Calories,
                Protein = recipe.Protein,
                Carbohydrates = recipe.Carbohydrates,
                Fats = recipe.Fats,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Preparation = recipe.Preparation
            };

            return View(viewModel);
        }

        public IActionResult AddToDiet()
        {
            throw new NotImplementedException();
        }

        public IActionResult RemoveFromDiet(Guid dietId, Guid recipeId)
        {
            var toRemove = context.DietsRecipes
                .Where(x => x.RecipeId == recipeId && x.DietId == dietId)
                .FirstOrDefault();

            if (toRemove != null)
            {
                context.DietsRecipes.Remove(toRemove);

                // Recalculate diet totals
                var diet = context.Diets
                    .Include(d => d.DietsRecipes)
                    .ThenInclude(dr => dr.Recipe)
                    .FirstOrDefault(d => d.Id == dietId);

                if (diet != null)
                {
                    diet.Calories = diet.DietsRecipes.Sum(df => df.Recipe.Calories);
                    diet.Protein = diet.DietsRecipes.Sum(df => df.Recipe.Protein);
                    diet.Carbohydrates = diet.DietsRecipes.Sum(df => df.Recipe.Carbohydrates);
                    diet.Fats = diet.DietsRecipes.Sum(df => df.Recipe.Fats);
                }

                context.SaveChanges();
            }

            return RedirectToAction("Details", new { id = dietId });
        }
    }
}
