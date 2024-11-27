using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    namespace FitnessApp.Services.ServiceContracts
    {
        public interface IUserRoleService
        {
            Task<List<UserRoleViewModel>> GetAllUsersWithRolesAsync();
            Task<bool> ToggleTrainerRoleAsync(string userId);
        }
    }
}
