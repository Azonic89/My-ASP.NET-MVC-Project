using System;

using Moq;
using NUnit.Framework;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Constructor_Should_CreateAdvertServices_IfParamsAreValid()
        {
            // Arrange & Act
            var mockedDataProvider = new Mock<IEfCarSystemDataProvider<Advert>>();
            var advertService = new AdvertService(mockedDataProvider.Object);

            // Assert
            Assert.That(advertService, Is.InstanceOf<AdvertService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDataProviderIsNull()
        {
            // Arrange & Act
            IEfCarSystemDataProvider<Advert> nullDataProvider = null;

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new AdvertService(nullDataProvider));
        }
    }
}
