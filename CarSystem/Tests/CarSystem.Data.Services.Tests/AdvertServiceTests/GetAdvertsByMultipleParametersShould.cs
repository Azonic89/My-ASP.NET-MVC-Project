using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class GetAdvertsByMultipleParametersShould
    {
        [Test]
        public void ReturnCorrectAdverts_WhenCorrectParameters()
        {
            // Arrange
            int vehicleModelId = 1;
            int cityId = 1;
            int minPrice = 1;
            int maxPrice = 4;
            int yearFrom = 1958;
            int yearTo = 3000;

            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            mockedDbSet.Setup(rep => rep.All()).Returns(() => new List<Advert>() {
                new Advert { Id = 1, VehicleModelId = 1, CityId = 1, Price = 2, Year = 2000 },
                new Advert { Id = 2, VehicleModelId = 1, CityId = 1, Price = 2, Year = 2000 },
                new Advert { Id = 3, VehicleModelId = 1, CityId = 1, Price = 2, Year = 2000 },
                new Advert { Id = 4, VehicleModelId = 2, CityId = 1, Price = 2, Year = 2000 }
            }.AsQueryable());

            var result = advertService.GetAdvertsByMultipleParameters(vehicleModelId, cityId, minPrice, maxPrice, yearFrom, yearTo).ToList();

            // Assert
            Assert.AreEqual(3, result.Count);
        }
    }
}
