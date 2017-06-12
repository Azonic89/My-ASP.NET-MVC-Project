using NUnit.Framework;

using CarSystem.Data.Contracts;

namespace CarSystem.Data.Tests.CarSystemDbContext.Tests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_HaveParameterlessConstructor()
        {
            // Arrange & Act
            var context = new Data.CarSystemEfDbContext();

            // Assert
            Assert.IsInstanceOf<Data.CarSystemEfDbContext>(context);
        }

        [Test]
        public void Constructor_Should_Return_InstanceOfICarSystemEfDbContext()
        {
            // Arrange & Act
            var context = new Data.CarSystemEfDbContext();

            // Assert
            Assert.IsInstanceOf<ICarSystemEfDbContext>(context);
        }
    }
}
