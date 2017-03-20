﻿using System;
using System.Data.Entity;

using NUnit.Framework;
using Moq;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models.Contracts;
using CarSystem.Data.Repositories;

namespace CarSystem.Data.Tests.EfRepoCarSystemData.Tests
{
    [TestFixture]
    public class DetachShould
    {
        [Test]
        public void Detach_Should_BeCalled_WhenInvoked()
        {
            // Arrange
            var mockedSet = new Mock<DbSet<IAdvert>>();
            var mockedDbContext = new Mock<ICarSystemDbContext>();
            mockedDbContext.Setup(x => x.Set<IAdvert>()).Returns(mockedSet.Object);
            var dataProvider = new EfCarSystemDataProvider<IAdvert>(mockedDbContext.Object);
            var mockedAdvert = new Mock<IAdvert>();

            // Act
            try
            {
                dataProvider.Detach(mockedAdvert.Object);
            }
            catch (NullReferenceException e) { };

            // Assert
            mockedDbContext.Verify(x => x.Entry(mockedAdvert.Object), Times.AtLeastOnce);
        }
    }
}