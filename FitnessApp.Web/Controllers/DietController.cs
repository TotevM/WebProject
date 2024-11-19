using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class DietController : Controller
    {
        private readonly ILogger<RecipeController> logger;
        private readonly UserManager<ApplicationUser> user;
        private readonly FitnessDBContext context;
        private readonly IDietService dietService;

        public DietController(ILogger<RecipeController> logger, UserManager<ApplicationUser> user, FitnessDBContext context, IDietService dietService)
        {
            this.logger = logger;
			this.user = user;
			this.context = context;
			this.dietService = dietService;
		}

        [HttpGet]
        public async Task<IActionResult> MyDiets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var diets = await dietService.MyDietsAsync(userId!);

            return View(diets);
        }

        [HttpGet]
        public async Task<IActionResult> DefaultDiets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dietsViewModel = await dietService.DefaultDietsAsync(userId!);

			return View(dietsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DietDetails(Guid dietId)
        {
			var dietsViewModel = await dietService.DietDetailsAsync(dietId);
            
			return View(dietsViewModel);
        }

        [HttpGet]
        public IActionResult RecipeDetailsInDiet(Guid recipeId, Guid dietId)
        {
            var recipe = context.Recipes
                .Where(r => r.Id == recipeId)
                .FirstOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }

            RecipeDetailsInDiet viewModel = new RecipeDetailsInDiet
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

        [HttpPost]
        public IActionResult RemoveFromDiet(Guid dietId, Guid recipeId)
        {
            var toRemove = context.DietsRecipes
                .Where(x => x.RecipeId == recipeId && x.DietId == dietId)
                .FirstOrDefault();

            if (toRemove != null)
            {
                context.DietsRecipes.Remove(toRemove);

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

            return RedirectToAction("DietDetails", new { dietId = dietId });
        }

        [HttpGet]
        public IActionResult AddRecipeToDiet(Guid recipeId)
        {
            List<SelectListItem> diets = context.Diets
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .ToList();

            var viewModel = new AddRecipeToDietViewModel
            {
                RecipeId = recipeId,
                Diets = diets
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddRecipeToDiet(AddRecipeToDietViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isPresent = context.DietsRecipes.AsNoTracking().Where(dr => dr.DietId == model.SelectedDietId && dr.RecipeId == model.RecipeId).FirstOrDefault();

                if (isPresent!=null)
                {
                    model.Diets = context.Diets
                            .Select(d => new SelectListItem
                            {
                                Value = d.Id.ToString(),
                                Text = d.Name
                            })
                                .ToList();

                    model.RecipeId = model.RecipeId;
                    ViewBag.ErrorMessage = "This recipe is already added to the selected diet.";

                    return View(model);
                }

                var dietRecipe = new DietRecipe
                {
                    DietId = model.SelectedDietId,
                    RecipeId = model.RecipeId
                };
                ;
                context.DietsRecipes.Add(dietRecipe);

                context.SaveChanges();

                var diet = context.Diets
                    .Include(d => d.DietsRecipes)
                    .ThenInclude(dr => dr.Recipe)
                    .FirstOrDefault(d => d.Id == model.SelectedDietId);

                if (diet != null)
                {
                    diet.Calories = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Calories);

                    diet.Protein = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Protein);

                    diet.Carbohydrates = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Carbohydrates);

                    diet.Fats = diet.DietsRecipes
                        .Where(df => df.Recipe != null)
                        .Sum(df => df.Recipe.Fats);
                }

                context.SaveChanges();

                return RedirectToAction("DietDetails", new { id = model.SelectedDietId });
            }

            model.Diets = context.Diets
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToMyDiets(Guid dietId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new UserDiet
            {
                UserId = userId,
                DietId = dietId,
            };

            context.UsersDiets.Add(model);
            context.SaveChanges();

            return RedirectToAction("MyDiets", "Diet");
        }

        [HttpPost]
        public IActionResult RemoveFromMyDiets(Guid dietId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var record = context.UsersDiets.Where(ud => ud.UserId == userId && ud.DietId == dietId).FirstOrDefault();

            if (record == null)
            {
                //To implement
            }

            context.UsersDiets.Remove(record!);
            context.SaveChanges();

            return RedirectToAction("MyDiets", "Diet");
        }
    }
}
