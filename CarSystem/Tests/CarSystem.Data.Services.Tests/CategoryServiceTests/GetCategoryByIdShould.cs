using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using Moq;

namespace CarSystem.Data.Services.Tests.CategoryServiceTests
{
    [TestFixture]
    public class GetCategoryByIdShould
    {
        public void GetById_Should_BeCalledOnce_IfParamsAreValid()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);
            var category = new Mock<Category>();

            // Act
            categoryService.GetById(category.Object.Id);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(category.Object.Id), Times.Once);
        }

        [Test]
        public void GetById_Should_NotBeCalled_IfNotCalledYolo()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);

            // Assert
            mockedDataProvider.Verify(rep => rep.GetById(1), Times.Never);
        }

        [Test]
        public void GetById_Should_ReturnTheProperCategoryWithId_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);
            var categoryWithId = new Mock<Category>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(categoryWithId.Object.Id)).Returns(() => categoryWithId.Object);

            // Assert
            Assert.IsInstanceOf<Category>(categoryService.GetById(categoryWithId.Object.Id));
        }

        [Test]
        public void GetById_Should_Work_IfCalledWithValidParams()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);
            var categoryWithId = new Mock<Category>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(categoryWithId.Object.Id)).Returns(() => categoryWithId.Object);

            // Assert
            Assert.AreEqual(categoryService.GetById(categoryWithId.Object.Id), categoryWithId.Object);
        }

        [Test]
        public void GetById_ShouldThrowNullReferenceException_IfCategoryIsNull()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);
            Mock<Category> categoryThatIsNull = null;

            // Assert
            Assert.Throws<NullReferenceException>(() => categoryService.GetById(categoryThatIsNull.Object.Id));
        }

        [Test]
        public void GetById_Should_NotReturnCategory_IfThereIsNoCategoryYolo()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);
            Mock<Category> categoryThatIsNull = null;

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(0)).Returns(() => null);

            // Assert
            Assert.IsNull(categoryService.GetById(0));
        }

        [Test]
        public void GetById_Should_ReturnTheCorrectAdvert_IfCalled()
        {
            // Arrange
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Category>>();
            var categoryService = new CategoryService(mockedDataProvider.Object);
            var category = new Mock<Category>();
            var secondCategory = new Mock<Category>();

            // Act
            mockedDataProvider.Setup(rep => rep.GetById(category.Object.Id)).Returns(() => category.Object);

            // Assert
            Assert.AreNotEqual(categoryService.GetById(category.Object.Id), secondCategory.Object);
        }
    }
}
