using System.Security.Claims;
using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class DietController : Controller
    {
        private readonly IDietService dietService;

        public DietController(IDietService dietService)
        {
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

            if (viewModel == null)
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
        public async Task<IActionResult> AddRecipeToDiet(Guid recipeId)
        {
            var viewModel = await dietService.AddRecipeToDietViewAsync(recipeId);
            return View(viewModel);
        }//working

        [HttpPost]
        public async Task<IActionResult> AddRecipeToDiet(AddRecipeToDietViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Diets = await dietService.GetDietsSelectListAsync();
                return View(model);
            }

            var isPresent = await dietService.IsRecipeInDietAsync(model.RecipeId, model.SelectedDietId);
            if (isPresent)
            {
                model.Diets = await dietService.GetDietsSelectListAsync();
                ViewBag.ErrorMessage = "This recipe is already added to the selected diet.";
                return View(model);
            }

            await dietService.AddRecipeToDietAsync(model.RecipeId, model.SelectedDietId);
            await dietService.UpdateDietMacronutrientsAsync(model.SelectedDietId);

            return RedirectToAction("DietDetails", new { dietId = model.SelectedDietId });
        }//working

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
