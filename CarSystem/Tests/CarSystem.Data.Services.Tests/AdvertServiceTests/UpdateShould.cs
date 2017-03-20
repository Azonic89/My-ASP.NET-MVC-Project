using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class UpdateShould
    {
        [Test]
        public void UpdateAdvert_Should_BeCalled_IfAdvertIsValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertToUpdate = new Mock<Advert>();

            // Act
            advertService.UpdateAdvert(advertToUpdate.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.Update(advertToUpdate.Object), Times.Once);
        }

        [Test]
        public void UpdateAdvert_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            Mock<Advert> advertAsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => advertService.UpdateAdvert(advertAsNull.Object));
        }

        [Test]
        public void UpdateAdvert_Should_NotUpdateAdvertThatIsNeverUpdatedInTheFirstPlace()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedDataProvider.Verify(rep => rep.Update(advertThatIsNotAdded.Object), Times.Never);
        }

        [Test]
        public void UpdateAdvert_Should_CallSaveChangesTwoTimes_IfAdvertIsValid()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advert = new Mock<Advert>();
            var secondAdvert = new Mock<Advert>();

            // Act
            advertService.UpdateAdvert(advert.Object);
            advertService.UpdateAdvert(secondAdvert.Object);

            // Assert
            mockedDataProvider.Verify(u => u.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void UpdateAdvert_Should_NotCallSaveChanges_IfAdvertIsNotDelete()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedDataProvider.Verify(u => u.SaveChanges(), Times.Never);
        }
    }
}
