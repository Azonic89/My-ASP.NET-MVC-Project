using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class GetAdvertByIdShould
    {
        [Test]
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advert = new Mock<Advert>();

            // Act
            advertService.GetById(advert.Object.Id);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(advert.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperAdvertWithId_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertWithId = new Mock<Advert>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(advertWithId.Object.Id)).Returns(() => advertWithId.Object);

            // Assert
            Assert.IsInstanceOf<Advert>(advertService.GetById(advertWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertWithId = new Mock<Advert>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(advertWithId.Object.Id)).Returns(() => advertWithId.Object);

            // Assert
            Assert.AreEqual(advertService.GetById(advertWithId.Object.Id), advertWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            Mock<Advert> advertThatIsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => advertService.GetById(advertThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnAdvert_IfThereIsNoAdvertYolo()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            Mock<Advert> advertThatIsNull = null;

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(0)).Returns(() => null);

            // Assert
            Assert.IsNull(advertService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectAdvert_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advert = new Mock<Advert>();
            var secondAdvert = new Mock<Advert>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(advert.Object.Id)).Returns(() => advert.Object);

            // Assert
            Assert.AreNotEqual(advertService.GetById(advert.Object.Id), secondAdvert.Object);
        }
    }
}
