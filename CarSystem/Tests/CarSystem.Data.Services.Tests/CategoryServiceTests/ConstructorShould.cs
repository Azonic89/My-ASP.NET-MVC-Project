using System;

using Moq;
using NUnit.Framework;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateCategoryServices_IfParamsAreValid()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);

            // Assert
            Assert.That(categoryService, Is.InstanceOf<CategoryService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDataProviderIsNull()
        {
            // Arrange & Act
            IEfCarSystemDataProvider<Category> nullDataProvider = null;

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new CategoryService(nullDataProvider));
        }
    }
}
