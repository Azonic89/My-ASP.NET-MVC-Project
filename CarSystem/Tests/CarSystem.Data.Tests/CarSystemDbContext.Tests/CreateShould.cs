using NUnit.Framework;

using CarSystem.Data.Contracts;

namespace CarSystem.Data.Tests.CarSystemDbContext.Tests
{
    [TestFixture]
    public class CreateShould
    {
        [Test]
        public void Create_Should_ReturnNewDbContextInstance()
        {
            // Arrange & Act
            var newContext = Data.CarSystemDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<ICarSystemDbContext>(newContext);
        }
    }
}
