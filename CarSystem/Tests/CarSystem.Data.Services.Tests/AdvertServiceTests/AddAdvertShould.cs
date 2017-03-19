using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using Moq;

namespace CarSystem.Data.Services.Tests.AdvertServiceTests
{
    [TestFixture]
    public class AddAdvertShould
    {
        //[Test]
        //public void AddAdvert_Should_BeCalled_IfAdvertIsValid()
        //{
        //    var mockedCarSystemData = new Mock<ICarSystemData>();
        //    var advertService = new AdvertService(mockedCarSystemData.Object);
        //    var advertToAdd = new Advert();
        //    var advertRepository = new Mock<IEfGenericRepository<Advert>>();
        //    mockedCarSystemData.Setup(a => a.Adverts).Returns(advertRepository.Object);
        //    advertService.AddAdvert(advertToAdd);


        //    mockedCarSystemData.Verify(data => data.Adverts.Add(advertToAdd), Times.Once);
        //}
    }
}
