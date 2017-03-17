using CarSystem.Data.Models;

namespace CarSystem.Data.Contracts
{
    public interface ICarSystemData
    {
        IEfGenericRepository<Advert> Adverts { get; }

        IEfGenericRepository<AdvertImage> AdvertImages { get; }

        IEfGenericRepository<User> Users { get; }

        IEfGenericRepository<City> Cities { get; }

        IEfGenericRepository<Category> Categories { get; }

        IEfGenericRepository<Manufacturer> Manufacterers { get; }

        IEfGenericRepository<VehicleModel> VehicleModels { get; }

        void SaveChanges();
    }
}
