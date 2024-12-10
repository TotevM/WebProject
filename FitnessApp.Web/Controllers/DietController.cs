using System.Security.Claims;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels.RecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class DietController : BaseController
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
            List<ViewModels.MyDietsIndexView> diets = await dietService.MyDietsAsync(userId!);

            return View(diets);
        }

        [HttpGet]
        public async Task<IActionResult> DefaultDiets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ViewModels.DietIndexView> dietsViewModel = await dietService.DefaultDietsAsync(userId!);

            return View(dietsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DietDetails(string dietId)
        {
            Guid dietGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(dietId.ToString(), ref dietGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(MyDiets));
            }

            List<ViewModels.DietDetailsView>? dietsViewModel = await dietService.DietDetailsAsync(dietGuid);

            if (dietsViewModel == null)
            {
                return RedirectToAction(nameof(MyDiets));
            }

            return View(dietsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipeToDiet(AddRecipeToDietViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Recipe");
            }
            Guid dietGuid = Guid.Empty;
            bool isDietGuidValid = this.IsGuidValid(model.SelectedDietId, ref dietGuid);

            Guid recipeGuid = Guid.Empty;
            bool isRecipeGuidValid = this.IsGuidValid(model.RecipeId, ref recipeGuid);

            if (!isDietGuidValid || !isRecipeGuidValid)
            {
                return this.RedirectToAction("Index", "Recipe");
            }

            bool recipeExists = await dietService.RecipeExists(recipeGuid);
            bool dietExists = await dietService.DietExists(dietGuid);

            if (!recipeExists || !dietExists)
            {
                return RedirectToAction("Index", "Recipe");
            }

            var isDefault =await dietService.IsDefaultDiet(dietGuid);
            bool isInRole = User.IsInRole(TrainerRole);

            var isPresent = await dietService.IsRecipeInDietAsync(recipeGuid, dietGuid);
            if (isPresent)
            {
                TempData["ErrorMessage"] = "This recipe is already added to the selected diet.";
                return RedirectToAction("Index", "Recipe");
            }

            if (isDefault==true)
            {
                if (isInRole)
                {
                    await dietService.AddRecipeToDietAsync(recipeGuid, dietGuid);
                    await dietService.UpdateDietMacronutrientsAsync(dietGuid);

                    return RedirectToAction("DietDetails", new { dietId = model.SelectedDietId });
                }
                TempData["ErrorMessage"] = "You arent allowed to edit a default diet.";
                return RedirectToAction("Index", "Recipe");
            }


            await dietService.AddRecipeToDietAsync(recipeGuid, dietGuid);
            await dietService.UpdateDietMacronutrientsAsync(dietGuid);

            return RedirectToAction("DietDetails", new { dietId = model.SelectedDietId });
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyDiets(string dietId)
        {
            Guid dietGuid = Guid.Empty;
            bool isDietGuidValid = this.IsGuidValid(dietId, ref dietGuid);

            if (!isDietGuidValid)
            {
                return RedirectToAction("Index", "Recipe");
            }

            bool dietExists = await dietService.DietExists(dietGuid);

            if (!dietExists)
            {
                return RedirectToAction("Index", "Recipe");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await dietService.AddToMyDietsAsync(dietGuid, userId!);
            return RedirectToAction("MyDiets", "Diet");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromMyDiets(string dietId)
        {
            Guid dietGuid = Guid.Empty;
            bool isDietGuidValid = this.IsGuidValid(dietId, ref dietGuid);

            if (!isDietGuidValid)
            {
                return RedirectToAction("MyDiets", "Diet");
            }

            bool dietExists = await dietService.DietExists(dietGuid);

            if (!dietExists)
            {
                return RedirectToAction("MyDiets", "Diet");
            }

            var isDefault = await dietService.IsDefaultDiet(dietGuid);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (isDefault==false)
            {
                bool successful = await dietService.RemoveFromMyDietsAsync(dietGuid, userId!);
                if (!successful)
                {
                    return NotFound();
                }

                await dietService.DeleteDiet(dietGuid);
                return RedirectToAction("MyDiets", "Diet");
            }

            bool succeed = await dietService.RemoveFromMyDietsAsync(dietGuid, userId!);

            if (!succeed)
            {
                return NotFound();
            }

            return RedirectToAction("MyDiets", "Diet");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var availableRecipes = await dietService.GetAllRecipeModelAsync();

            ViewBag.AvailableRecipes = availableRecipes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromDiet(string dietId, string recipeId)
        {
            Guid dietGuid = Guid.Empty;
            bool isDietGuidValid = this.IsGuidValid(dietId, ref dietGuid);

            Guid recipeGuid = Guid.Empty;
            bool isRecipeGuidValid = this.IsGuidValid(recipeId, ref recipeGuid);

            if (!isDietGuidValid && !isRecipeGuidValid)
            {
                return this.RedirectToAction(nameof(MyDiets));
            }

            var isDefault = await dietService.IsDefaultDiet(dietGuid);
            var recipeExists = await dietService.RecipeExists(recipeGuid);

            if (isDefault == null && !recipeExists)
            {
                return RedirectToAction("MyDiets", "Diet");
            }

            var role = User.IsInRole(TrainerRole);

            if (isDefault == true && !role)
            { 
                await dietService.RemoveFromDietAsync(dietGuid, recipeGuid);
                return RedirectToAction("MyDiets", "Diet");
            }

            await dietService.RemoveFromDietAsync(dietGuid, recipeGuid);
            return RedirectToAction("DietDetails", new { dietId });
        }
    }
}
