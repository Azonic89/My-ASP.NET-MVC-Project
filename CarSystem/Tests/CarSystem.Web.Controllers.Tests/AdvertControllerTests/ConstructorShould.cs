using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Controllers.Tests.AdvertControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        //[Test]
        //public void Constructor_Should_ThrowArgumentNullException_WhenAdvertServiceIsNull()
        //{
        //    // Arrange
        //    IAdvertService advertService = null;
        //    var mappingService = new Mock<IMappingService>();

        //    // Act and Assert
        //    Assert.Throws<ArgumentNullException>(() => new AdvertController(advertService, mappingService.Object));
        //}

        //[Test]
        //public void Constructor_Should_ThrowArgumentNullException_WhenMappingServiceIsNull()
        //{
        //    // Arrange
        //    var advertService = new Mock<IAdvertService>();
        //    IMappingService mappingService = null;

        //    // Act and Assert
        //    Assert.Throws<ArgumentNullException>(() => new AdvertController(advertService.Object, mappingService));
        //}

        [Test]
        public void Constructor_Should_ThrowArgumentNullException_WhenPassedParametersAreNull()
        {
            // Arrange
            IAdvertService advertService = null;
            IMappingService mappingService = null;
            ICityService cityService = null;
            IVehicleModelService vehicleModelService = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new AdvertController(advertService, mappingService, vehicleModelService, cityService));
        }

        [Test]
        public void CreateInstanceOfAdvertService_WhenAdvertServiceParameterIsNotNull()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();

            // Act
            var advertController = new AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            // Assert
            Assert.That(advertController, Is.Not.Null);
            Assert.IsInstanceOf<AdvertController>(advertController);
        }
    }
}
