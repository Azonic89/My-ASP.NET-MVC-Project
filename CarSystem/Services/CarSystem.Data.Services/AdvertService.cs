using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IEfCarSystemDataProvider<Advert> advertDataProvider;

        public AdvertService(IEfCarSystemDataProvider<Advert> advertDataProvider)
        {
            Guard.WhenArgument(advertDataProvider, nameof(advertDataProvider)).IsNull().Throw();

            this.advertDataProvider = advertDataProvider;
        }

        public void AddAdvert(Advert advertToAdd)
        {
            Guard.WhenArgument(advertToAdd, nameof(advertToAdd)).IsNull().Throw();

            this.advertDataProvider.Add(advertToAdd);
            this.advertDataProvider.SaveChanges();
        }

        public void DeleteAdvert(Advert advertToDelete)
        {
            Guard.WhenArgument(advertToDelete, nameof(advertToDelete)).IsNull().Throw();

            this.advertDataProvider.Delete(advertToDelete);
            this.advertDataProvider.SaveChanges();
        }

        public void DeleteAdvertById(object advertId)
        {
            Guard.WhenArgument(advertId, nameof(advertId)).IsNull().Throw();

            this.advertDataProvider.Delete((int)advertId);
            this.advertDataProvider.SaveChanges();
        }

        public IQueryable<Advert> GetAllAdverts()
        {
            return this.advertDataProvider.All();
        }

        public Advert GetById(int id)
        {
            return this.advertDataProvider.GetById(id);
        }

        public IQueryable<Advert> GetAdvertsByMultipleParameters(int vehicleModelId, int cityId, int minPrice, int maxPrice, int yearFrom, int yearTo)
        {
            var adverts = this.advertDataProvider
                                            .All()
                                            .Where(a => a.VehicleModelId == vehicleModelId &&
                                                        a.CityId == cityId &&
                                                        a.Price >= minPrice &&
                                                        a.Price <= maxPrice &&
                                                        a.Year >= yearFrom &&
                                                        a.Year <= yearTo);

            return adverts;
        }

        public void UpdateAdvert(Advert advert)
        {
            this.advertDataProvider.Update(advert);
            this.advertDataProvider.SaveChanges();
        }

        public IQueryable<Advert> GetAllAdvertsByUserId(string userId)
        {
            var adverts = this.advertDataProvider
                .All()
                .Where(a => a.UserId == userId);

            return adverts;
        }
    }
}
