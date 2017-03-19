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
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertToAddAndDelete = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advertToAddAndDelete.Object);
            advertService.DeleteAdvert(advertToAddAndDelete.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.Delete(advertToAddAndDelete.Object), Times.Once);
        }

        [Test]
        public void DeleteAdvert_ShouldThrowNullReferenceException_IfAdvertIsNull()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            Mock<Advert> advertAsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => advertService.DeleteAdvert(advertAsNull.Object));
        }

        [Test]
        public void DeleteAdvert_Should_NotDeleteAdvertThatIsNeverAddedInTheFirstPlace()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedDataProvider.Verify(rep => rep.Delete(advertThatIsNotAdded.Object), Times.Never);
        }

        [Test]
        public void DeleteAdvert_Should_CallSaveChangesTwoTimes_IfAdvertIsValid()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advert = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advert.Object);
            advertService.DeleteAdvert(advert.Object);

            // Assert
            mockedDataProvider.Verify(u => u.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void DeleteAdvert_Should_NotCallSaveChanges_IfAdvertIsNotDelete()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advertThatIsNotAdded = new Mock<Advert>();

            // Assert
            mockedDataProvider.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Test]
        public void DeleteAdvert_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);
            var advert = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advert.Object);
            advertService.DeleteAdvert(advert.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.Delete(It.IsAny<Advert>()), Times.Once);
        }
    }
}
