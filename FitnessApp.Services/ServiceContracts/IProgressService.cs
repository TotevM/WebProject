using FitnessApp.ViewModels;

namespace FitnessApp.Services.ServiceContracts
{
    public interface IProgressService
    {
        Task<List<ProgressModel>> GetProgressByUserId(string userId);
        Task RegisterProgress(ProgressModel model, string userId);
    }
}
