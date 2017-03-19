using System;
using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.CityServiceTests
{
    [TestFixture]
    public class GetCityByIdShould
    {
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);
            var city = new Mock<Category>();

            // Act
            cityService.GetById(city.Object.Id);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(city.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperCityWithId_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);
            var cityWithId = new Mock<City>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(cityWithId.Object.Id)).Returns(() => cityWithId.Object);

            // Assert
            Assert.IsInstanceOf<City>(cityService.GetById(cityWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);
            var cityWithId = new Mock<City>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(cityWithId.Object.Id)).Returns(() => cityWithId.Object);

            // Assert
            Assert.AreEqual(cityService.GetById(cityWithId.Object.Id), cityWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfCityIsNull()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);
            Mock<City> cityThatIsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => cityService.GetById(cityThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnCategory_IfThereIsNoCityYolo()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);
            Mock<City> cityThatIsNull = null;

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(0)).Returns(() => null);

            // Assert
            Assert.IsNull(cityService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectCity_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<City>>();
            var cityService = new CityService(mockedDataProvider.Object);
            var city = new Mock<City>();
            var secondCity = new Mock<City>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(city.Object.Id)).Returns(() => city.Object);

            // Assert
            Assert.AreNotEqual(cityService.GetById(city.Object.Id), secondCity.Object);
        }
    }
}
