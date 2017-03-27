using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture.Contracts;
using CarSystem.Web.Models.Advert;

namespace CarSystem.Web.Controllers.Tests.AdvertControllerTests
{
    [TestFixture]
    public class CreatePostShould
    {
        [Test]
        public void CreatePost_Should_RedirectToDefaultViewWithCorrectParameterModel_WhenThereIsExceptionOnCreatingInDatabase()
        {
            // Arrange
            var mockedContext = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dedoviqt@gmail.com");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            mockedContext.Setup(s => s.User).Returns(principal);

            var model = new AdvertCreateViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();

            mockedAdvertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>())).Throws(new Exception());

            var advertController = new AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            advertController.ControllerContext = new ControllerContext(mockedContext.Object, new RouteData(), advertController);

            // Act & Assert
            advertController
                .WithCallTo(c => c.Create(model, uploadedFiles))
                .ShouldRenderDefaultView()
                .WithModel<AdvertCreateViewModel>(x =>
                {
                    Assert.IsNull(x.Title);
                    Assert.AreEqual(x.VehicleModelId, 0);
                    Assert.AreEqual(x.Year, 0);
                    Assert.AreEqual(x.Price, 0);
                    Assert.AreEqual(x.Power, 0);
                    Assert.AreEqual(x.DistanceCoverage, 0);
                    Assert.AreEqual(x.CityId, 0);
                    Assert.IsNull(x.Description);
                });
        }

        [Test]
        public void CreatePost_Should_SetTempData_NotificationsWithCorrectMessage_WhenThereIsAnExceptionOnCreatingInDatabase()
        {
            // Arrange
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dedoviqt@gmail.com");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);

            var model = new AdvertCreateViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();

            mockedAdvertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>())).Throws(new Exception());

            var advertController = new AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act
            advertController.Create(model, uploadedFiles);

            // Assert
            Assert.AreEqual(advertController.TempData["Notification"], "Exception.");
        }

        [Test]
        public void Create_Post_Should_ThrowArgumentNullException_WhenModelParameterIsNull()
        {
            // Arrange
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dedoviqt@gmail.com");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);

            AdvertCreateViewModel model = null;
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();

            mockedAdvertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var advertController = new AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => advertController.Create(model, uploadedFiles));
        }

        [Test]
        public void CreatePost_Should_ReturnDefaultViewWithAdvertCreateViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var model = new AdvertCreateViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();

            var advertController = new AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            advertController.ModelState.AddModelError("Yolo", "Yolo");

            // Act & Assert
            advertController
                .WithCallTo(x => x.Create(model, uploadedFiles))
                .ShouldRenderDefaultView()
                .WithModel<AdvertCreateViewModel>(x =>
                {
                    Assert.IsNull(x.Title);
                    Assert.AreEqual(x.VehicleModelId, 0);
                    Assert.AreEqual(x.Year, 0);
                    Assert.AreEqual(x.Price, 0);
                    Assert.AreEqual(x.Power, 0);
                    Assert.AreEqual(x.DistanceCoverage, 0);
                    Assert.AreEqual(x.CityId, 0);
                    Assert.IsNull(x.Description);
                }
            );
        }

        [Test]
        public void CreatePost_Should_InvokeAdvertServiceMethod_CreateAdvert_Once_WhenModelStateIsValid()
        {
            // Arrange
            var context = new Mock<HttpContextBase>();
            var identity = new GenericIdentity("dedoviqt@gmail.com");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));
            var principal = new GenericPrincipal(identity, new[] { "user" });
            context.Setup(s => s.User).Returns(principal);

            var model = new AdvertCreateViewModel();
            IEnumerable<HttpPostedFileBase> uploadedFiles = null;

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();

            mockedAdvertService.Setup(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()));

            var advertController = new AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            advertController.ControllerContext = new ControllerContext(context.Object, new RouteData(), advertController);

            // Act
            advertController.Create(model, uploadedFiles);

            // Assert
            mockedAdvertService.Verify(a => a.CreateAdvert(It.IsAny<Advert>(), It.IsAny<IEnumerable<HttpPostedFileBase>>()), Times.Once);
        }
    }
}
