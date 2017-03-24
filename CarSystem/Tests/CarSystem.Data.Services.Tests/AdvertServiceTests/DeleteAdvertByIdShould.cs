using System;

using Moq;
using NUnit.Framework;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class DeleteAdvertByIdShould
    {
        [Test]
        public void DeleteAdvertById_Should_BeCalled_IfAdvertWithIdToDeleteIsValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertToDeleteWithId = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advertToDeleteWithId.Object);
            advertService.DeleteAdvertById(advertToDeleteWithId.Object.Id);

            // Assert
            mockedDbSet.Verify(rep => rep.Delete(advertToDeleteWithId.Object.Id));
        }

        [Test]
        public void DeleteAdvertById_Should_BeCalledOnce_IfAdvertWithIdToDeleteIsValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertToDeleteWithId = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advertToDeleteWithId.Object);
            advertService.DeleteAdvertById(advertToDeleteWithId.Object.Id);

            // Assert
            mockedDbSet.Verify(rep => rep.Delete(advertToDeleteWithId.Object.Id), Times.Once);
        }

        [Test]
        public void DeleteAdvertById_Should_NotDeleteAdvertWithId_IfItIsNotAddedInTheFirstPlace()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertToDeleteWithId = new Mock<Advert>();

            // Assert
            mockedDbSet.Verify(rep => rep.Delete(advertToDeleteWithId.Object.Id), Times.Never);
        }

        [Test]
        public void DeleteAdvertById_Should_CallSaveChangesTwoTimes_IfParamsAreValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            var advertWithId = new Mock<Advert>();

            // Act
            advertService.AddAdvert(advertWithId.Object);
            advertService.DeleteAdvertById(advertWithId.Object.Id);

            // Assert
            mockedSaveChanges.Verify(u => u.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void DeleteAdvertById_Should_ThrowNullReferenceException_IfAdvertWithIdIsNull()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);
            Mock<Advert> advertWithId = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => advertService.DeleteAdvertById(advertWithId.Object.Id));
        }
    }
}
