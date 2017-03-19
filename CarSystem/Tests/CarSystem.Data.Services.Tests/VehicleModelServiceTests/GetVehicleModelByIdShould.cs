using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.VehicleModelServiceTests
{
    [TestFixture]
    public class GetVehicleModelByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);
            var vehicleModel = new Mock<VehicleModel>();

            // Act
            vehicleModelService.GetById(vehicleModel.Object.Id);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(vehicleModel.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperVehicleModelWithId_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);
            var vehicleModelWithId = new Mock<VehicleModel>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(vehicleModelWithId.Object.Id)).Returns(() => vehicleModelWithId.Object);

            // Assert
            Assert.IsInstanceOf<VehicleModel>(vehicleModelService.GetById(vehicleModelWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);
            var vehicleModelWithId = new Mock<VehicleModel>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(vehicleModelWithId.Object.Id)).Returns(() => vehicleModelWithId.Object);

            // Assert
            Assert.AreEqual(vehicleModelService.GetById(vehicleModelWithId.Object.Id), vehicleModelWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfVehicleModelIsNull()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);
            Mock<VehicleModel> vehicleModelThatIsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => vehicleModelService.GetById(vehicleModelThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnVehicleModel_IfThereIsNoVehicleModelYolo()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(0)).Returns(() => null);

            // Assert
            Assert.IsNull(vehicleModelService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectVehicleModel_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<VehicleModel>>();
            var vehicleModelService = new VehicleModelService(mockedDataProvider.Object);
            var vehicleModel = new Mock<VehicleModel>();
            var secondVehicleModel = new Mock<VehicleModel>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(vehicleModel.Object.Id)).Returns(() => vehicleModel.Object);

            // Assert
            Assert.AreNotEqual(vehicleModelService.GetById(vehicleModel.Object.Id), secondVehicleModel.Object);
        }
    }
}
