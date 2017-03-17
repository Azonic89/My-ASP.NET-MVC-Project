using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using CarSystem.Data.Models;

namespace CarSystem.Data.Contracts
{
    public interface ICarSystemDbContext
    {
        DbSet<Advert> Adverts { get; set; }

        DbSet<AdvertImage> AdvertImages { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<City> Cities { get; set; }

        DbSet<Manufacturer> Manufacturers { get; set; }

        DbSet<VehicleModel> VehicleModels { get; set; }

        void SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
