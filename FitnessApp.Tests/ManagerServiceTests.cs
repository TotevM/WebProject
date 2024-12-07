using FitnessApp.Data.Models;
using FitnessApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using static FitnessApp.Common.ApplicationConstants;

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
        public async Task ToggleUserDeleteAsync_UserNotFound_ReturnsFalse()
        {
            var testUserId = Guid.NewGuid().ToString();

            _mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            var result = await _managerService.ToggleUserDeletionAsync(testUserId);

            Assert.IsFalse(result);

            _mockUserManager.Verify(x => x.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never);
        }

        [Test]
        public async Task ToggleAdminRoleAsync_UserNotFound_ReturnsFalse()
        {
            var testUserId = Guid.NewGuid().ToString();

            _mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            var result = await _managerService.ToggleAdminRoleAsync(testUserId);

            Assert.IsFalse(result);

            _mockUserManager.Verify(x => x.GetRolesAsync(It.IsAny<ApplicationUser>()), Times.Never);
            _mockUserManager.Verify(x => x.RemoveFromRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
            _mockUserManager.Verify(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task ToggleUserDeletionAsync_UserNotFound_ReturnsFalse()
        {
            var testUserId = Guid.NewGuid().ToString();
            _mockUserManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            var result = await _managerService.ToggleUserDeletionAsync(testUserId);

            Assert.IsFalse(result);

            _mockUserManager.Verify(x => x.UpdateAsync(It.IsAny<ApplicationUser>()), Times.Never);
        }

        [Test]
        public async Task ToggleAdminRoleAsync_UserIsAdmin_ShouldRemoveAdminRole()
        {
            var userId = "test-user-id";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager
                .Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager
                .Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { AdminRole, UserRole });

            _mockUserManager
                .Setup(x => x.RemoveFromRoleAsync(user, AdminRole))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _managerService.ToggleAdminRoleAsync(userId);

            Assert.That(result, Is.True);

            _mockUserManager.Verify(x => x.FindByIdAsync(userId), Times.Once);
            _mockUserManager.Verify(x => x.GetRolesAsync(user), Times.Exactly(2));
            _mockUserManager.Verify(x => x.RemoveFromRoleAsync(user, AdminRole), Times.Once);
            _mockUserManager.Verify(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task ToggleTrainerRoleAsync_UserIsTrainer_ShouldRemoveTrainerRoleAndAddUserRoleIfNeeded()
        {
            var userId = "test-user-id";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager
                .Setup(x => x.FindByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserManager
                .Setup(x => x.IsInRoleAsync(user, It.Is<string>(r => r == TrainerRole)))
                .ReturnsAsync(true);

            _mockUserManager
                .Setup(x => x.IsInRoleAsync(user, It.Is<string>(r => r == UserRole)))
                .ReturnsAsync(false);

            _mockUserManager
                .Setup(x => x.RemoveFromRoleAsync(user, TrainerRole))
                .ReturnsAsync(IdentityResult.Success);

            _mockUserManager
                .Setup(x => x.AddToRoleAsync(user, UserRole))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _managerService.ToggleTrainerRoleAsync(userId);

            Assert.That(result, Is.True);

            _mockUserManager.Verify(x => x.FindByIdAsync(userId), Times.Once);
            _mockUserManager.Verify(x => x.IsInRoleAsync(user, TrainerRole), Times.Once);
            _mockUserManager.Verify(x => x.IsInRoleAsync(user, UserRole), Times.Once);
            _mockUserManager.Verify(x => x.RemoveFromRoleAsync(user, TrainerRole), Times.Once);
            _mockUserManager.Verify(x => x.AddToRoleAsync(user, UserRole), Times.Once);
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