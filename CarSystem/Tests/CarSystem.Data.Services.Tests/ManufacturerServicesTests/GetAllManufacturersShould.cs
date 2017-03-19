using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.ManufacturerServicesTests
{
    [TestFixture]
    public class GetAllManufacturersShould
    {
        [Test]
        public void GetAllManufacturers_Should_BeCalled_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Act
            manufacturerService.GetAllManufacturers();

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllManufacturers_Should_NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllManufacturers_Should_ReturnIQueryable_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Act
            IEnumerable<Manufacturer> expectedManufacturersResult = new List<Manufacturer>() { new Manufacturer(), new Manufacturer() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedManufacturersResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<Manufacturer>>(manufacturerService.GetAllManufacturers());
        }

        [Test]
        public void GetAllManufacturers_Should_ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Act
            IEnumerable<Manufacturer> expectedManufacturersResult = new List<Manufacturer>() { new Manufacturer(), new Manufacturer() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedManufacturersResult.AsQueryable());

            // Assert
            Assert.AreEqual(manufacturerService.GetAllManufacturers(), expectedManufacturersResult);
        }

        [Test]
        public void GetAllManufacturers_Should_ReturnEmptyCollection_IfThereAreNoManufacturersAdded()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Act
            IEnumerable<Manufacturer> expectedManufacturersResult = new List<Manufacturer>();
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedManufacturersResult.AsQueryable());

            // Assert
            Assert.IsEmpty(manufacturerService.GetAllManufacturers());
        }

        [Test]
        public void GetAllManufacturers_Should_ThrowArgumentNullException_IfPassedManufacturersAreNull()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Manufacturer>>();
            var manufacturerService = new ManufacturerService(mockedDataProvider.Object);

            // Act
            IEnumerable<Manufacturer> expectedManufacturersResult = null;
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedManufacturersResult.AsQueryable());

            // Assert
            Assert.Throws<ArgumentNullException>(() => manufacturerService.GetAllManufacturers());
        }
    }
}
