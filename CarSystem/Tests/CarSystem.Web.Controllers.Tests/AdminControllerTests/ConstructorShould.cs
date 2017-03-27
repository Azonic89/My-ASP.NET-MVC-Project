using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Areas.Admin.Controllers;

namespace CarSystem.Web.Controllers.Tests.AdminControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_ThrowArgumentNullException_WhenAdvertServiceIsNull()
        {
            // Arrange
            IAdvertService mockedNullAdvertService = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AdminController(mockedNullAdvertService));
        }

        [Test]
        public void Constructor_Should_CreateAdminController_WhenAdvertServiceIsNotNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var adminController = new AdminController(mockedAdvertService.Object);
            // Act & Assert
            Assert.That(adminController, Is.Not.Null);
            Assert.IsInstanceOf<AdminController>(adminController);
        }
    }
}
