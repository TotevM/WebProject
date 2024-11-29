using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts.FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class ManagerService : IManagerService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ManagerService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<UserRoleViewModel>> GetAllUsersWithRolesAsync()
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

            return model;
        }

        public async Task<bool> ToggleTrainerRoleAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
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

            return true;
        }

        public async Task SoftDeleteUserAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsDeleted = true;
                await userManager.UpdateAsync(user);
            }
        }

        public async Task<IEnumerable<ManageUsersModel>> GetAllUsersAsync()
        {
            var users = await userManager.Users.IgnoreQueryFilters()
                .Select(u => new ManageUsersModel
                {
                    Id = u.Id,
                    UserName = u.UserName!,
                    Email = u.Email!,
                    IsDeleted = u.IsDeleted
                })
                .ToListAsync();

            return users;
        }

        public async Task<bool> ToggleUserDeletionAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.IsDeleted = !user.IsDeleted;
            await userManager.UpdateAsync(user);
            return true;
        }
    }
}
