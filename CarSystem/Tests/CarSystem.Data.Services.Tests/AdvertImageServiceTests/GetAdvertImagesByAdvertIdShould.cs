using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertImageServiceTests
{
    [TestFixture]
    public class GetAdvertImagesByAdvertIdShould
    {
        [Test]
        public void GetAdvertImagesByAdvertIdShould_ReturnCorrectAdvertImagesCount_WhenValidAdvertIdParameterIsPassed()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<AdvertImage>>();
            var pictureService = new AdvertImageService(mockedDataProvider.Object);
            int testAdvertId = 1;
            int expectedResult = 2;

            mockedDataProvider.Setup(rep => rep.All()).Returns(() => new List<AdvertImage>() {
                new AdvertImage() { Id = 1, ImageName = "1.jpg", AdvertImageId = 1 },
                new AdvertImage() { Id = 2, ImageName = "2.jpg", AdvertImageId = 2},
                new AdvertImage() { Id = 3, ImageName = "3.jpg", AdvertImageId = 1 },
                new AdvertImage() { Id = 4, ImageName = "4.jpg", AdvertImageId = 3}
            }.AsQueryable());

            // Act
            var result = pictureService.GetAdvertImagesByAdvertId(testAdvertId);

            // Assert
            Assert.AreEqual(expectedResult, result.ToList().Count);
        }
    }
}
