using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Serialization;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models.Contracts;
using CarSystem.Data.Repositories;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class AddShould
    {
        [Test]
        public void Add_Should_ThrowNullReferenceException_WhenPassedArgumentIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();
            var mockedSet = new Mock<DbSet<IAdvert>>();

            // Act
            mockedDbContext.Setup(set => set.Set<IAdvert>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);
            IAdvert entity = null;

            // Assert
            Assert.That(() => mockedDbSet.Add(entity),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void Add_Should_NotThrowException_WhenPassedArgumentIsValid()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<IAdvert>>();
            var mockedAdvert = new Mock<IAdvert>();
            mockedSet.SetupAllProperties();
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();
            var fakeEntry = (DbEntityEntry<IAdvert>)FormatterServices.GetSafeUninitializedObject(typeof(DbEntityEntry<IAdvert>));

            // Act
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedSet.Object);
            mockedDbContext.Setup(x => x.Entry(It.IsAny<IAdvert>())).Returns(fakeEntry);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);

            try
            {
                mockedDbSet.Add(mockedAdvert.Object);
            }
            catch (NullReferenceException e)
            {
            }

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}
