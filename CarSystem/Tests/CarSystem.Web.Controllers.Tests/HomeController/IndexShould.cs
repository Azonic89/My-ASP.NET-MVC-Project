using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Models;
using CarSystem.Data.Contracts;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture;
using TestStack.FluentMVCTesting;

namespace CarSystem.Web.Controllers.Tests.HomeController
{
    [TestFixture]
    public class IndexShould
    {
        [OneTimeSetUp]
        public void Initial()
        {
            AutoMapperConfig.Config(Assembly.Load("CarSystem.Web"));
        }

        [Test]
        public void Index_Should_ReturnEverythingFromViewBag_WithCorrectValues()
        {
            // Arrange
            var categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Car"},
                new Category() { Id = 1, Name = "Bus"},
            }.AsQueryable();

            var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer() { Id = 1, Name = "Audi"},
                new Manufacturer() { Id = 1, Name = "BMV"},
            }.AsQueryable();

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

            var mockedCategoryDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var mockedManufacturersDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var mockedVehicleModelDbSet = new Mock<IEfCarSystemDbSetCocoon<VehicleModel>>();
            var mockedCityDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();

            mockedCategoryDbSet.Setup(c => c.All()).Returns(categories);
            mockedManufacturersDbSet.Setup(m => m.All()).Returns(manufacturers);
            mockedVehicleModelDbSet.Setup(v => v.All()).Returns(vehicleModels);
            mockedCityDbSet.Setup(c => c.All()).Returns(cities);

            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedVehicleModelService = new Mock<IVehicleModelService>();
            var mockedManufacturerService = new Mock<IManufacturerService>();
            var mockedCityService = new Mock<ICityService>();

            var homeController = new Controllers.HomeController(
                mockedCategoryService.Object,
                mockedVehicleModelService.Object,
                mockedManufacturerService.Object,
                mockedCityService.Object);

            // Act 
            homeController.Index();

            // Assert
            Assert.IsNotNull(homeController.ViewBag.Categories as SelectList);
            Assert.IsNotNull(homeController.ViewBag.Manufacturers as SelectList);
            Assert.IsNotNull(homeController.ViewBag.VehicleModels as SelectList);
            Assert.IsNotNull(homeController.ViewBag.Cities as SelectList);
            Assert.IsNotNull(homeController.ViewBag.Years as SelectList);
        }
    }
}
