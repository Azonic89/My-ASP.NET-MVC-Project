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
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Assert
            Assert.That(categoryService, Is.InstanceOf<CategoryService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDataProviderIsNull()
        {
            // Arrange & Act
            IEfCarSystemDbSetCocoon<Category> nullDataProvider = null;

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new CategoryService(nullDataProvider));
        }
    }
}
