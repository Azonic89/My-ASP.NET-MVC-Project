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
            var context = new Data.CarSystemDbContext();

            // Assert
            Assert.IsInstanceOf<Data.CarSystemDbContext>(context);
        }

        [Test]
        public void Constructor_Should_Return_InstanceOfIPetsWonderlandDbContext()
        {
            // Arrange & Act
            var context = new Data.CarSystemDbContext();

            // Assert
            Assert.IsInstanceOf<ICarSystemDbContext>(context);
        }
    }
}
