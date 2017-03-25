using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.EfDbSetCocoon;

namespace CarSystem.Data.Tests.EfCarSystemDbContextSaveChanges.Tests
{
    [TestFixture]
    public class DisposeShould
    {
        [Test]
        public void Dispose_Should_BeCalledNever()
        {
            // Arrange
            var validDbContext = new Mock<ICarSystemEfDbContext>();
            var carSystemDbContextSaveChanges = new CarSystemDbContextSaveChanges(validDbContext.Object);

            // Act
            carSystemDbContextSaveChanges.Dispose();

            // Assert
            validDbContext.Verify(u => u.Dispose(), Times.Never);
        }
    }
}
