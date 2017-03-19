using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class GetAllAdvertsShould
    {
        [Test]
        public void GetAllAdverts_Should_BeCalled_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Act
            advertService.GetAllAdverts();

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllAdverts_Should_NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllAdverts_Should_ReturnIQueryable_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>() { new Advert(), new Advert() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<Advert>>(advertService.GetAllAdverts());
        }

        [Test]
        public void GetAllAdverts_Should_ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>() { new Advert(), new Advert() };
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.AreEqual(advertService.GetAllAdverts(), expectedAdvertsResult);
        }

        [Test]
        public void GetAllAdverts_Should_ReturnEmptyCollection_IfThereAreNoAdvertsAdded()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>();
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.IsEmpty(advertService.GetAllAdverts());
        }

        [Test]
        public void GetAllAdverts_Should_ThrowArgumentNullException_IfPassedAdvertsAreNull()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = null;
            mockedDataProvider.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.Throws<ArgumentNullException>(() => advertService.GetAllAdverts());
        }
    }
}
