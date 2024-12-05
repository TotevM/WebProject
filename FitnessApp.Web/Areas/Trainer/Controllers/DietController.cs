using System.Security.Claims;
using FitnessApp.Services;
using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Web.Areas.Trainer.Controllers
{
    [Authorize(Roles = TrainerRole)]
    [Area(TrainerRole)]
    public class DietController : Controller
    {
        private readonly IDietService dietService;

        public DietController(DietService dietService)
        {
            this.dietService = dietService;
        }


        [HttpGet]
        public async Task<IActionResult> ManageDefaultDiets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ViewModels.DietIndexView> dietsViewModel = await dietService.DefaultDietsAsync(userId!);

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
