using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.CityServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateCityServices_IfParamsAreValid()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<City>>();
            var cityService = new CityService(mockedDbSet.Object);

            // Assert
            Assert.That(cityService, Is.InstanceOf<CityService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDataProviderIsNull()
        {
            // Arrange & Act
            IEfCarSystemDbSetCocoon<City> nullDataProvider = null;

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new CityService(nullDataProvider));
        }
    }
}
