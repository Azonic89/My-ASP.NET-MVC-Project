using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetCategoryByIdShould
    {
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);
            var category = new Mock<Category>();

            // Act
            categoryService.GetById(category.Object.Id);

            // Assert
            mockedDbSet.Verify(rep => rep.GetById(category.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Assert
            mockedDbSet.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperCategoryWithId_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);
            var categoryWithId = new Mock<Category>();

            // Act
            mockedDbSet.Setup(rep => rep.GetById(categoryWithId.Object.Id)).Returns(() => categoryWithId.Object);

            // Assert
            Assert.IsInstanceOf<Category>(categoryService.GetById(categoryWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);
            var categoryWithId = new Mock<Category>();

            // Act
            mockedDbSet.Setup(rep => rep.GetById(categoryWithId.Object.Id)).Returns(() => categoryWithId.Object);

            // Assert
            Assert.AreEqual(categoryService.GetById(categoryWithId.Object.Id), categoryWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfCategoryIsNull()
        {
            // Arrange & Act
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);
            Mock<Category> categoryThatIsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => categoryService.GetById(categoryThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnCategory_IfThereIsNoCategoryYolo()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);

            // Act
            mockedDbSet.Setup(rep => rep.GetById(0)).Returns(() => null);

            // Assert
            Assert.IsNull(categoryService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectCategory_IfCalled()
        {
            // Arrange
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Category>>();
            var categoryService = new CategoryService(mockedDbSet.Object);
            var category = new Mock<Category>();
            var secondCategory = new Mock<Category>();

            // Act
            mockedDbSet.Setup(rep => rep.GetById(category.Object.Id)).Returns(() => category.Object);

            // Assert
            Assert.AreNotEqual(categoryService.GetById(category.Object.Id), secondCategory.Object);
        }
    }
}
