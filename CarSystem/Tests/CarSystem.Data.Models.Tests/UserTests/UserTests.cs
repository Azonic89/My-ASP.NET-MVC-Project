using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using NUnit.Framework;

using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models.Tests.UserTests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_Should_HaveParametlessConstructor()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void Constructor_Should_InitializeAdvertCollectionCorreclty()
        {
            // Arrange & Act
            var user = new User();
            var adverts = user.Adverts;

            // Assert
            Assert.That(adverts, Is.Not.Null.And.InstanceOf<HashSet<Advert>>());
        }

        [Test]
        public void FirstName_Should_HaveTheCorrectMinLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("FirstName");

            // Act
            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.UserFirstNameMinLength));
        }

        [Test]
        public void FirstName_Should_HaveTheCorrectMaxLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("FirstName");

            // Act
            var maxLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.UserFirstNameMaxLength));
        }

        [TestCase("Vasil")]
        [TestCase("Ivan")]
        public void FirstName_Should_SetTitleDataCorrectly(string testFirstName)
        {
            // Arrange & Act
            var user = new User { FirstName = testFirstName };

            // Assert
            Assert.AreEqual(testFirstName, user.FirstName);
        }

        [Test]
        public void LastName_Should_HaveTheCorrectMinLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("LastName");

            // Act
            var minLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(minLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.UserLastNameMinLength));
        }

        [Test]
        public void LastName_Should_HaveTheCorrectMaxLength()
        {
            // Arrange
            var firstNameProp = typeof(User).GetProperty("LastName");

            // Act
            var maxLengthAttribute = firstNameProp.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // Assert
            Assert.That(maxLengthAttribute.Length, Is.Not.Null.And.EqualTo(ModelsValidationConstants.UserLastNameMaxLength));
        }

        [TestCase("Penev")]
        [TestCase("Angelov")]
        public void LastName_Should_SetTitleDataCorrectly(string testLastName)
        {
            // Arrange & Act
            var user = new User { LastName = testLastName };

            // Assert
            Assert.AreEqual(testLastName, user.LastName);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsDeleted_Should_GetAndSetDataCorrectly(bool testIsDeleted)
        {
            // Arrange & Act
            var user = new User { IsDeleted = testIsDeleted };

            // Assert
            Assert.AreEqual(testIsDeleted, user.IsDeleted);
        }

        [TestCase(123)]
        [TestCase(12)]
        public void AdvertCollection_Should_GetAndSetDataCorrectly(int testId)
        {
            // Arrange & Act
            var advert = new Advert() { Id = testId };
            var set = new HashSet<Advert> { advert };
            var user = new User() { Adverts = set };

            // Assert
            Assert.AreEqual(user.Adverts.First().Id, testId);
        }
    }
}
