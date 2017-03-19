using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;

namespace CarSystem.Data.Services
{
    public class AdvertService
    {
        //private readonly ICarSystemData carSystemData;

        //public AdvertService(ICarSystemData carSystemData)
        //{
        //    Guard.WhenArgument(carSystemData, "Unit of Work is Null!!!").IsNull().Throw();

        //    this.carSystemData = carSystemData;
        //}

        //public void AddAdvert(Advert advertToAdd)
        //{
        //    Guard.WhenArgument(advertToAdd, "Advert to Add is Null!!!").IsNull().Throw();

        //    this.carSystemData.Adverts.Add(advertToAdd);
        //}

        //public void DeleteAdvert(Advert advertToDelete)
        //{
        //    Guard.WhenArgument(advertToDelete, "Advert To Delete is Null!!!!").IsNull().Throw();

        //    this.carSystemData.Adverts.Delete(advertToDelete);
        //}

        //public void DeleteAdvertById(object advertId)
        //{
        //    Guard.WhenArgument(advertId, "The Id of the Advert cannot be Null!!!").IsNull().Throw();

        //    this.carSystemData.Adverts.Delete((int)advertId);
        //}

        //public IQueryable<Advert> GetAllAdverts()
        //{
        //    return this.carSystemData.Adverts.All();
        //}

        //public Advert GetById(int id)
        //{
        //    return this.carSystemData.Adverts.GetById(id);
        //}

        //public IQueryable<Advert> GetAdvertsByMultipleParameters(int vehicleModelId, int cityId, int minPrice, int maxPrice, int yearFrom, int yearTo)
        //{
        //    var adverts = this.carSystemData.Adverts
        //                                    .All()
        //                                    .Where(a => a.VehicleModelId == vehicleModelId &&
        //                                                a.CityId == cityId &&
        //                                                a.Price >= minPrice &&
        //                                                a.Price <= maxPrice &&
        //                                                a.Year >= yearFrom &&
        //                                                a.Year <= yearTo);

        //    return adverts;
        //}

        //public void UpdateAdvert(Advert advert)
        //{
        //    this.carSystemData.Adverts.Update(advert);
        //}

        //public IQueryable<Advert> GetAllAdvertsByUserId(string userId)
        //{
        //    var adverts = this.carSystemData.Adverts
        //        .All()
        //        .Where(a => a.UserId == userId);

        //    return adverts;
        //}
    }
}
