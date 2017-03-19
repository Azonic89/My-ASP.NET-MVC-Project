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
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Assert
            Assert.That(cityService, Is.InstanceOf<CityService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDataProviderIsNull()
        {
            // Arrange & Act
            IEfCarSystemDataProvider<City> nullDataProvider = null;

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new CityService(nullDataProvider));
        }
    }
}
