using FitnessApp.Data.Models;
using FitnessApp.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace FitnessApp.Tests
{
    [TestFixture]
    public class ManagerServiceTests
    {
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private ManagerService _managerService;
        private Mock<ApplicationUser> _mockUser;

        [SetUp]
        public void Setup()
        {
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(),
                null, null, null, null, null, null, null, null);
            _managerService = new ManagerService(_mockUserManager.Object);
        }

        [Test]
        public async Task ToggleTrainerRoleAsync_ShouldToggleTrainerRole_WhenUserIsNotTrainer()
        {
            var user = new ApplicationUser { Id = "1", UserName = "User1", Email = "user1@example.com" };
            _mockUserManager.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);

            _mockUserManager.Setup(um => um.IsInRoleAsync(It.IsAny<ApplicationUser>(), "Trainer")).ReturnsAsync(false);
            _mockUserManager.Setup(um => um.IsInRoleAsync(It.IsAny<ApplicationUser>(), "User")).ReturnsAsync(true);
            _mockUserManager.Setup(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _managerService.ToggleTrainerRoleAsync("1");

            Assert.IsTrue(result);
            _mockUserManager.Verify(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"),
                Times.Never);
            _mockUserManager.Verify(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"),
                Times.Once);
            _mockUserManager.Verify(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "User"),
                Times.Once);
        }

        [Test]
        public async Task ToggleAdminRoleAsync_ShouldToggleAdminRole_WhenUserIsAdmin()
        {
            var user = new ApplicationUser { Id = "1", UserName = "User1", Email = "user1@example.com" };
            _mockUserManager.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);

            _mockUserManager.Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(new List<string> { "Admin" });
            _mockUserManager.Setup(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "Admin"))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Admin"))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _managerService.ToggleAdminRoleAsync("1");

            Assert.IsTrue(result);
            _mockUserManager.Verify(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "Admin"), Times.Once);
            _mockUserManager.Verify(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Admin"),
                Times.Never);
        }

        [Test]
        public async Task ToggleAdminRoleAsync_ShouldToggleAdminRole()
        {
            var user = new ApplicationUser { Id = "1", UserName = "User1", Email = "user1@example.com" };
            _mockUserManager.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(new List<string> { "User" });
            _mockUserManager.Setup(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Admin"))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "Admin"))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _managerService.ToggleAdminRoleAsync("1");

            Assert.IsTrue(result);
            _mockUserManager.Verify(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Admin"), Times.Once);
        }

        [Test]
        public async Task ToggleTrainerRoleAsync_ShouldToggleTrainerRole()
        {
            var user = new ApplicationUser { Id = "1", UserName = "User1", Email = "user1@example.com" };
            _mockUserManager.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.IsInRoleAsync(It.IsAny<ApplicationUser>(), "Trainer")).ReturnsAsync(false);
            _mockUserManager.Setup(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"))
                .ReturnsAsync(IdentityResult.Success);
            _mockUserManager.Setup(um => um.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _managerService.ToggleTrainerRoleAsync("1");

            Assert.IsTrue(result);
            _mockUserManager.Verify(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Trainer"), Times.Once);
        }

        [Test]
        public async Task ToggleUserDeletionAsync_ShouldToggleUserDeletionStatus()
        {
            var user = new ApplicationUser
            { Id = "1", UserName = "User1", Email = "user1@example.com", IsDeleted = false };
            _mockUserManager.Setup(um => um.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserManager.Setup(um => um.UpdateAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _managerService.ToggleUserDeletionAsync("1");

            Assert.IsTrue(result);
            Assert.IsTrue(user.IsDeleted);
            _mockUserManager.Verify(um => um.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Once);
        }
    }
}