using Moq;
using TestStack.FluentMVCTesting;
using NUnit.Framework;

using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Web.Controllers.Tests.AdvertImageControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void Index_Should_ReturnCorrectImageParams()
        {
            // Arrange
            var advertImage = new AdvertImage
            {
                Id = 1,
                ImageData = new byte[5],
                ImageName = "ContentType"
            };

            var mockedAdvertImageService = new Mock<IAdvertImageService>();
            mockedAdvertImageService.Setup(x => x.GetById(It.IsAny<int>())).Returns(advertImage);

            var advertImageController = new AdvertImageController(mockedAdvertImageService.Object);

            // Act & assert
            advertImageController.WithCallTo(x => x.Index(It.IsAny<int>())).ShouldRenderFileContents(advertImage.ImageData, advertImage.ImageName);
        }

        [Test]
        public void Index_Should_ReturnNullImageParams()
        {
            // Arrange
            AdvertImage nullAdvertImage = null;
            var mockedAdvertImageService = new Mock<IAdvertImageService>();

            mockedAdvertImageService.Setup(x => x.GetById(It.IsAny<int?>())).Returns(nullAdvertImage);

            var advertImageController = new AdvertImageController(mockedAdvertImageService.Object);

            // Act & assert
            advertImageController.WithCallTo(x => x.Index(It.IsAny<int>())).ShouldReturnContent(null);
        }
    }
}
