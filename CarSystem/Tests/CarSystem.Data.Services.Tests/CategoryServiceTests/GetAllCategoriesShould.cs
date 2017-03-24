using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetAllCategoriesShould
    {
        [Test]
        public void GetAllCategories_Should_BeCalled_IfParamsAreValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Act
            categoryService.GetAllCategories();

            // Assert
            mockedDbSet.Verify(rep => rep.All(), Times.Once);
        }

        [Test]
        public void GetAllCategories_Should_NotBeCalled_IfItIsNeverCalled()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.All(), Times.Never);
        }

        [Test]
        public void GetAllCategories_Should_ReturnIQueryable_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Act
            IEnumerable<Category> expectedCategoriesResult = new List<Category>() { new Category(), new Category() };
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            // Assert
            Assert.IsInstanceOf<IQueryable<Category>>(categoryService.GetAllCategories());
        }

        [Test]
        public void GetAllCategories_Should_ReturnCorrectCollection_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Act
            IEnumerable<Category> expectedCategoriesResult = new List<Category>() { new Category(), new Category() };
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            // Assert
            Assert.AreEqual(categoryService.GetAllCategories(), expectedCategoriesResult);
        }

        [Test]
        public void GetAllCategories_Should_ReturnEmptyCollection_IfThereAreNoAdvertsAdded()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Act
            IEnumerable<Category> expectedCategoriesResult = new List<Category>();
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            // Assert
            Assert.IsEmpty(categoryService.GetAllCategories());
        }

        [Test]
        public void GetAllCategories_Should_ThrowArgumentNullException_IfPassedAdvertsAreNull()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Act
            IEnumerable<Category> expectedCategoriesResult = null;
            mockedDbSet.Setup(rep => rep.All()).Returns(() => expectedCategoriesResult.AsQueryable());

            // Assert
            Assert.Throws<ArgumentNullException>(() => categoryService.GetAllCategories());
        }
    }
}
