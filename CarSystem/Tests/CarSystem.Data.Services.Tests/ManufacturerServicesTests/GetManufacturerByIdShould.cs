using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.ManufacturerServicesTests
{
    [TestFixture]
    public class GetManufacturerByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);
            var manufacturer = new Mock<Manufacturer>();

            // Act
            manufacturerService.GetById(manufacturer.Object.Id);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(manufacturer.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperManufacturerWithId_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);
            var manufacturerWithId = new Mock<Manufacturer>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(manufacturerWithId.Object.Id)).Returns(() => manufacturerWithId.Object);

            // Assert
            Assert.IsInstanceOf<Manufacturer>(manufacturerService.GetById(manufacturerWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);
            var manufacturerWithId = new Mock<Manufacturer>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(manufacturerWithId.Object.Id)).Returns(() => manufacturerWithId.Object);

            // Assert
            Assert.AreEqual(manufacturerService.GetById(manufacturerWithId.Object.Id), manufacturerWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfManufacturerIsNull()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);
            Mock<Manufacturer> manufacturerThatIsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => manufacturerService.GetById(manufacturerThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnManufacturer_IfThereIsNoManufacturerYolo()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(0)).Returns(() => null);

            // Assert
            Assert.IsNull(manufacturerService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectManufacturer_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);
            var manufacturer = new Mock<Manufacturer>();
            var secondManufacturer = new Mock<Manufacturer>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(manufacturer.Object.Id)).Returns(() => manufacturer.Object);

            // Assert
            Assert.AreNotEqual(manufacturerService.GetById(manufacturer.Object.Id), secondManufacturer.Object);
        }
    }
}
