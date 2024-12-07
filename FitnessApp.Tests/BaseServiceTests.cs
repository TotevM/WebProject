using FitnessApp.Services;
using NUnit.Framework;

namespace FitnessApp.Tests
{
    [TestFixture]
    public class BaseServiceTests
    {
        private BaseService _baseService;

        [SetUp]
        public void SetUp()
        {
            _baseService = new BaseService();
        }

        [Test]
        public void IsGuidValid_ShouldReturnTrue_WhenValidGuid()
        {
            var validGuidString = Guid.NewGuid().ToString();
            Guid parsedGuid = Guid.Empty;

            var result = _baseService.IsGuidValid(validGuidString, ref parsedGuid);

            Assert.IsTrue(result);
            Assert.AreNotEqual(Guid.Empty, parsedGuid);
            Assert.AreEqual(new Guid(validGuidString), parsedGuid);
        }

        [Test]
        public void IsGuidValid_ShouldReturnFalse_WhenInvalidGuid()
        {
            var invalidGuidString = "invalid-guid";
            Guid parsedGuid = Guid.Empty;

            var result = _baseService.IsGuidValid(invalidGuidString, ref parsedGuid);

            Assert.IsFalse(result);
            Assert.AreEqual(Guid.Empty, parsedGuid);
        }

        [Test]
        public void IsGuidValid_ShouldReturnFalse_WhenNullGuid()
        {
            string? nullGuidString = null;
            Guid parsedGuid = Guid.Empty;

            var result = _baseService.IsGuidValid(nullGuidString, ref parsedGuid);

            Assert.IsFalse(result);
            Assert.AreEqual(Guid.Empty, parsedGuid);
        }

        [Test]
        public void IsGuidValid_ShouldReturnFalse_WhenEmptyGuid()
        {
            string? emptyGuidString = string.Empty;
            Guid parsedGuid = Guid.Empty;

            var result = _baseService.IsGuidValid(emptyGuidString, ref parsedGuid);

            Assert.IsFalse(result);
            Assert.AreEqual(Guid.Empty, parsedGuid);
        }
    }
}
