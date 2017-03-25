using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IEfCarSystemDbSetCocoon<Advert> advertDbSetCocoon;
        private readonly ICarSystemEfDbContextSaveChanges carSystemEfDbContextSaveChanges;

        public AdvertService(IEfCarSystemDbSetCocoon<Advert> advertDbSetCocoon, ICarSystemEfDbContextSaveChanges systemEfDbContextSaveChanges)
        {
            Guard.WhenArgument(advertDbSetCocoon, nameof(advertDbSetCocoon)).IsNull().Throw();
            Guard.WhenArgument(systemEfDbContextSaveChanges, nameof(systemEfDbContextSaveChanges)).IsNull().Throw();

            this.advertDbSetCocoon = advertDbSetCocoon;
            this.carSystemEfDbContextSaveChanges = systemEfDbContextSaveChanges;
        }

        public void AddAdvert(Advert advertToAdd)
        {
            Guard.WhenArgument(advertToAdd, nameof(advertToAdd)).IsNull().Throw();

            this.advertDbSetCocoon.Add(advertToAdd);
            this.carSystemEfDbContextSaveChanges.SaveChanges();
        }

        public void DeleteAdvert(Advert advertToDelete)
        {
            Guard.WhenArgument(advertToDelete, nameof(advertToDelete)).IsNull().Throw();

            this.advertDbSetCocoon.Delete(advertToDelete);
            this.carSystemEfDbContextSaveChanges.SaveChanges();
        }

        public void DeleteAdvertById(object advertId)
        {
            Guard.WhenArgument(advertId, nameof(advertId)).IsNull().Throw();

            this.advertDbSetCocoon.Delete((int)advertId);
            this.carSystemEfDbContextSaveChanges.SaveChanges();
        }

        public IQueryable<Advert> GetAllAdverts()
        {
            return this.advertDbSetCocoon.All();
        }

        public Advert GetById(int? id)
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
            this.carSystemEfDbContextSaveChanges.SaveChanges();
        }

        public IQueryable<Advert> GetAllAdvertsByUserId(string userId)
        {
            var adverts = this.advertDbSetCocoon
                .All()
                .Where(a => a.UserId == userId);

            return adverts;
        }

        public void AddUploadedFilesToAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles)
        {
            Guard.WhenArgument(advert, nameof(advert)).IsNull().Throw();

            if (uploadedFiles != null)
            {
                foreach (HttpPostedFileBase file in uploadedFiles)
                {
                    if (file == null || file.ContentLength <= 0) continue;
                    var advertImage = new AdvertImage
                    {
                        ImageName = Path.GetFileName(file.FileName),
                    };

                    using (var reader = new BinaryReader(file.InputStream))
                    {
                        advertImage.ImageData = reader.ReadBytes(file.ContentLength);
                    }

                    advert.AdvertImages.Add(advertImage);
                }
            }
        }

        public void CreateAdvert(Advert advert, IEnumerable<HttpPostedFileBase> uploadedFiles)
        {
            Guard.WhenArgument(advert, nameof(advert)).IsNull().Throw();

            if (uploadedFiles != null && uploadedFiles.Count() > 0)
            {
                this.AddUploadedFilesToAdvert(advert, uploadedFiles);
            }

            this.advertDbSetCocoon.Add(advert);
            this.carSystemEfDbContextSaveChanges.SaveChanges();
        }

        public IQueryable<Advert> Search(
                int vehicleModelId,
                int cityId,
                int minYear,
                int maxYear,
                decimal minPrice,
                decimal maxPrice,
                int minPower,
                int maxPower,
                int minDistanceCoverage,
                int maxDistanceCoverage)
        {
            var adverts = this.advertDbSetCocoon
                .All();
            //.Where(a => a.VehicleModelId == model.VehicleModelId &&
            //            a.CityId == model.CityId &&
            //            a.Year >= model.MinYear && a.Year <= model.MaxPower &&
            //            a.Price >= model.MinPrice && a.Price <= model.MaxPrice &&
            //            a.Power >= model.MinPower && a.Power <= model.MaxPower &&
            //            a.DistanceCoverage >= model.MinDistanceCoverage &&
            //            a.DistanceCoverage <= model.MaxDistanceCoverage)

            return adverts;
        }
    }
}
