using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Areas.Admin.Controllers;
using CarSystem.Web.Areas.Admin.Models;

namespace CarSystem.Web.Controllers.Tests.AdminControllerTests
{
    [TestFixture]
    public class DeleteAdvertShould
    {
        [Test]
        public void DeleteAdvert_Should_ThrowNullReferenceException_WhenViewModelIsnull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var adminController = new AdminController(mockedAdvertService.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => adminController.DeleteAdvert(null));
        }

        [Test]
        public void DeleteAdvert_Should_CallDeleteAdvertMethodOnce_WhenViewModelAreNotNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advertViewModel = new AdvertViewModel
            {
                Id = 15,
                Description = "Yoloolol",
                DistanceCoverage = 123321,
                Power = 123,
                Price = 1323,
                Title = "Best",
                Year = 2017
            };

            mockedAdvertService.Setup(a => a.GetById(It.IsAny<int>())).Returns(new Advert());

            var adminController = new AdminController(mockedAdvertService.Object);

            // Act
            adminController.DeleteAdvert(advertViewModel);

            // Assert
            mockedAdvertService.Verify(a => a.DeleteAdvertById(It.IsAny<int>()), Times.Once);
        }
    }
}
