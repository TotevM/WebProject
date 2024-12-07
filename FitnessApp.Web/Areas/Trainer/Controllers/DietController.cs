using System.Security.Claims;
using FitnessApp.Services;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Web.Areas.Trainer.Controllers
{
    [Authorize(Roles = TrainerRole)]
    [Area(TrainerRole)]
    public class DietController : BaseController
    {
        private readonly IDietService dietService;

        public DietController(IDietService dietService)
        {
            this.dietService = dietService;
        }


        [HttpGet]
        public async Task<IActionResult> ManageDefaultDiets()
        {
            List<ViewModels.DietIndexView> dietsViewModel = await dietService.DefaultDietsAsync(null);

            return View(dietsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var availableRecipes = await dietService.GetAllRecipeModelAsync();

            ViewBag.AvailableRecipes = availableRecipes;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DietDetails(string dietId)
        {
            Guid dietGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(dietId.ToString(), ref dietGuid);
            if (!isGuidValid)
            {
                return this.RedirectToAction(nameof(ManageDefaultDiets));
            }

            List<ViewModels.DietDetailsView>? dietsViewModel = await dietService.DietDetailsAsync(dietGuid);

            if (dietsViewModel == null)
            {
                return this.RedirectToAction(nameof(ManageDefaultDiets));
            }

            return View(dietsViewModel);
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
                return this.RedirectToAction(nameof(ManageDefaultDiets));
            }

            var isDefault = await dietService.IsDefaultDiet(dietGuid);
            var recipeExists = await dietService.RecipeExists(recipeGuid);

            if (isDefault == null || !recipeExists)
            {
                //sth is wrong display msg
                return this.RedirectToAction(nameof(ManageDefaultDiets));
            }

            var role = User.IsInRole(TrainerRole);

            if (isDefault == true && !role)
            {
                //msg display cant change the recipes default diet
                /*await dietService.RemoveFromDietAsync(dietGuid, recipeGuid);*///To remove after implementing add custom diet
                return this.RedirectToAction(nameof(ManageDefaultDiets));
            }

            await dietService.RemoveFromDietAsync(dietGuid, recipeGuid);
            return RedirectToAction("DietDetails", new { dietId });
        }
    }
}
