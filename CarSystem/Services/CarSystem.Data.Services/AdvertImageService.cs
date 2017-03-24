using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class AdvertImageService : IAdvertImageService
    {
        private readonly IEfCarSystemDbSetCocoon<AdvertImage> advertDbSetCocoon;

        public AdvertImageService(IEfCarSystemDbSetCocoon<AdvertImage> advertDbSetCocoon)
        {
            Guard.WhenArgument(advertDbSetCocoon, nameof(advertDbSetCocoon)).IsNull().Throw();

            this.advertDbSetCocoon = advertDbSetCocoon;
        }

        public IQueryable<AdvertImage> GetAdvertImagesByAdvertId(int advertId)
        {
            var advertImages = this.advertDbSetCocoon
                                                .All()
                                                .Where(p => p.AdvertImageId == advertId);

            return advertImages;
        }
    }
}
