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
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var mockedAdvert = new Mock<Advert>();

            // Act
            var advertService = new AdvertService(mockedDataProvider.Object);
            advertService.AddAdvert(mockedAdvert.Object);

            // Assert
            mockedDataProvider.Verify(ser => ser.Add(mockedAdvert.Object), Times.Once);
        }

        [Test]
        public void AddAdvert_Should_CallSaveChangesOnce_IfAdvertIsValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var mockedAdvert = new Mock<Advert>();

            // Act
            var advertService = new AdvertService(mockedDataProvider.Object);
            advertService.AddAdvert(mockedAdvert.Object);

            // Assert
            mockedDataProvider.Verify(ser => ser.SaveChanges(), Times.Once);
        }

        [Test]
        public void AddAdvert_Should_ThrowAgrumentNullException_IfAdvertIsNull()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            Advert nullAdvert = null;

            // Act
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Assert
            Assert.That(() => advertService.AddAdvert(nullAdvert), Throws.ArgumentNullException);
        }
    }
}
