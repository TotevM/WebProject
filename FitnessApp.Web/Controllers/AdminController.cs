using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = userManager.Users.ToList();

            var model = new List<UserRoleViewModel>();
            foreach (var user in users)
            {
                var isTrainer = await userManager.IsInRoleAsync(user, "Trainer");
                model.Add(new UserRoleViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    IsTrainer = isTrainer
                });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleTrainerRole(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var isTrainer = await userManager.IsInRoleAsync(user, "Trainer");

            if (isTrainer)
            {
                await userManager.RemoveFromRoleAsync(user, "Trainer");
            }
            else
            {
                await userManager.AddToRoleAsync(user, "Trainer");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
