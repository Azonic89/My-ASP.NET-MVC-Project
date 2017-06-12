using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;
using CarSystem.Data.Models.Contracts;
using Moq;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class DeleteShould
    {
        [Test]
        public void Delete_Should_ThrowNullReferenceException_WhenPassedArgumentIsNull()
        {
            // Arrange
            var mockedDbContext = new Mock<ICarSystemEfDbContext>();
            var mockedSet = new Mock<DbSet<IAdvert>>();

            // Act
            mockedDbContext.Setup(set => set.Set<IAdvert>()).Returns(mockedSet.Object);
            var mockedDbSet = new EfCarSystemDbSetCocoon<IAdvert>(mockedDbContext.Object);
            IAdvert entity = null;

            // Assert
            Assert.That(() => mockedDbSet.Delete(entity),
                Throws.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void Delete_Should_NotThrowException_WhenPassedArgumentIsValid()
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
                mockedDbSet.Delete(mockedAdvert.Object);
            }
            catch (NullReferenceException e)
            {
            }

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}
