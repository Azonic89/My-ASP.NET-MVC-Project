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
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);
            var manufacturer = new Mock<Manufacturer>();

            // Act
            manufacturerService.GetById(manufacturer.Object.Id);

            // Assert
            mockedDbSet.Verify(rep => rep.GetById(manufacturer.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperManufacturerWithId_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);
            var manufacturerWithId = new Mock<Manufacturer>();

            // Act
            mockedDbSet.Setup(rep => rep.GetById(manufacturerWithId.Object.Id)).Returns(() => manufacturerWithId.Object);

            // Assert
            Assert.IsInstanceOf<Manufacturer>(manufacturerService.GetById(manufacturerWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);
            var manufacturerWithId = new Mock<Manufacturer>();

            // Act
            mockedDbSet.Setup(rep => rep.GetById(manufacturerWithId.Object.Id)).Returns(() => manufacturerWithId.Object);

            // Assert
            Assert.AreEqual(manufacturerService.GetById(manufacturerWithId.Object.Id), manufacturerWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfManufacturerIsNull()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);
            Mock<Manufacturer> manufacturerThatIsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => manufacturerService.GetById(manufacturerThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnManufacturer_IfThereIsNoManufacturerYolo()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);

            // Act
            mockedDbSet.Setup(rep => rep.GetById(0)).Returns(() => null);

            // Assert
            Assert.IsNull(manufacturerService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectManufacturer_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDbSet.Object);
            var manufacturer = new Mock<Manufacturer>();
            var secondManufacturer = new Mock<Manufacturer>();

            // Act
            mockedDbSet.Setup(rep => rep.GetById(manufacturer.Object.Id)).Returns(() => manufacturer.Object);

            // Assert
            Assert.AreNotEqual(manufacturerService.GetById(manufacturer.Object.Id), secondManufacturer.Object);
        }
    }
}
