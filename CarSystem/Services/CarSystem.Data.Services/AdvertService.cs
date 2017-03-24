using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IEfCarSystemDbSetCocoon<Advert> advertDbSetCocoon;
        private readonly ICarSystemEfDbContextSaveChanges systemEfDbContextSaveChanges;

        public AdvertService(IEfCarSystemDbSetCocoon<Advert> advertDbSetCocoon, ICarSystemEfDbContextSaveChanges systemEfDbContextSaveChanges)
        {
            Guard.WhenArgument(advertDbSetCocoon, nameof(advertDbSetCocoon)).IsNull().Throw();
            Guard.WhenArgument(systemEfDbContextSaveChanges, nameof(systemEfDbContextSaveChanges)).IsNull().Throw();

            this.advertDbSetCocoon = advertDbSetCocoon;
            this.systemEfDbContextSaveChanges = systemEfDbContextSaveChanges;
        }

        public void AddAdvert(Advert advertToAdd)
        {
            Guard.WhenArgument(advertToAdd, nameof(advertToAdd)).IsNull().Throw();

            this.advertDbSetCocoon.Add(advertToAdd);
            this.systemEfDbContextSaveChanges.SaveChanges();
        }

        public void DeleteAdvert(Advert advertToDelete)
        {
            Guard.WhenArgument(advertToDelete, nameof(advertToDelete)).IsNull().Throw();

            this.advertDbSetCocoon.Delete(advertToDelete);
            this.systemEfDbContextSaveChanges.SaveChanges();
        }

        public void DeleteAdvertById(object advertId)
        {
            Guard.WhenArgument(advertId, nameof(advertId)).IsNull().Throw();

            this.advertDbSetCocoon.Delete((int)advertId);
            this.systemEfDbContextSaveChanges.SaveChanges();
        }

        public IQueryable<Advert> GetAllAdverts()
        {
            return this.advertDbSetCocoon.All();
        }

        public Advert GetById(int id)
        {
            return this.advertDbSetCocoon.GetById(id);
        }

        public IQueryable<Advert> GetAdvertsByMultipleParameters(int vehicleModelId, int cityId, int minPrice, int maxPrice, int yearFrom, int yearTo)
        {
            var adverts = this.advertDbSetCocoon
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
            this.advertDbSetCocoon.Update(advert);
            this.systemEfDbContextSaveChanges.SaveChanges();
        }

        public IQueryable<Advert> GetAllAdvertsByUserId(string userId)
        {
            var adverts = this.advertDbSetCocoon
                .All()
                .Where(a => a.UserId == userId);

            return adverts;
        }
    }
}
