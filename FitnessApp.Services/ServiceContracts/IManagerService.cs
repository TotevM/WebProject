using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    namespace FitnessApp.Services.ServiceContracts
    {
        public interface IManagerService
        {
            Task<List<UserRoleViewModel>> GetAllUsersWithRolesAsync();
            Task<bool> ToggleTrainerRoleAsync(string userId);
            public Task SoftDeleteUserAsync(string userId);

            Task<IEnumerable<ManageUsersModel>> GetAllUsersAsync();
            Task<bool> ToggleUserDeletionAsync(string userId);
        }
    }
}
