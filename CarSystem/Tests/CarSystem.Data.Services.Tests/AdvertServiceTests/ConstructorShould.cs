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
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();
            var advertService = new AdvertService(mockedDbSet.Object, mockedSaveChanges.Object);

            // Assert
            Assert.That(advertService, Is.InstanceOf<AdvertService>());
        }

        [Test]
        public void Constructor_Should_ArgumentNullException_IfPassedDbSetIsNull()
        {
            // Arrange & Act
            IEfCarSystemDbSetCocoon<Advert> nullMockedSet = null;
            var mockedSaveChanges = new Mock<ICarSystemEfDbContextSaveChanges>();

            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new AdvertService(nullMockedSet, mockedSaveChanges.Object));
        }

        [Test]
        public void Constuctor_Should_ThrowNullReferenceException_IfPassedEfSaveChangesIsNull()
        {
            var mockedDbSet = new Mock<IEfCarSystemDbSetCocoon<Advert>>();
            Mock<ICarSystemEfDbContextSaveChanges> mockedNullSaveChanges = null;

            Assert.Throws<NullReferenceException>(
                () => new AdvertService(mockedDbSet.Object, mockedNullSaveChanges.Object));
        }
    }
}
