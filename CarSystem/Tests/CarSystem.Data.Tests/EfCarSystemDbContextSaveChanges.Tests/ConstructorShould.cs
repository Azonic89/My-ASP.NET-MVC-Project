using System;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;

namespace CarSystem.Data.Tests.EfCarSystemDbContextSaveChanges.Tests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Contructor_Should_ThrowArgumentNullException_IfPassedDbContextIsNull()
        {
            // Arrange
            ICarSystemEfDbContext dbContextThatIsNull = null;

            // Act & Assert
            Assert.That(
                () => new CarSystemDbContextSaveChanges(dbContextThatIsNull),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("carSystemEfDbContext"));
        }

        [Test]
        public void Contructor_Should_NotThrowArgumentNullException_IfPassedDbContextIsNotNull()
        {
            // Arrange
            var validDbContext = new Mock<ICarSystemEfDbContext>();
            var carSystemDbContextSaveChanges = new CarSystemDbContextSaveChanges(validDbContext.Object);

            // Act & Assert
            Assert.That(carSystemDbContextSaveChanges, Is.Not.Null);
        }
    }
}
