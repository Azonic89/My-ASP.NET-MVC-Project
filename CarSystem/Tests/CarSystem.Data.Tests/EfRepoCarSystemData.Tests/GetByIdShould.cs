using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models.Contracts;
using CarSystem.Data.Repositories;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void ReturnCorrectResult_WhenParameterIsValid()
        {
            // Arrange 
            var mockedDbSet = new Mock<DbSet<IAdvert>>();
            var mockedDbContext = new Mock<ICarSystemDbContext>();
            var fakeAdvert = new Mock<IAdvert>();
            var validId = 15;

            // Act
            mockedDbContext.Setup(mock => mock.Set<IAdvert>()).Returns(mockedDbSet.Object);
            var dataProvider = new EfCarSystemDataProvider<IAdvert>(mockedDbContext.Object);
            mockedDbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(fakeAdvert.Object);

            // Assert
            Assert.That(dataProvider.GetById(validId), Is.Not.Null);
            Assert.AreEqual(dataProvider.GetById(validId), fakeAdvert.Object);
        }
    }
}
