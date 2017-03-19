using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using NUnit.Framework;

using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models.Tests.CityTests
{
    [TestFixture]
    public class CityTests
    {
        [Test]
        public void Constructor_Should_HaveParameterlessConstructor()
        {
            // Arrange & Act
            var city = new City();

            // Assert
            Assert.IsInstanceOf<City>(city);
        }

        [Test]
        public void Constructor_Should_InitializeAdvertCollectionCorrectly()
        {
            // Arrange & Act
            var city = new City();
            var advert = city.Adverts;

            // Assert
            Assert.That(advert, Is.Not.Null.And.InstanceOf<HashSet<Advert>>());
        }
        
        [Test]
        public void Id_Should_HaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(City).GetProperty("Id");

            // Act
            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_Should_GetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var city = new City() { Id = testId };

            // Assert
            Assert.AreEqual(testId, city.Id);
        }

        [Test]
        public void Name_Should_HaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_Should_HaveUniqueAttribute()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(indexAttribute, Is.Not.Null);
            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void Name_Should_HaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.CityNameMinLength));
        }

        [Test]
        public void Name_Should_HaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(City).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.CityNameMaxLength));
        }

        [TestCase("Sofia")]
        [TestCase("Varna")]
        public void Name_Should_GetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var city = new City { Name = testName };

            // Assert
            Assert.AreEqual(city.Name, testName);
        }
        
        [TestCase(123)]
        [TestCase(12)]
        public void AdvertsCollection_Should_GetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var advert = new Advert() { Id = testId };
            var set = new HashSet<Advert> { advert };
            var city = new City() { Adverts = set };

            // Assert
            Assert.AreEqual(city.Adverts.First().Id, testId);
        }
    }
}
