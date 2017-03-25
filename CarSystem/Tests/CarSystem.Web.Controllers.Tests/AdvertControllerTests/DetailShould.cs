using System.Net;

using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Controllers.Tests.AdvertControllerTests
{
    [TestFixture]
    public class DetailShould
    {
        [Test]
        public void Detail_Should_ReturnHttpStatusCode_BadRequest_WhenIdParameterIsNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act & Assert
            advertController
                .WithCallTo(c => c.Detail(null))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Detail_Should_InvokeAdvertServiceMethod_GetById_Once_WhenIdParameterIsNotNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act
            advertController.Detail(1);

            // Assert
            mockedAdvertService.Verify(a => a.GetById(It.IsAny<int?>()), Times.Once);
        }

        [Test]
        public void Detail_Should_ReturnHttpStatusCode_NotFound_WhenNotFindAdvert()
        {
            // Arrange
            Advert nullAdvert = null;

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            mockedAdvertService.Setup(a => a.GetById(It.IsAny<int?>())).Returns(nullAdvert);

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act & Assert
            advertController
                .WithCallTo(c => c.Detail(1))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }
    }
}
