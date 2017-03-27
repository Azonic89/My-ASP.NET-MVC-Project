using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using Moq;
using TestStack.FluentMVCTesting;
using NUnit.Framework;

using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Controllers.Tests.AdvertControllerTests
{
    [TestFixture]
    public class CreateGetShould
    {
        [OneTimeSetUp]
        public void Initialize()
        {
            AutoMapperConfig.Config(Assembly.Load("CarSystem.Web"));
        }

        [Test]
        public void Create_Get_Should_ReturnCorrectActionResult()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();

            var advertController = new AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            // Act & Assert
            advertController.WithCallTo(x => x.Create()).ShouldRenderDefaultView();

        }

        [Test]
        public void CreateGet_Should_ReturnEverythingFromViewBag_WithCorrectValues()
        {
            // Arrange
            var vehicleModels = new List<VehicleModel>()
            {
                new VehicleModel() { Id = 1, Name = "Model X"},
                new VehicleModel() { Id = 1, Name = "100"},
            }.AsQueryable();

            var cities = new List<City>()
            {
                new City() { Id = 1, Name = "Veliko Tarnovo"},
                new City() { Id = 1, Name = "Sofia"},
            }.AsQueryable();

            var mockedVehicleModelDbSet = new Mock<IEfCarSystemDbSetCocoon<VehicleModel>>();
            var mockedCityDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();

            mockedVehicleModelDbSet.Setup(v => v.All()).Returns(vehicleModels);
            mockedCityDbSet.Setup(c => c.All()).Returns(cities);

            var mockedAdvertService = new Mock<IAdvertService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedCityService = new Mock<ICityService>();

            var advertController = new Controllers.AdvertController(
                mockedAdvertService.Object,
                mockedMappingService.Object,
                mockedVehicleModelService.Object,
                mockedCityService.Object);

            // Act 
            advertController.Create();

            // Assert
            Assert.IsNotNull(advertController.ViewBag.VehicleModels as SelectList);
            Assert.IsNotNull(advertController.ViewBag.Cities as SelectList);
        }
    }
}
