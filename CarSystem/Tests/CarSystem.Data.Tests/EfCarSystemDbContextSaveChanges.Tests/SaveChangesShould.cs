using Moq;
using NUnit.Framework;

using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;

namespace CarSystem.Data.Tests.EfCarSystemDbContextSaveChanges.Tests
{
    [TestFixture]
    public class SaveChangesShould
    {
        [Test]
        public void SaveChanges_Should_CallSaveChangesOnce()
        {
            // Arrange
            var validDbContext = new Mock<ICarSystemEfDbContext>();
            var carSystemDbContextSaveChanges = new CarSystemDbContextSaveChanges(validDbContext.Object);

            // Act
            carSystemDbContextSaveChanges.SaveChanges();

            // Assert
            validDbContext.Verify(u => u.SaveChanges(), Times.Once);
        }
    }
}
