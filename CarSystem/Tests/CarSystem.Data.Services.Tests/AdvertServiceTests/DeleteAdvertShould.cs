using System;

using Moq;
using NUnit.Framework;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class DeleteAdvertShould
    {
        [Test]
        public void DeleteAdvert_Should_BeCalled_IfAdvertIsValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertToAddAndDelete = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advertToAddAndDelete.Object);
            advertService.DeleteAdvert(advertToAddAndDelete.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.Delete(advertToAddAndDelete.Object), Times.Once);
        }

        [Test]
        public void DeleteAdvert_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            Mock<Advert> advertAsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => advertService.DeleteAdvert(advertAsNull.Object));
        }

        [Test]
        public void DeleteAdvert_Should_NotDeleteAdvertThatIsNeverAddedInTheFirstPlace()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedDbSet.Verify(rep => rep.Delete(advertThatIsNotAdded.Object), Times.Never);
        }

        [Test]
        public void DeleteAdvert_Should_CallSaveChangesTwoTimes_IfAdvertIsValid()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advert = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advert.Object);
            advertService.DeleteAdvert(advert.Object);

            // Assert
            mockedSaveChanges.Verify(u => u.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void DeleteAdvert_Should_NotCallSaveChanges_IfAdvertIsNotDelete()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedSaveChanges.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Test]
        public void DeleteAdvert_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advert = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advert.Object);
            advertService.DeleteAdvert(advert.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.Delete(It.IsAny<Advert>()), Times.Once);
        }
    }
}
