using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NUnit.Framework;

using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models.Tests.VehicleModelTests
{
    [TestFixture]
    public class VehicleModelTests
    {
        [Test]
        public void Constructor_Should_HaveParameterlessConstructor()
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel();

            // Assert
            Assert.IsInstanceOf<VehicleModel>(vehicleModel);
        }

        [Test]
        public void Constructor_Should_InitializeAdvertCollectionCorrectly()
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel();
            var advert = vehicleModel.Adverts;

            // Assert
            Assert.That(advert, Is.Not.Null.And.InstanceOf<HashSet<Advert>>());
        }
        
        [Test]
        public void Id_Should_HaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(VehicleModel).GetProperty("Id");

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
            var vehicleModel = new VehicleModel { Id = testId };

            //Assert
            Assert.AreEqual(testId, vehicleModel.Id);
        }

        [Test]
        public void Name_Should_HaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

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
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

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
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.VechicleNameMinLength));
        }

        [Test]
        public void Name_Should_HaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(VehicleModel).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.VechicleNameMaxLength));
        }

        [TestCase("A4")]
        [TestCase("Tigra")]
        public void Name_Should_GetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel { Name = testName };

            //Assert
            Assert.AreEqual(vehicleModel.Name, testName);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void ManufacturerId_Should_GetAndSetDataCorrectly(int testManufacturerId)
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel { ManufacturerId = testManufacturerId };

            // Assert
            Assert.AreEqual(vehicleModel.ManufacturerId, testManufacturerId);
        }
        
        [TestCase("Audi")]
        [TestCase("Fiat")]
        public void Manufacturer_Should_GetAndSetDataCorrectly(string testManufacturerName)
        {
            // Arrange & Act         
            var manufacturer = new Manufacturer() { Name = testManufacturerName };
            var vehicleModel = new VehicleModel { Manufacturer = manufacturer };

            // Assert
            Assert.AreEqual(vehicleModel.Manufacturer.Name, testManufacturerName);
        }

        [TestCase(15)]
        [TestCase(20)]
        public void CategoryId_Should_GetAndSetDataCorrectly(int categoryId)
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel { CategoryId = categoryId };

            // Assert
            Assert.AreEqual(vehicleModel.CategoryId, categoryId);
        }

        [TestCase("Audi")]
        [TestCase("Fiat")]
        public void Category_Should_GetAndSetDataCorrectly(string testCategoryName)
        {
            // Arrange & Act         
            var category = new Category() { Name = testCategoryName };
            var vehicleModel = new VehicleModel { Category = category };

            // Assert
            Assert.AreEqual(vehicleModel.Category.Name, testCategoryName);
        }
        
        [TestCase(123)]
        [TestCase(12)]
        public void AdvertsCollection_Should_GetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var advert = new Advert() { Id = testId };
            var set = new HashSet<Advert> { advert };
            var manufacturer = new VehicleModel() { Adverts = set };

            // Assert
            Assert.AreEqual(manufacturer.Adverts.First().Id, testId);
        }
    }
}
