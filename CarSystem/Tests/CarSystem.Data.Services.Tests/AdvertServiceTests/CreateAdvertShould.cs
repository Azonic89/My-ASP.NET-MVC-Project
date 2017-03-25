using System.Collections.Generic;
using System.Web;

using Moq;
using NUnit.Framework;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class CreateAdvertShould
    {
        [Test]
        public void CreateAdvert_Should_ThrowArgumentNullExeption_IfAdvertParameterIsNull()
        {
            // Arrange
            Advert advert = null;
            IEnumerable<HttpPostedFileBase> nullImages = null;
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act and Assert
            Assert.That(() => advertService.AddUploadedFilesToAdvert(advert, nullImages),
                Throws.ArgumentNullException);
        }

        [Test]
        public void CreateAdvert_Should_InvokeSaveChanges_Once_IfAdvertParameterIsNotNull()
        {
            // Arrange
            Advert advert = new Advert { Id = 1 };
            IEnumerable<HttpPostedFileBase> files = null;

            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();

            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act
            advertService.CreateAdvert(advert, files);

            // Assert
            mockedSaveChanges.Verify(p => p.SaveChanges(), Times.Once);
        }
    }
}
