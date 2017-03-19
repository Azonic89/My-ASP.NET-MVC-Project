using NUnit.Framework;
using System;
using CarSystem.Data.Contracts;
using Moq;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        //[Test]
        //public void Constructor_Should_CreateAdvertServices_IfParamsAreValid()
        //{
        //    // Arrange & Act
        //    var mockedSystemData = new Mock<ICarSystemData>();
        //    var advertService = new AdvertService(mockedSystemData.Object);

        //    // Assert
        //    Assert.That(advertService, Is.InstanceOf<AdvertService>());
        //}

        //[Test]
        //public void Constructor_Should_ThrowNullReferenceException_IfPassedCarSystemDataIsNull()
        //{
        //    // Arrange & Act
        //    Mock<ICarSystemData> mockedSystemData = null;

        //    // Assert
        //    Assert.Throws<NullReferenceException>(
        //        () => new AdvertService(mockedSystemData.Object));
        //}
    }
}
