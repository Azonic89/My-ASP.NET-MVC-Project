using System.ComponentModel.DataAnnotations;
using System.Linq;

using NUnit.Framework;

namespace CarSystem.Data.Models.Tests.AdvertImageTests
{
    [TestFixture]
    public class AdvertImageTests
    {
        [Test]
        public void Id_Should_HaveTheKeyAttribute()
        {
            // Arrange
            var keyAttributeProperty = typeof(AdvertImage).GetProperty("Id");

            // Act
            var attribute = keyAttributeProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(attribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void Id_Should_SetIdCorrectly(int testId)
        {
            // Arrange & Act
            var advertImage = new AdvertImage { Id = testId };

            // Assert
            Assert.AreEqual(testId, advertImage.Id);
        }

        [TestCase(new byte[] { 0x00, 0x00, 0x00, 0x01 })]
        [TestCase(new byte[] { 0x01, 0x01, 0x00, 0x01 })]
        public void ImageData_Should_SetDataCorreclty(byte[] testByteArray)
        {
            // Arrange & Act
            var advertImage = new AdvertImage { ImageData = testByteArray };

            // Assert
            Assert.AreEqual(testByteArray, advertImage.ImageData);
        }

        [TestCase("Amazing Picture!!!")]
        [TestCase("Best Car Picture!!!")]
        public void ImageName_Should_SetDataCorreclty(string testImageName)
        {
            // Arrange & Act
            var advertImage = new AdvertImage { ImageName = testImageName };

            // Assert
            Assert.AreEqual(testImageName, advertImage.ImageName);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void AdvertImageId_Should_GetAndSetDataCorrectly(int testAdvertImageId)
        {
            // Arrange & Act
            var advertImage = new AdvertImage { AdvertImageId = testAdvertImageId };

            // Assert
            Assert.AreEqual(advertImage.AdvertImageId, testAdvertImageId);
        }

        [TestCase("Audi For Sale")]
        [TestCase("Buggati Veyron Only for Watching!!!")]
        public void Advert_Should_GetAndSetDataCorrectly(string testAdvertName)
        {
            // Arrange & Act         
            var advert = new Advert { Title = testAdvertName };
            var advertImage = new AdvertImage { Advert = advert };

            // Assert
            Assert.AreEqual(advertImage.Advert.Title, testAdvertName);
        }

    }
}
