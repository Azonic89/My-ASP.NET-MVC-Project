using System;
using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models.Contracts;
using CarSystem.Data.Repositories;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_ThrowArgumentNullException_IfDbContextPassedIsNull()
        {
            // Arrange
            ICarSystemDbContext nullContext = null;

            // Act & Assert
            Assert.That(() => new EfCarSystemDataProvider<IAdvert>(nullContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains(nameof(ICarSystemDbContext)));
        }

        [Test]
        public void Constructor_Should_WorkCorrectly_IfDbContextPassedIsValid()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();

            // Act
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);
            var dataProvider = new EfCarSystemDataProvider<IAdvert>(mockedDbContext.Object);

            // Assert
            Assert.That(dataProvider, Is.Not.Null);
        }

        [Test]
        public void Constructor_Should_SetContextCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<ICarSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();

            // Act
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);
            var dataProvider = new EfCarSystemDataProvider<IAdvert>(mockedContext.Object);

            // Assert
            Assert.That(dataProvider.Context, Is.Not.Null);
            Assert.That(dataProvider.Context, Is.EqualTo(mockedContext.Object));
        }

        [Test]
        public void Constructor_Should_SetDbSetCorrectly_WhenValidArgumentsPassed()
        {
            // Arrange
            var mockedContext = new Mock<ICarSystemDbContext>();
            var mockedModel = new Mock<DbSet<IAdvert>>();

            // Act
            mockedContext.Setup(x => x.Set<IAdvert>()).Returns(mockedModel.Object);
            var repository = new EfCarSystemDataProvider<IAdvert>(mockedContext.Object);

            // Assert
            Assert.That(repository.DbSet, Is.Not.Null);
            Assert.That(repository.DbSet, Is.EqualTo(mockedModel.Object));
        }
    }
}
