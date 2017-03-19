using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using NUnit.Framework;

using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models.Tests.CategoryTests
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Constructor_Should_HaveParameterlessConstructor()
        {
            // Arrange & Act
            var category = new Category();

            // Assert
            Assert.IsInstanceOf<Category>(category);
        }

        [Test]
        public void Constructor_Should_InitializeVehicleModelsCollectionCorrectly()
        {
            // Arrange & Act
            var category = new Category();
            var vehicleModel = category.VehicleModels;

            // Assert
            Assert.That(vehicleModel, Is.Not.Null.And.InstanceOf<HashSet<VehicleModel>>());
        }

        [Test]
        public void Id_Should_HaveKeyAttribute()
        {
            // Arrange
            var idProperty = typeof(Category).GetProperty("Id");

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
            var category = new Category() { Id = testId };

            // Assert
            Assert.AreEqual(testId, category.Id);
        }

        [Test]
        public void Name_Should_HaveRequiredAttribute()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

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
            var nameProperty = typeof(Category).GetProperty("Name");

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
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.CategoryNameMinLength));
        }

        [Test]
        public void Name_Should_HaveCorrectMaxLength()
        {
            // Arrange
            var nameProperty = typeof(Category).GetProperty("Name");

            // Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.CategoryNameMaxLength));
        }

        [TestCase("Car")]
        [TestCase("Bus")]
        public void Name_Should_GetAndSetDataCorrectly(string testName)
        {
            // Arrange & Act
            var category = new Category() { Name = testName };

            // Assert
            Assert.AreEqual(category.Name, testName);
        }

        [TestCase(123)]
        [TestCase(12)]
        public void VehicleModelsCollection_Should_GetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var vehicleModel = new VehicleModel() { Id = testId };
            var set = new HashSet<VehicleModel> { vehicleModel };
            var category = new Category() { VehicleModels = set };

            // Assert
            Assert.AreEqual(category.VehicleModels.First().Id, testId);
        }
    }
}
