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
            List<ViewModels.DietIndexView> dietsViewModel = await dietService.DefaultDietsForTrainersAsync();

            return View(dietsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var availableRecipes = await dietService.GetAllRecipeModelAsync();

            ViewBag.AvailableRecipes = availableRecipes;

            return View();
        }
    }
}
