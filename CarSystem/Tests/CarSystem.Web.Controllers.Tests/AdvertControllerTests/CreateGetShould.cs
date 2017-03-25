using Moq;
using TestStack.FluentMVCTesting;
using NUnit.Framework;

using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Controllers.Tests.AdvertControllerTests
{
    [TestFixture]
    public class CreateGetShould
    {
        [Test]
        public void ReturnCorrectActionResult()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act & Assert
            advertController.WithCallTo(x => x.Create()).ShouldRenderDefaultView();

        }
    }
}
