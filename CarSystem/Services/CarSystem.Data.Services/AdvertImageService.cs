using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class AdvertImageService : IAdvertImageService
    {
        private readonly IEfCarSystemDataProvider<AdvertImage> advertImageDataProvider;

        public AdvertImageService(IEfCarSystemDataProvider<AdvertImage> advertImageDataProvider)
        {
            Guard.WhenArgument(advertImageDataProvider, nameof(advertImageDataProvider)).IsNull().Throw();

            this.advertImageDataProvider = advertImageDataProvider;
        }

        public IQueryable<AdvertImage> GetAdvertImagesByAdvertId(int advertId)
        {
            var advertImages = this.advertImageDataProvider
                                                .All()
                                                .Where(p => p.AdvertImageId == advertId);

            return advertImages;
        }
    }
}
