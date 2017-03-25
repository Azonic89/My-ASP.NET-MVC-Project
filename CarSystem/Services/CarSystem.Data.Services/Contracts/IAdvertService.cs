using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        Advert GetById(int? id);

        void AddUploadedFilesToAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles);

        void CreateAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles);

        void UpdateAdvert(Advert advert);

        IQueryable<Advert> Search(
            int vehicleModelId,
            int cityId,
            int minYear,
            int maxYear,
            decimal minPrice,
            decimal maxPrice,
            int minPower,
            int maxPower,
            int minDistanceCoverage,
            int maxDistanceCoverage);
    }
}