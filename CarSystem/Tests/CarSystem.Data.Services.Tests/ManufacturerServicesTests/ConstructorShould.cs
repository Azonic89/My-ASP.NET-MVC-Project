using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.ManufacturerServicesTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateManufacturerServices_IfParamsAreValid()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);

            // Assert
            Assert.That(manufacturerService, Is.InstanceOf<ManufacturerService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDataProviderIsNull()
        {
            // Arrange & Act
            IEfCarSystemDbSetCocoon<Manufacturer> nullDataProvider = null;

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new ManufacturerService(nullDataProvider));
        }
    }
}
