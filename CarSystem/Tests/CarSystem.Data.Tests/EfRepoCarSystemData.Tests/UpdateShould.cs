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
    public class UpdateShould
    {
        [Test]
        public void Update_Should_ThrowNullReferenceException_WhenPassedArgumentIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();
            var mockedSet = new Mock<DbSet<IAdvert>>();

            // Act
            mockedDbContext.Setup(set => set.Set<IAdvert>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);
            IAdvert entity = null;

            // Assert
            Assert.That(() => mockedDbSet.Update(entity),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void Update_Should_NotThrowException_WhenPassedArgumentIsValid()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<IAdvert>>();
            var mockedAdvert = new Mock<IAdvert>();
            mockedSet.SetupAllProperties();
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();

            // Act
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);

            try
            {
                mockedDbSet.Update(mockedAdvert.Object);
            }
            catch (NullReferenceException e)
            {
            }

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}
