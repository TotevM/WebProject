using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts.FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Services
{
    public class ManagerService : IManagerService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ManagerService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IEnumerable<ManageAdminsViewModel>> GetAllUsersWithAdminStatusAsync()
        {
            var users = await userManager.Users.ToListAsync();
            var models = new List<ManageAdminsViewModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                models.Add(new ManageAdminsViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    IsAdmin = roles.Contains(AdminRole),
                    CurrentRoles = roles.ToList()
                });
            }
            return models;
        }

        public async Task<bool> ToggleAdminRoleAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var currentRoles = await userManager.GetRolesAsync(user);
            var isCurrentlyAdmin = currentRoles.Contains(AdminRole);

            if (isCurrentlyAdmin)
            {
                await userManager.RemoveFromRoleAsync(user, AdminRole);

                var remainingRoles = await userManager.GetRolesAsync(user);
                if (remainingRoles.Count == 0)
                {
                    await userManager.AddToRoleAsync(user, UserRole);
                }
            }
            else
            {
                if (currentRoles.Contains(UserRole))
                {
                    await userManager.RemoveFromRoleAsync(user, UserRole);
                }

                await userManager.AddToRoleAsync(user, AdminRole);
            }

            return true;
        }

        public async Task<IEnumerable<ManageUsersModel>> GetAllUsersWithRolesAsync()
        {
            var users = await userManager.Users.IgnoreQueryFilters().ToListAsync();
            var models = new List<ManageUsersModel>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                models.Add(new ManageUsersModel
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    IsDeleted = user.IsDeleted,
                    Roles = roles.ToList()
                });
            }

            return models;
        }

        public async Task<bool> ToggleTrainerRoleAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var isTrainer = await userManager.IsInRoleAsync(user, TrainerRole);
            var isUser = await userManager.IsInRoleAsync(user, UserRole);

            if (isTrainer)
            {
                await userManager.RemoveFromRoleAsync(user, TrainerRole);
                if (!isUser)
                {
                    await userManager.AddToRoleAsync(user, UserRole);
                }
            }
            else
            {
                if (isUser)
                {
                    await userManager.RemoveFromRoleAsync(user, UserRole);
                }

                await userManager.AddToRoleAsync(user, TrainerRole);
            }

            return true;
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
