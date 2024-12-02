using FitnessApp.Services.ServiceContracts.FitnessApp.Services.ServiceContracts;
using FitnessApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = AdminRole)]
    [Area(AdminRole)]
    public class ManageController : BaseController
    {
        private readonly IManagerService adminService;

        public ManageController(IManagerService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageAdmins()
        {
            var users = await adminService.GetAllUsersWithAdminStatusAsync();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleAdmin(string userId)
        {
            var result = await adminService.ToggleAdminRoleAsync(userId);

            if (result)
            {
                TempData["SuccessMessage"] = "Admin status updated successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update admin status.";
            }

            return RedirectToAction(nameof(ManageAdmins));
        }


        [HttpGet]
        public async Task<IActionResult> ManageTrainers()
        {
            var model = await adminService.GetAllUsersWithRolesAsync(); // Fetch users along with roles
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

            return RedirectToAction(nameof(ManageTrainers));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleDelete(string userId)
        {
            var success = await adminService.ToggleUserDeletionAsync(userId);
            if (!success)
            {
                return NotFound("User not found.");
            }

            return RedirectToAction(nameof(ManageTrainers));
        }
    }
}
