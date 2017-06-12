using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;
using CarSystem.Data.Models.Contracts;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void ReturnCorrectResult_WhenParameterIsValid()
        {
            // Arrange 
            var mockedSet = new Mock<DbSet<IAdvert>>();
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();
            var fakeAdvert = new Mock<IAdvert>();
            var validId = 15;

            // Act
            mockedDbContext.Setup(mock => mock.Set<IAdvert>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<int>())).Returns(fakeAdvert.Object);

            // Assert
            Assert.That(mockedDbSet.GetById(validId), Is.Not.Null);
            Assert.AreEqual(mockedDbSet.GetById(validId), fakeAdvert.Object);
        }
    }
}
