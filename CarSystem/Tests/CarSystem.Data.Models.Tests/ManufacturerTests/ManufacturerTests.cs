using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NUnit.Framework;

using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models.Tests.ManufacturerTests
{
    [TestFixture]
    public class ManufacturerTests
    {
        [Test]
        public void Constructor_ShouldHaveParameterlessConstructor()
        {
            // Arrange & Act
            var manufacturer = new Manufacturer();

            // Assert
            Assert.IsInstanceOf<Manufacturer>(manufacturer);
        }

        [Test]
        public void Constructor_ShouldInitializeVehicleModelCollectionCorrectly()
        {
            // Arrange & Act
            var manufacturer = new Manufacturer();
            var vehicleModel = manufacturer.Models;

            // Assert
            Assert.That(vehicleModel, Is.Not.Null.And.InstanceOf<HashSet<VehicleModel>>());
        }
        
        [Test]
        public void Id_ShouldHaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Manufacturer).GetProperty("Id");

            // Act
            var keyAttribute = idProperty.GetCustomAttributes(typeof(KeyAttribute), true)
                .Cast<KeyAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(keyAttribute, Is.Not.Null);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void Id_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var manufacturer = new Manufacturer { Id = testId };

            // Assert
            Assert.AreEqual(testId, manufacturer.Id);
        }
        
        [Test]
        public void Name_ShouldHaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

            // Act
            var requiredAttribute = nameProperty.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(requiredAttribute, Is.Not.Null);
        }

        [Test]
        public void Name_ShouldHaveUniqueAttribute()
        {
            // Arrange
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

            // Act
            var indexAttribute = nameProperty.GetCustomAttributes(typeof(IndexAttribute), true)
                .Cast<IndexAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(indexAttribute.IsUnique, Is.True);
        }

        [Test]
        public void Name_ShouldHaveCorrectMinLength()
        {
            // Arrange
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.ManufacturerNameMinLength));
        }

        [Test]
        public void Name_ShouldHaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Manufacturer).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.ManufacturerNameMaxLength));
        }

        [TestCase("Audi")]
        [TestCase("BMV")]
        public void Name_ShouldGetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var manufacturer = new Manufacturer { Name = testName };

            // Assert
            Assert.AreEqual(manufacturer.Name, testName);
        }

        [TestCase(123)]
        [TestCase(12)]
        public void VehicleModelCollection_ShouldGetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel() { Id = testId };
            var set = new HashSet<VehicleModel> { vehicleModel };
            var manufacturer = new Manufacturer() { Models = set };

            // Assert
            Assert.AreEqual(manufacturer.Models.First().Id, testId);
        }
    }
}
