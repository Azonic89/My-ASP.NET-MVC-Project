using System;
using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;
using CarSystem.Data.Models.Contracts;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_ThrowArgumentNullException_IfDbContextPassedIsNull()
        {
            // Arrange
            ICarSystemEfDbContext nullContext = null;

            // Act & Assert
            Assert.That(() => new EfCarSystemDbSetCocoon<IAdvert>(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ICarSystemEfDbContext)));
        }

        [Test]
        public void Constructor_Should_WorkCorrectly_IfDbContextPassedIsValid()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();

            // Act
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);

            // Assert
            Assert.That(mockedDbSet, Is.Not.Null);
        }

        [Test]
        public void Constructor_Should_SetContextCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<ICarSystemEfDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();

            // Act
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedContext.Object);

            // Assert
            Assert.That(mockedDbSet.Context, Is.Not.Null);
            Assert.That(mockedDbSet.Context, Is.EqualTo(mockedContext.Object));
        }

        [Test]
        public void Constructor_Should_SetDbSetCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<ICarSystemEfDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();

            // Act
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);
            var repository = new EfCarSystemDbSetCocoon<IAdvert>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }
    }
}
