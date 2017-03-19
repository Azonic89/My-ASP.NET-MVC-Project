using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models.Contracts;
using CarSystem.Data.Repositories;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class AllShould
    {
        [Test]
        public void All_Should_ReturnEntitiesOfGivenSet()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarSystemDbContext>();
            var mockedSet = new Mock<DbSet<IAdvert>>();

            // Act
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedSet.Object);
            var dataProvider = new EfCarSystemDataProvider<IAdvert>(mockedDbContext.Object);

            // Assert
            Assert.NotNull(dataProvider.All());
            Assert.IsInstanceOf(typeof(DbSet<IAdvert>), dataProvider.All());
            Assert.AreSame(dataProvider.All(), dataProvider.DbSet);
        }
    }
}
