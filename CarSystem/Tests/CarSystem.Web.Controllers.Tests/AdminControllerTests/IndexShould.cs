using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Areas.Admin.Controllers;


namespace CarSystem.Web.Controllers.Tests.AdminControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void Index_Should_CallTheDefaultView()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var adminController = new AdminController(mockedAdvertService.Object);

            // Act & Assert
            adminController
                .WithCallTo(a => a.Index())
                .ShouldRenderDefaultView();
        }
    }
}
