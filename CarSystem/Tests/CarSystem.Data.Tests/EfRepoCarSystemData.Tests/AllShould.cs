using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;
using CarSystem.Data.Models.Contracts;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class AllShould
    {
        [Test]
        public void All_Should_ReturnEntitiesOfGivenSet()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();
            var mockedSet = new Mock<DbSet<IAdvert>>();

            // Act
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);

            // Assert
            Assert.NotNull(mockedDbSet.All());
            Assert.IsInstanceOf(typeof(DbSet<IAdvert>), mockedDbSet.All());
            Assert.AreSame(mockedDbSet.All(), mockedDbSet.DbSet);
        }
    }
}
