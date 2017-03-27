using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;
using Moq;
using TestStack.FluentMVCTesting;

using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Areas.Admin.Controllers;
using CarSystem.Data.Models;


namespace CarSystem.Web.Controllers.Tests.AdminControllerTests
{
    [TestFixture]
    public class GetAllAdvertsShould
    {
        [Test]
        public void GetAllAdverts_Should_ReturnJson_AndCallGetAllAdvertFromViewModel()
        {
            // Arrange
            var mockedAdvertService = new Mock<IAdvertService>();

            var advert = new Advert
            {
                Id = 15,
                Price = 20,
                Power = 155,
                DistanceCoverage = 15555,
                Description = "Mnogo Qkata Brichka brat"
            };

            var adverts = new List<Advert>()
            {
                new Advert
                {
                    Id = 15,
                    Price = 20,
                    Power = 155,
                    DistanceCoverage = 15555,
                    Description = "Mnogo Qkata Brichka brat"
                }
            }.AsQueryable();

            mockedAdvertService.Setup(a => a.GetAllAdverts()).Returns(adverts);

            var adminController = new AdminController(mockedAdvertService.Object);

            // Act & Assert
            adminController
                .WithCallTo(a => a.GetAllAdverts())
                .ShouldReturnJson(data =>
                {
                    Assert.That(advert.Id, Is.EqualTo(15));
                    Assert.That(advert.Price, Is.EqualTo(20));
                    Assert.That(advert.Power, Is.EqualTo(155));
                    Assert.That(advert.DistanceCoverage, Is.EqualTo(15555));
                    Assert.That(advert.Description, Is.EqualTo("Mnogo Qkata Brichka brat"));
                });
        }  
    }
}
