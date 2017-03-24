using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using CarSystem.Data.Models;

namespace CarSystem.Data.Contracts
{
    public interface ICarSystemEfDbContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Advert> Adverts { get; set; }

        IDbSet<AdvertImage> AdvertImages { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Manufacturer> Manufacturers { get; set; }

        IDbSet<VehicleModel> VehicleModels { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
