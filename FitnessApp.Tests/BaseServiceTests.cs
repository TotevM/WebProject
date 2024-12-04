using NUnit.Framework;
using System;
using FitnessApp.Services;

namespace FitnessApp.Tests
{
    [TestFixture]
    public class BaseServiceTests
    {
        private BaseService _baseService;

        [SetUp]
        public void SetUp()
        {
            // Initialize BaseService before each test
            _baseService = new BaseService();
        }

        [Test]
        public void IsGuidValid_ShouldReturnTrue_WhenValidGuid()
        {
            // Arrange
            var validGuidString = Guid.NewGuid().ToString();
            Guid parsedGuid = Guid.Empty;

            // Act
            var result = _baseService.IsGuidValid(validGuidString, ref parsedGuid);

            // Assert
            Assert.IsTrue(result); // Ensure the result is true
            Assert.AreNotEqual(Guid.Empty, parsedGuid); // Ensure parsedGuid is set to the parsed value
            Assert.AreEqual(new Guid(validGuidString), parsedGuid); // Ensure parsedGuid matches the input GUID
        }

        [Test]
        public void IsGuidValid_ShouldReturnFalse_WhenInvalidGuid()
        {
            // Arrange
            var invalidGuidString = "invalid-guid";
            Guid parsedGuid = Guid.Empty;

            // Act
            var result = _baseService.IsGuidValid(invalidGuidString, ref parsedGuid);

            // Assert
            Assert.IsFalse(result); // Ensure the result is false
            Assert.AreEqual(Guid.Empty, parsedGuid); // Ensure parsedGuid is still Guid.Empty
        }

        [Test]
        public void IsGuidValid_ShouldReturnFalse_WhenNullGuid()
        {
            // Arrange
            string? nullGuidString = null;
            Guid parsedGuid = Guid.Empty;

            // Act
            var result = _baseService.IsGuidValid(nullGuidString, ref parsedGuid);

            // Assert
            Assert.IsFalse(result); // Ensure the result is false
            Assert.AreEqual(Guid.Empty, parsedGuid); // Ensure parsedGuid is still Guid.Empty
        }

        [Test]
        public void IsGuidValid_ShouldReturnFalse_WhenEmptyGuid()
        {
            // Arrange
            string? emptyGuidString = string.Empty;
            Guid parsedGuid = Guid.Empty;

            // Act
            var result = _baseService.IsGuidValid(emptyGuidString, ref parsedGuid);

            // Assert
            Assert.IsFalse(result); // Ensure the result is false
            Assert.AreEqual(Guid.Empty, parsedGuid); // Ensure parsedGuid is still Guid.Empty
        }
    }
}
