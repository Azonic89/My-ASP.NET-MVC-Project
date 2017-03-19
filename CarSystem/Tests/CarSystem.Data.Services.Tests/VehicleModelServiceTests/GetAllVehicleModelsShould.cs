using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.VehicleModelServiceTests
{
    [TestFixture]
    public class GetAllVehicleModelsShould
    {
        [Test]
        public void GetAllVehicleModels_Should_BeCalled_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Act
            vehicleModelService.GetAllVehicleModels();

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllVehicleModels_Should_NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllVehicleModels_Should_ReturnIQueryable_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Act
            IEnumerable<VehicleModel> expectedVehicleModelsResult = new List<VehicleModel>() { new VehicleModel(), new VehicleModel() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedVehicleModelsResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<VehicleModel>>(vehicleModelService.GetAllVehicleModels());
        }

        [Test]
        public void GetAllVehicleModels_Should_ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Act
            IEnumerable<VehicleModel> expectedVehicleModelsResult = new List<VehicleModel>() { new VehicleModel(), new VehicleModel() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedVehicleModelsResult.AsQueryable());

            // Assert
            Assert.AreEqual(vehicleModelService.GetAllVehicleModels(), expectedVehicleModelsResult);
        }

        [Test]
        public void GetAllVehicleModels_Should_ReturnEmptyCollection_IfThereAreNoVehicleModelsAdded()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Act
            IEnumerable<VehicleModel> expectedVehicleModelsResult = new List<VehicleModel>();
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedVehicleModelsResult.AsQueryable());

            // Assert
            Assert.IsEmpty(vehicleModelService.GetAllVehicleModels());
        }

        [Test]
        public void GetAllVehicleModels_Should_ThrowArgumentNullException_IfPassedVehicleModelsAreNull()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Act
            IEnumerable<VehicleModel> expectedVehicleModelsResult = null;
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedVehicleModelsResult.AsQueryable());

            // Assert
            Assert.Throws<ArgumentNullException>(() => vehicleModelService.GetAllVehicleModels());
        }
    }
}
