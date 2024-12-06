using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
    public class ProgressService : BaseService, IProgressService
    {
        private IRepository<Progress, Guid> progressRepository;

        public ProgressService(IRepository<Progress, Guid> progressRepository)
        {
            this.progressRepository = progressRepository;
        }

        public async Task<List<ProgressModel>> GetProgressByUserId(string userId)
        {
            var model = await progressRepository.GetAllAttached()
                .Where(x => x.UserID == userId).OrderBy(x=>x.Date).Select(x=> new ProgressModel
                {
                    Value = x.Weight,
                    Date = x.Date
                })
                .ToListAsync();

            return model;
        }

        public async Task RegisterProgress(ProgressModel model, string userId)
        {
            var newProgress = new Progress
            {
                Id = Guid.NewGuid(),
                Date = model.Date,
                Weight = model.Value,
                UserID = userId!
            };

            await progressRepository.AddAsync(newProgress);
        }
    }
}
