using System.Security.Claims;
using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class ProgressController : BaseController
    {
        private readonly ILogger<ProgressController> logger;
        private readonly UserManager<ApplicationUser> user;
        private readonly IProgressService progressService;

        public ProgressController(ILogger<ProgressController> _logger, UserManager<ApplicationUser> _user, IProgressService progressService)
        {
            logger = _logger;
            user = _user;
            this.progressService = progressService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ProgressModel> model = await progressService.GetProgressByUserId(userId!);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProgress(ProgressModel model)
        {
            if (ModelState.IsValid)
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await progressService.RegisterProgress(model, userId!);

                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}
