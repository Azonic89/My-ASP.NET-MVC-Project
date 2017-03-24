using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class AdvertImageService : IAdvertImageService
    {
        private readonly IEfCarSystemDbSetCocoon<AdvertImage> advertImageDbSetCocoon;

        public AdvertImageService(IEfCarSystemDbSetCocoon<AdvertImage> advertDbSetCocoon)
        {
            Guard.WhenArgument(advertDbSetCocoon, nameof(advertDbSetCocoon)).IsNull().Throw();

            this.advertImageDbSetCocoon = advertDbSetCocoon;
        }

        public IQueryable<AdvertImage> GetAdvertImagesByAdvertId(int advertId)
        {
            var advertImages = this.advertImageDbSetCocoon
                                                .All()
                                                .Where(p => p.AdvertImageId == advertId);

            return advertImages;
        }

        public AdvertImage GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var image = this.advertImageDbSetCocoon.GetById(id);

            return image;
        }
    }
}
