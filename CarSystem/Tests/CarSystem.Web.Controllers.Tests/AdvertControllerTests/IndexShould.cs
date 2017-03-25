using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using NUnit.Framework;
using TestStack.FluentMVCTesting;
using Moq;

using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture.Contracts;
using CarSystem.Web.Models.Advert;

namespace CarSystem.Web.Controllers.Tests.AdvertControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void Index_Should_ReturnHttpStatusCode_BadRequest_IfModelParameterIsNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act &Assert
            advertController
                .WithCallTo(x => x.Index(null))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [Test]
        public void Index_Should_SetTempDataNotificationWithCorrectMessage_IfModelStateIsNotValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);
            advertController.ModelState.AddModelError("Yolo", "Yolo");

            // Act 
            advertController.Index(new AdvertSearchViewModel());

            // Assert
            Assert.AreEqual(advertController.TempData["Notification"], "Exception.");
        }

        [Test]
        public void Index_Should_RedirectTo_ControllerHome_MethodIndex_IfModelStateIsNotValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);
            advertController.ModelState.AddModelError("Yolo", "Yolo");

            // Act and Assert
            advertController
                .WithCallTo(x => x.Index(new AdvertSearchViewModel()))
                .ShouldRedirectTo<HomeController>(h => h.Index());
        }

        [Test]
        public void Index_Should_InvokeAdvertServiceMethod_Search_Once_IfModelStateIsValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);
            advertController.Index(new AdvertSearchViewModel());

            // Act & Assert
            mockedAdvertService.Verify(a => a.Search(
                                                    It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                                                    It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>(),
                                                    It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void Index_Should_InvokeAdvertServiceMethod_Search_Never_IfModelStateIsNotValid()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);
            advertController.ModelState.AddModelError("Yolo", "Yolo");

            advertController.Index(new AdvertSearchViewModel());

            // Act and Assert
            mockedAdvertService.Verify(a => a.Search(
                                                    It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                                                    It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>(),
                                                    It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void Index_Should_ReturnDefaultViewWithCorrectModel_IfThereIsNoError()
        {
            // Arrange
            var adverts = new List<Advert>
            {
                new Advert { Id = 1, CityId = 1, Price = 100, Power = 100 }

            }.AsQueryable();

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            mockedAdvertService.Setup(x => x.Search(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(adverts);
            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act & Assert
            advertController
                .WithCallTo(x => x.Index(new AdvertSearchViewModel()))
                .ShouldRedirectTo<HomeController>(typeof(AdvertController).GetMethod("Index"));
        }

        [Test]
        public void Index_Should_SetTempDataNotificationWithCorrectMessage_IfThereIsNoError()
        {
            // Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedAdvertService = new Mock<IAdvertService>();

            mockedAdvertService.Setup(a => a.Search(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception());

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act 
            advertController.Index(new AdvertSearchViewModel());

            // Assert
            Assert.AreEqual(advertController.TempData["Notification"], "Exeption.");
        }

        [Test]
        public void Index_Should_RedirectTo_ControllerHome_MethodIndex_IfThereIsNoError()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();

            mockedAdvertService.Setup(a => a.Search(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<int>(), It.IsAny<decimal>(), It.IsAny<decimal>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception());

            var advertController = new AdvertController(mockedAdvertService.Object, mockedMappingService.Object);

            // Act & Assert
            advertController
                .WithCallTo(x => x.Index(new AdvertSearchViewModel()))
                .ShouldRedirectTo<HomeController>(h => h.Index());
        }
    }
}
