using FitnessApp.Data.Models;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace FitnessApp.Tests
{
    public class ProgressServiceTests
    {
        private Mock<IRepository<Progress, Guid>> _progressRepositoryMock;
        private IProgressService _progressService;

        [SetUp]
        public void Setup()
        {
            _progressRepositoryMock = new Mock<IRepository<Progress, Guid>>();
            _progressService = new ProgressService(_progressRepositoryMock.Object);
        }

        [Test]
        public async Task RegisterProgress_AddsNewProgressSuccessfully()
        {
            var userId = "test-user";
            var progressModel = new ProgressModel
            {
                Date = DateTime.Now,
                Value = 68
            };

            await _progressService.RegisterProgress(progressModel, userId);

            _progressRepositoryMock.Verify(
                repo => repo.AddAsync(It.Is<Progress>(p =>
                    p.Weight == progressModel.Value &&
                    p.Date == progressModel.Date &&
                    p.UserID == userId)),
                Times.Once);
        }
    }
}
