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
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            advertService.GetAllAdverts();

            // Assert
            mockedDbSet.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllAdverts_Should_NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllAdverts_Should_ReturnIQueryable_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>() { new Advert(), new Advert() };
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<Advert>>(advertService.GetAllAdverts());
        }

        [Test]
        public void GetAllAdverts_Should_ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>() { new Advert(), new Advert() };
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.AreEqual(advertService.GetAllAdverts(), expectedAdvertsResult);
        }

        [Test]
        public void GetAllAdverts_Should_ReturnEmptyCollection_IfThereAreNoAdvertsAdded()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = new List<Advert>();
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.IsEmpty(advertService.GetAllAdverts());
        }

        [Test]
        public void GetAllAdverts_Should_ThrowArgumentNullException_IfPassedAdvertsAreNull()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            IEnumerable<Advert> expectedAdvertsResult = null;
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedAdvertsResult.AsQueryable());

            // Assert
            Assert.Throws<ArgumentNullException>(() => advertService.GetAllAdverts());
        }
    }
}
