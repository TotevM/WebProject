using System.Security.Claims;
using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels.RecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Goal? goal = null)
        {
            var model = await recipeService.DisplayRecipesAsync(goal);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = recipeService.AddRecipe();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeView model)
        {
            if (!ModelState.IsValid)
            {
                var filledGoals = recipeService.AddRecipe();
                model.Goals = filledGoals.Goals;
                return View(model);
            }

            if (!Goal.TryParse(model.Goal, out Goal goal))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await recipeService.AddRecipeAsync(model, goal, userId);

            return RedirectToAction("Index", "Recipe");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref exerciseGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var recipeModel = await recipeService.EditView(exerciseGuid);
            return View(recipeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var filledGoals = recipeService.AddRecipe();
                model.Goals = filledGoals.Goals;

                return View(model);
            }

            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(model.Id, ref exerciseGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            Recipe? recipe = await recipeService.GetRecipeAsync(exerciseGuid);

            if (recipe == null)
            {
                return NotFound();
            }

            if (!Goal.TryParse(model.Goal, out Goal goal))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            await recipeService.UpdateRecipe(recipe, model, goal);
            await recipeService.UpdateDietsAsync(exerciseGuid);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref exerciseGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var recipe = await recipeService.GetRecipeAsync(exerciseGuid);

            if (recipe == null)
            {
                return NotFound();
            }

            var viewModel = recipeService.RecipeDetailsView(recipe);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRecipeView model)
        {
            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(model.Id, ref exerciseGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var recipe = await recipeService.GetRecipeAsync(exerciseGuid);

            if (recipe == null)
            {
                return NotFound();
            }

            await recipeService.SoftDeleteRecipe(recipe!);
            await recipeService.DeleteDietRecipeRelationAsync(exerciseGuid);
            await recipeService.UpdateDietsAsync(exerciseGuid);
            return RedirectToAction("Index", "Recipe");
        }
    }
}
