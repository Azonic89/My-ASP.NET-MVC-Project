using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.VehicleModelServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateVehicleModelService_IfParamsAreValid()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Assert
            Assert.That(vehicleModelService, Is.InstanceOf<VehicleModelService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDataProviderIsNull()
        {
            // Arrange & Act
            IEfCarSystemDataProvider<VehicleModel> nullDataProvider = null;

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new VehicleModelService(nullDataProvider));
        }
    }
}
