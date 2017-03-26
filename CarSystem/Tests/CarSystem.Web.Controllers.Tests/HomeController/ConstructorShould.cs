using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Services.Contracts;

namespace CarSystem.Web.Controllers.Tests.HomeController
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Construct_Should_ThrowArumentNullException_WhenAllDependeciesAreNull()
        {
            // Arrange
            ICategoryService mockedCategoryService = null;
            IVehicleModelService mockedVehicleModelService = null;
            IManufacturerService mockedManufacturerService = null;
            ICityService mockedCityService = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Controllers.HomeController(
                mockedCategoryService,
                mockedVehicleModelService,
                mockedManufacturerService,
                mockedCityService));
        }

        [Test]
        public void Construct_Should_CreateHomeControllerInstance_WhenAllDependeciesAreValid()
        {
            // Arrange
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();
            var mockedManufacturerService = new Mock<IManufacturerService>();
            var mockedCityService = new Mock<ICityService>();

            var homeController = new Controllers.HomeController(
                mockedCategoryService.Object,
                mockedVehicleModelService.Object,
                mockedManufacturerService.Object,
                mockedCityService.Object);

            // Act & Assert
            Assert.That(homeController, Is.Not.Null);
            Assert.IsInstanceOf<Controllers.HomeController>(homeController);
        }
    }
}
