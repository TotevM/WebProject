using FitnessApp.Services.ServiceContracts.FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserRoleService _userRoleService;

        public AdminController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _userRoleService.GetAllUsersWithRolesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleTrainerRole(string userId)
        {
            var success = await _userRoleService.ToggleTrainerRoleAsync(userId);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
