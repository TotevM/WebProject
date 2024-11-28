using FitnessApp.Services.ServiceContracts.FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IManagerService adminService;

        public AdminController(IManagerService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageRoles()
        {
            var model = await adminService.GetAllUsersWithRolesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleTrainerRole(string userId)
        {
            var success = await adminService.ToggleTrainerRoleAsync(userId);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return RedirectToAction(nameof(ManageRoles));
        }

        [HttpGet]
        public async Task<IActionResult> ManageUsers()
        {
            var model = await adminService.GetAllUsersAsync();
            return View(model);
        }

        // Toggle User Deletion Status
        [HttpPost]
        public async Task<IActionResult> ToggleDelete(string userId)
        {
            var success = await adminService.ToggleUserDeletionAsync(userId);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return RedirectToAction(nameof(ManageUsers));
        }
    }
}
