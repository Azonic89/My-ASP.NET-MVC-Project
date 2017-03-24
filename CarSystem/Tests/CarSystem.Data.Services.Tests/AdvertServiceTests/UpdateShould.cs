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
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertToUpdate = new Mock<Advert>();

            // Act
            advertService.UpdateAdvert(advertToUpdate.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.Update(advertToUpdate.Object), Times.Once);
        }

        [Test]
        public void UpdateAdvert_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            Mock<Advert> advertAsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => advertService.UpdateAdvert(advertAsNull.Object));
        }

        [Test]
        public void UpdateAdvert_Should_NotUpdateAdvertThatIsNeverUpdatedInTheFirstPlace()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedDbSet.Verify(rep => rep.Update(advertThatIsNotAdded.Object), Times.Never);
        }

        [Test]
        public void UpdateAdvert_Should_CallSaveChangesTwoTimes_IfAdvertIsValid()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advert = new Mock<Advert>();
            var secondAdvert = new Mock<Advert>();

            // Act
            advertService.UpdateAdvert(advert.Object);
            advertService.UpdateAdvert(secondAdvert.Object);

            // Assert
            mockedSaveChanges.Verify(u => u.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void UpdateAdvert_Should_NotCallSaveChanges_IfAdvertIsNotDelete()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedSaveChanges.Verify(u => u.SaveChanges(), Times.Never);
        }
    }
}
