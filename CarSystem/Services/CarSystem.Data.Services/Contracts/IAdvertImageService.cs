using System.Linq;

using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Contracts
{
    public interface IAdvertImageService
    {
        IQueryable<AdvertImage> GetAdvertImagesByAdvertId(int advertId);
    }
}