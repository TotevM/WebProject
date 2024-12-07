using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IManagerService
    {
        Task<IEnumerable<ManageUsersModel>> GetAllUsersWithRolesAsync();
        Task<bool> ToggleTrainerRoleAsync(string userId);
        Task<bool> ToggleUserDeletionAsync(string userId);
        Task<IEnumerable<ManageAdminsViewModel>> GetAllUsersWithAdminStatusAsync();
        Task<bool> ToggleAdminRoleAsync(string userId);
    }
}
