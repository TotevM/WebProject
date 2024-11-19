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
        }//working

        [HttpGet]
        public async Task<IActionResult> DefaultDiets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dietsViewModel = await dietService.DefaultDietsAsync(userId!);

			return View(dietsViewModel);
        }//working

        [HttpGet]
        public async Task<IActionResult> DietDetails(Guid dietId)
        {
			var dietsViewModel = await dietService.DietDetailsAsync(dietId);
            
			return View(dietsViewModel);
        }//working

        [HttpGet]
        public async Task<IActionResult> RecipeDetailsInDiet(Guid recipeId, Guid dietId)
        {
            var viewModel = await dietService.RecipeDetailsInDietAsync(recipeId, dietId);

            if (viewModel==null)
            {
                return NotFound();
            }

            return View(viewModel);
        }//working

        [HttpPost]
        public async Task<IActionResult> RemoveFromDiet(Guid dietId, Guid recipeId)
        {
            await dietService.RemoveFromDietAsync(dietId, recipeId);
            return RedirectToAction("DietDetails", new { dietId });
        }//working

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

                return RedirectToAction("DietDetails", new { dietId = model.SelectedDietId });
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
        public async Task<IActionResult> AddToMyDiets(Guid dietId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await dietService.AddToMyDietsAsync(dietId, userId!);
            return RedirectToAction("MyDiets", "Diet");
        }//working

        [HttpPost]
        public async Task<IActionResult> RemoveFromMyDiets(Guid dietId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool succeed = await dietService.RemoveFromMyDietsAsync(dietId, userId!);

            if (!succeed)
            {
                return NotFound();
            }

            return RedirectToAction("MyDiets", "Diet");
        }//working
    }
}
