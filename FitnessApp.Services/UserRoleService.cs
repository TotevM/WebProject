using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts.FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FitnessApp.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRoleService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserRoleViewModel>> GetAllUsersWithRolesAsync()
        {
            var users = _userManager.Users.ToList();

            var model = new List<UserRoleViewModel>();
            foreach (var user in users)
            {
                var isTrainer = await _userManager.IsInRoleAsync(user, "Trainer");
                model.Add(new UserRoleViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    IsTrainer = isTrainer
                });
            }

            return model;
        }

        public async Task<bool> ToggleTrainerRoleAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var isTrainer = await _userManager.IsInRoleAsync(user, "Trainer");

            if (isTrainer)
            {
                await _userManager.RemoveFromRoleAsync(user, "Trainer");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Trainer");
            }

            return true;
        }
    }
}
