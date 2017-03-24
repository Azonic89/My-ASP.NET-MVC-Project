using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

using NUnit.Framework;
using Moq;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class AddAdvertShould
    {
        [Test]
        public void AddAdvert_Should_BeCalledOnce_IfAdvertIsValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var mockedAdvert = new Mock<Advert>();

            // Act
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            advertService.AddAdvert(mockedAdvert.Object);

            // Assert
            mockedDbSet.Verify(ser => ser.Add(mockedAdvert.Object), Times.Once);
        }

        [Test]
        public void AddAdvert_Should_CallSaveChangesOnce_IfAdvertIsValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var mockedAdvert = new Mock<Advert>();

            // Act
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            advertService.AddAdvert(mockedAdvert.Object);

            // Assert
            mockedSaveChanges.Verify(ser => ser.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddAdvert_Should_ThrowAgrumentNullException_IfAdvertIsNull()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            Advert nullAdvert = null;

            // Act
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Assert
            Assert.That(() => advertService.AddAdvert(nullAdvert), Throws.ArgumentNullException);
        }
    }
}

