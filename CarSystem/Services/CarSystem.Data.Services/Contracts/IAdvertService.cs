using System.Linq;

using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Contracts
{
    public interface IAdvertService
    {
        void AddAdvert(Advert advertToAdd);

        void DeleteAdvert(Advert advertToDelete);

        void DeleteAdvertById(object advertId);

        IQueryable<Advert> GetAdvertsByMultipleParameters(int vehicleModelId, int cityId, int minPrice, int maxPrice, int yearFrom, int yearTo);

        IQueryable<Advert> GetAllAdverts();

        IQueryable<Advert> GetAllAdvertsByUserId(string userId);

        Advert GetById(int id);

        void UpdateAdvert(Advert advert);
    }
}