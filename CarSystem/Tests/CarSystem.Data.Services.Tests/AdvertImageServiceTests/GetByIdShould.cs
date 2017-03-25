using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertImageServiceTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void GetById_Should_ReturnNull_IfParameterIdIsNull()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<AdvertImage>>();

            // Act
            var advertImageService = new AdvertImageService(mockedDbSet.Object);
            var result = advertImageService.GetById(null);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetById_Should_ReturnCorrectFile_IfParameterIdIsValid_AndThereIsFileWithIdEqualOfParamId()
        {
            // Arrange
            var expectedFile = new AdvertImage() { Id = 1 };

            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<AdvertImage>>();

            mockedDbSet.Setup(f => f.GetById(It.IsAny<int>())).Returns(expectedFile);

            // Act
            var advertImageService = new AdvertImageService(mockedDbSet.Object);
            var result = advertImageService.GetById(1);

            // Assert
            Assert.AreEqual(result, expectedFile);
        }
    }
}
