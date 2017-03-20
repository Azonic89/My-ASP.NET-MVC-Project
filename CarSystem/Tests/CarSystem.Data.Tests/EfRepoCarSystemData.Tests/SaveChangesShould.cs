﻿using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models.Contracts;
using CarSystem.Data.Repositories;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class SaveChangesShould
    {
        [Test]
        public void SaveChanges_Should_BeCalled_WhenDisposingProvider()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<IAdvert>>();
            var mockedDbContext = new Mock<ICarSystemDbContext>();
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedSet.Object);
            var dataProvider = new EfCarSystemDataProvider<IAdvert>(mockedDbContext.Object);

            // Act
            dataProvider.SaveChanges();
         
            // Assert
            mockedDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}