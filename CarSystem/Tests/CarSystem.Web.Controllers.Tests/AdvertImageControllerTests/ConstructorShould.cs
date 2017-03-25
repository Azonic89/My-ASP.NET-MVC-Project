using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Services.Contracts;

namespace CarSystem.Web.Controllers.Tests.AdvertImageControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_ThrowArgumentNullException_WhenAdvertImageServiceParameterIsNull()
        {
            // Arrange
            IAdvertImageService nullAdvertImageService = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AdvertImageController(nullAdvertImageService));
        }

        [Test]
        public void Constructor_Should_CreateInstanceOfAdvertImageService_WhenAdvertImageServiceParameterIsNotNull()
        {
            // Arrange
            var mockdedAdvertImageService = new Mock<IAdvertImageService>();
            var advertImageController = new AdvertImageController(mockdedAdvertImageService.Object);

            // Act & Assert
            Assert.That(advertImageController, Is.Not.Null);
            Assert.IsInstanceOf<AdvertImageController>(advertImageController);
        }
    }
}
