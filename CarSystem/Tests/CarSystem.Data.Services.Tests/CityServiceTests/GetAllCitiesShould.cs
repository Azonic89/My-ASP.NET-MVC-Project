using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.CityServiceTests
{
    [TestFixture]
    public class GetAllCitiesShould
    {
        [Test]
        public void GetAllCities_Should_BeCalled_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Act
            cityService.GetAllCities();

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllCities_Should_NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllCities_Should_ReturnIQueryable_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = new List<City>() { new City(), new City() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<City>>(cityService.GetAllCities());
        }

        [Test]
        public void GetAllCities_Should_ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = new List<City>() { new City(), new City() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.AreEqual(cityService.GetAllCities(), expectedCitiesResult);
        }

        [Test]
        public void GetAllCities_Should_ReturnEmptyCollection_IfThereAreNoCategoriesAdded()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = new List<City>();
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.IsEmpty(cityService.GetAllCities());
        }

        [Test]
        public void GetAllCities_Should_ThrowArgumentNullException_IfPassedCategoriesAreNull()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = null;
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.Throws<ArgumentNullException>(() => cityService.GetAllCities());
        }
    }
}
