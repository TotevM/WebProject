using System.Security.Claims;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels.RecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> RecipeDetailsInDiet(string recipeId, string dietId)
        {
            Guid dietGuid = Guid.Empty;
            bool isDietGuidValid = this.IsGuidValid(dietId, ref dietGuid);
            Guid recipeGuid = Guid.Empty;
            bool isRecipeGuidValid = this.IsGuidValid(recipeId, ref recipeGuid);
            if (!isDietGuidValid || !isRecipeGuidValid)
            {
                return this.RedirectToAction(nameof(MyDiets));
            }

            ViewModels.RecipeDetailsInDiet viewModel = await dietService.RecipeDetailsInDietAsync(recipeGuid, dietGuid);

            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(MyDiets));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromDiet(string dietId, string recipeId)
        {
            Guid dietGuid = Guid.Empty;
            bool isDietGuidValid = this.IsGuidValid(dietId, ref dietGuid);

            Guid recipeGuid = Guid.Empty;
            bool isRecipeGuidValid = this.IsGuidValid(recipeId, ref recipeGuid);

            if (!isDietGuidValid || !isRecipeGuidValid)
            {
                return this.RedirectToAction(nameof(MyDiets));
            }

            var isDefault = await dietService.IsDefaultDiet(dietGuid);
            var recipeExists = await dietService.RecipeExists(recipeGuid);

            if (isDefault == null || !recipeExists)//if diet doesnt exist
            {
                return RedirectToAction("MyDiets", "Diet");
            }

            var role = User.IsInRole("Admin") || User.IsInRole("Trainer");

            if (isDefault == true && !role)//if user isnt supposed to edit a default diet
            {
                return RedirectToAction("MyDiets", "Diet");
            }

            await dietService.RemoveFromDietAsync(dietGuid, recipeGuid);
            return RedirectToAction("DietDetails", new { dietId });
        }

        [HttpGet]
        public async Task<IActionResult> AddRecipeToDiet(string recipeId)
        {
            Guid recipeGuid = Guid.Empty;
            bool isRecipeGuidValid = this.IsGuidValid(recipeId, ref recipeGuid);

            if (!isRecipeGuidValid)
            {
                return this.RedirectToAction("Index", "Recipe");
            }

            bool role = User.IsInRole("Admin") || User.IsInRole("Trainer");
            var viewModel = await dietService.AddRecipeToDietViewAsync(recipeGuid, role);

            if (viewModel == null)
            {
                return this.RedirectToAction("Index", "Recipe");
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipeToDiet(AddRecipeToDietViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Diets = await dietService.GetDietsSelectListAsync();
                return View(model);
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
                model.Diets = await dietService.GetDietsSelectListAsync();
                return View(model);
            }

            var isPresent = await dietService.IsRecipeInDietAsync(recipeGuid, dietGuid);
            if (isPresent)
            {
                model.Diets = await dietService.GetDietsSelectListAsync();
                ViewBag.ErrorMessage = "This recipe is already added to the selected diet.";
                return View(model);
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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool succeed = await dietService.RemoveFromMyDietsAsync(dietGuid, userId!);

            if (!succeed)
            {
                return NotFound();
            }

            return RedirectToAction("MyDiets", "Diet");
        }
    }
}
