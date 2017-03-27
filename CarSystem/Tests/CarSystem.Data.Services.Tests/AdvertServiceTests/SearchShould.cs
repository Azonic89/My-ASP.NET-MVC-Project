using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class SearchShould
    {
        [Test]
        public void Search_Should_ReturnAllAdverts_WhenAllParametersAreNull()
        {
            // Arrange
            var adverts = new List<Advert>()
            {
                new Advert {Id = 1, Title = "Yolo", CityId = 1, Power = 600},
                new Advert {Id = 2, Title = "Yolo", CityId = 5, Power = 1001 }

            }.AsQueryable();

            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();

            mockedDbSet.Setup(m => m.All()).Returns(adverts);

            var mockedAdvertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            var result = mockedAdvertService.Search(null, null, null, null, null, null, null, null, null, null);

            // Assert
            Assert.AreEqual(result, adverts);
            Assert.AreEqual(result.Count(), adverts.Count());
        }

        [Test]
        public void Search_Should_CityParamateForExample_WhenIsValid()
        {
            // Arrange
            var adverts = new List<Advert>()
            {
                new Advert {Id = 1, Title = "Yolo", CityId = 1, Power = 600},
                new Advert {Id = 2, Title = "Yolo", CityId = 2, Power = 1001 },
                new Advert {Id = 2, Title = "Yolo", CityId = 2, Power = 1001 }

            }.AsQueryable();

            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();

            mockedDbSet.Setup(m => m.All()).Returns(adverts);

            var mockedAdvertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            var result = mockedAdvertService.Search(null, 2, null, null, null, null, null, null, null, null);

            // Assert
            Assert.AreEqual(result.ToList()[0], adverts.ToList()[1]);
            Assert.AreEqual(result.ToList()[1], adverts.ToList()[2]);
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
