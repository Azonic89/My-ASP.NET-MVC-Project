using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class GetAllAdvertsByUserIdShould
    {
        [Test]
        public void GetAllAdvertsByUserIdShould_ShouldReturn_CorrectAdvertsAccordingToUserIdAsQueryable()
        {
            // Arrange
            string userId = "asdasdasd";
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            mockedDbSet.Setup(rep => rep.All()).Returns(() => new List<Advert>() {
                new Advert { Id = 1, UserId = userId },
                new Advert { Id = 2, UserId = userId },
                new Advert { Id = 3, UserId = userId },
                new Advert { Id = 4, UserId = userId }
            }.AsQueryable());

            // Act
            var result = advertService.GetAllAdvertsByUserId(userId).ToList();

            // Assert
            Assert.AreEqual(4, result.Count);
        }
    }
}
