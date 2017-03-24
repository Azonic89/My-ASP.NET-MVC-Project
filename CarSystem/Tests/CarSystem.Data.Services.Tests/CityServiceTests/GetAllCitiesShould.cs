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
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();
            var cityService = new CityService(mockedDbSet.Object);

            // Act
            cityService.GetAllCities();

            // Assert
            mockedDbSet.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllCities_Should_NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();
            var cityService = new CityService(mockedDbSet.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllCities_Should_ReturnIQueryable_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();
            var cityService = new CityService(mockedDbSet.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = new List<City>() { new City(), new City() };
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<City>>(cityService.GetAllCities());
        }

        [Test]
        public void GetAllCities_Should_ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();
            var cityService = new CityService(mockedDbSet.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = new List<City>() { new City(), new City() };
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.AreEqual(cityService.GetAllCities(), expectedCitiesResult);
        }

        [Test]
        public void GetAllCities_Should_ReturnEmptyCollection_IfThereAreNoCategoriesAdded()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();
            var cityService = new CityService(mockedDbSet.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = new List<City>();
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.IsEmpty(cityService.GetAllCities());
        }

        [Test]
        public void GetAllCities_Should_ThrowArgumentNullException_IfPassedCategoriesAreNull()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();
            var cityService = new CityService(mockedDbSet.Object);

            // Act
            IEnumerable<City> expectedCitiesResult = null;
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCitiesResult.AsQueryable());

            // Assert
            Assert.Throws<ArgumentNullException>(() => cityService.GetAllCities());
        }
    }
}
