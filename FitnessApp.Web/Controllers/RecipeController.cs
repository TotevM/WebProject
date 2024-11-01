using System.Globalization;
using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.Data.Models.Enumerations;
using FitnessApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Web.Controllers
{
	public class RecipeController : Controller
	{
		private readonly ILogger<RecipeController> logger;
		private readonly UserManager<ApplicationUser> user;
        private readonly FitnessDBContext context;

        public RecipeController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
		{
            logger = _logger;
			user = _user;
            context = _context;
        }

        public IActionResult Index(Goal? goal = null)
        {
            var recipesQuery = context.Recipes
                .Where(d=>!d.IsDeleted)
                .OrderByDescending(r=>r.CreatedOn)
                .ThenBy(d=>d.Name)
                .AsQueryable();

            if (goal.HasValue)
            {
                recipesQuery = recipesQuery.Where(r => r.Goal == goal.Value);
            }

            var model = recipesQuery.Select(r => new RecipesIndexView
            {
                ImageUrl = r.ImageUrl,
                Name = r.Name,
                UserID = r.UserID,
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Goal> goals = Enum.GetValues(typeof(Goal))
                .Cast<Goal>()
                .ToList();


            var model = new AddRecipeView()
            {
                Goals = goals,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeView model)
        {
            if (!ModelState.IsValid)
            {
                List<Goal> goals = Enum.GetValues(typeof(Goal))
                    .Cast<Goal>()
                    .ToList();

                model = new AddRecipeView()
                {
                    Goals = goals,
                };
                return View(model);
            }

            if (!Goal.TryParse(model.Goal, out Goal goal))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            var recipe = new Recipe()
            {
                Id = Guid.NewGuid(),
                Name = model.RecipeName,
                CreatedOn = DateTime.Now,
                Preparation = model.Preparation,
                Ingredients = model.Ingredients,
                ImageUrl = model.ImageUrl,
                UserID = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                Goal = goal,
                Calories = (int)model.Calories!,
                Protein = (int)model.Protein!,
                Carbohydrates = (int)model.Carbohydrates!,
                Fats = (int)model.Fats!
            };

            await context.Recipes.AddAsync(recipe);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Recipe");
        }
    }
}
