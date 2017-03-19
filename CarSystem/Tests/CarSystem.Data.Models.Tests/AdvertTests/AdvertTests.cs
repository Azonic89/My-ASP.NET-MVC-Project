using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using NUnit.Framework;

using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models.Tests.AdvertTests
{
    [TestFixture]
    public class AdvertTests
    {
        [Test]
        public void Id_Should_HaveTheKeyAttribute()
        {
            // Arrange
            var keyAttributeProperty = typeof(Advert).GetProperty("Id");

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
            var advert = new Advert { Id = testId };

            // Assert
            Assert.AreEqual(testId, advert.Id);
        }

        [Test]
        public void Title_Should_HaveTheRequiredAttribute()
        {
            // Arrange
            var titleProp = typeof(Advert).GetProperty("Title");

            // Act
            var requiredAttribute = titleProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Title_Should_HaveTheCorrectMinLength()
        {
            // Arrange
            var titleProp = typeof(Advert).GetProperty("Title");

            // Act
            var minLengthAttribute = titleProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.AdvertTitleMinLength));
        }

        [Test]
        public void Title_Should_HaveTheCorrectMaxLength()
        {
            // Arrange
            var titleProp = typeof(Advert).GetProperty("Title");

            // Act
            var maxLengthAttribute = titleProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.AdvertTitleMaxLength));
        }

        [TestCase("Best Scrap Car Brah!")]
        [TestCase("Best Hypercar Car Brah!")]
        public void Title_Should_SetTitleDataCorrectly(string testTitle)
        {
            // Arrange & Act
            var advert = new Advert { Title = testTitle };

            // Assert
            Assert.AreEqual(testTitle, advert.Title);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_Should_GetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var advert = new Advert { IsDeleted = testIsDeleted };

            // Assert
            Assert.AreEqual(testIsDeleted, advert.IsDeleted);
        }

        [Test]
        public void Year_Should_HaveRequiredAttribute()
        {
            // Arrange
            var yearProp = typeof(Advert).GetProperty("Year");

            // Act
            var requiredAttribute = yearProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(1999)]
        [TestCase(2017)]
        public void Year_Should_SetDataCorrectly(int testYear)
        {
            // Arrange & Act
            var advert = new Advert { Year = testYear };

            // Assert
            Assert.AreEqual(testYear, advert.Year);
        }

        [Test]
        public void Price_Should_HaveRequiredAttribute()
        {
            // Arrange
            var priceProp = typeof(Advert).GetProperty("Price");

            // Act
            var requiredAttribute = priceProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(14000.00)]
        [TestCase(4329.00)]
        public void Price_Should_SetDataCorreclty(decimal testPrice)
        {
            // Arrange & Act
            var advert = new Advert { Price = testPrice };

            // Assert
            Assert.AreEqual(testPrice, advert.Price);
        }

        [Test]
        public void Power_Should_HaveRequiredAttribute()
        {
            // Arrange
            var powerProp = typeof(Advert).GetProperty("Power");

            // Act
            var requiredAttribute = powerProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(247)]
        [TestCase(1001)]
        public void Power_Should_SetDataCorrectly(int testPower)
        {
            // Arrange & Act
            var advert = new Advert { Power = testPower };

            // Assert
            Assert.AreEqual(testPower, advert.Power);
        }

        [Test]
        public void DistanceCoverage_Should_HaveRequiredAttribute()
        {
            // Arrange
            var distanceCoverageProp = typeof(Advert).GetProperty("DistanceCoverage");

            // Act
            var requiredAttribute = distanceCoverageProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [TestCase(50000)]
        [TestCase(250000)]
        public void DistanceCoverage_Should_SetDataCorrectly(int testDistanceCoverage)
        {
            // Arrange & Act
            var advert = new Advert { DistanceCoverage = testDistanceCoverage };

            // Assert
            Assert.AreEqual(testDistanceCoverage, advert.DistanceCoverage);
        }

        [Test]
        public void Description_Should_HaveRequiredAttribute()
        {
            // Arrange
            var descriptionProp = typeof(Advert).GetProperty("Description");

            // Act
            var requiredAttribute = descriptionProp.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Description_Should_HaveTheCorrectMinLength()
        {
            // Arrange
            var descriptionProp = typeof(Advert).GetProperty("Description");

            // Act
            var minLengthAttribute = descriptionProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.AdvertDescriptionMinLength));
        }

        [Test]
        public void Description_Should_HaveTheCorrectMaxLength()
        {
            // Arrange
            var descriptionProp = typeof(Advert).GetProperty("Description");

            // Act
            var minLengthAttribute = descriptionProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.AdvertDescriptionMaxLength));
        }

        [TestCase("I Crashed My car Like 42 Times!!! Please Buy It!!!")]
        [TestCase("I Crashed My car Like 12312313 Times!!! Please Buy It!!!")]
        public void Description_Should_SetDataCorrectly(string testDescription)
        {
            // Arrange & Act
            var advert = new Advert { Description = testDescription };

            // Assert
            Assert.AreEqual(testDescription, advert.Description);
        }

        [Test]
        public void Constructor_Should_HaveParametlessConstructor()
        {
            // Arrange & Act
            var advert = new Advert();

            // Assert
            Assert.IsInstanceOf<Advert>(advert);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void VehicleModelId_Should_GetAndSetDataCorrectly(int testVehicleModelId)
        {
            // Arrange & Act
            var advert = new Advert() { VehicleModelId = testVehicleModelId };

            // Assert
            Assert.AreEqual(advert.VehicleModelId, testVehicleModelId);
        }

        [TestCase("Model X")]
        [TestCase("La Ferrari")]
        public void VehicleModel_Should_GetAndSetDataCorrectly(string testVehicleModelName)
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel { Name = testVehicleModelName };
            var advert = new Advert() { VehicleModel = vehicleModel };

            // Assert
            Assert.AreEqual(advert.VehicleModel.Name, testVehicleModelName);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void CityId_Should_GetAndSetDataCorrectly(int testCityId)
        {
            // Arrange & Act
            var advert = new Advert() { CityId = testCityId };

            // Assert
            Assert.AreEqual(advert.CityId, testCityId);
        }

        [TestCase("Veliko Turnovo")]
        [TestCase("Sofia")]
        public void City_Should_GetAndSetDataCorreclty(string testCityName)
        {
            // Arrange & Act
            var city = new City { Name = testCityName };
            var advert = new Advert { City = city };

            // Assert
            Assert.AreEqual(advert.City.Name, testCityName);
        }

        [TestCase("191983391239jskd-asdnbjasdnj-22")]
        [TestCase("asdjasdj9i1231-123ju1jsad")]
        public void UserId_Should_GetAndSetDataCorrectly(string testUserId)
        {
            // Arrange & Act
            var advert = new Advert() { UserId = testUserId };

            // Assert
            Assert.AreEqual(advert.UserId, testUserId);
        }

        [TestCase("chuk@abv.bg")]
        [TestCase("tuturutka@yahoo.com")]
        public void User_Should_GetAndSetDataCorreclty(string testUserEmail)
        {
            // Arrange & Act
            var user = new User { Email = testUserEmail };
            var advert = new Advert { User = user };

            // Assert
            Assert.AreEqual(advert.User.Email, testUserEmail);
        }

        [Test]
        public void AdvertImages_Should_GetAndSetDataCorrectly()
        {
            // Arrange & Act
            var advertImages = new List<AdvertImage> { new AdvertImage(), new AdvertImage() };
            var advert = new Advert { AdvertImages = advertImages };

            // Assert
            Assert.AreEqual(advert.AdvertImages, advertImages);
        }
    }
}
