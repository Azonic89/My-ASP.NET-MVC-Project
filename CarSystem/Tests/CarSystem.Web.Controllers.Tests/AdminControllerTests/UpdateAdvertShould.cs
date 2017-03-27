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
    public class UpdateAdvertShould
    {
        [Test]
        public void Update_Advert_Should_ThrowNullReferenceException_WhenViewModelIsnull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var adminController = new AdminController(mockedAdvertService.Object);

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => adminController.UpdateAdvert(null));
        }

        [Test]
        public void Update_Advert_Should_CallUpdateAdvertMethodOnce_WhenViewModelAreNotNull()
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
            adminController.UpdateAdvert(advertViewModel);

            // Assert
            mockedAdvertService.Verify(a => a.UpdateAdvert(It.IsAny<Advert>()), Times.Once);
        }

        [Test]
        public void Updates_Advert_Should_CallUpdateMethodOnce_WhenViewModelAreNotNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advert = new Advert
            {
                Id = 15,
                Description = "Yoloolol",
                DistanceCoverage = 123321,
                Power = 123,
                Price = 1323,
                Title = "Best",
                Year = 2017
            };

            var advertViewModel = new AdvertViewModel();
            mockedAdvertService.Setup(a => a.GetById(It.IsAny<int>())).Returns(advert);

            var adminController = new AdminController(mockedAdvertService.Object);

            // Act
            adminController.UpdateAdvert(advertViewModel);

            // Assert
            Assert.AreEqual(advertViewModel.Description, advert.Description);
            Assert.AreEqual(advertViewModel.DistanceCoverage, advert.DistanceCoverage);
            Assert.AreEqual(advertViewModel.Power, advert.Power);
            Assert.AreEqual(advertViewModel.Price, advert.Price);
            Assert.AreEqual(advertViewModel.Title, advert.Title);
            Assert.AreEqual(advertViewModel.Year, advert.Year);
        }
    }
}
