using System.Collections.Generic;
using System.Web;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class AddUploadedFilesToAdvertShould
    {
        [Test]
        public void AddUploadedFilesToAdvert_Should_ThrowArgumentNullExeption_IfAdvertParameterIsNull()
        {
            // Arrange
            Advert advert = null;
            IEnumerable<HttpPostedFileBase> files = null;

            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Act and Assert
            Assert.That(() => advertService.AddUploadedFilesToAdvert(advert, files),
                Throws.ArgumentNullException);
        }
    }
}
