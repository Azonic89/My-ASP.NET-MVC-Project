using System;
using System.Collections.Generic;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Repositories;

namespace CarSystem.Data
{
    public class CarSystemData : ICarSystemData
    {
        private readonly ICarSystemDbContext carSystemDbContext;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public CarSystemData(ICarSystemDbContext carSystemDbContext)
        {
            Guard.WhenArgument(carSystemDbContext, nameof(ICarSystemDbContext)).IsNull().Throw();

            this.carSystemDbContext = carSystemDbContext;
        }

        public IEfGenericRepository<Advert> Adverts => this.GetRepository<Advert>();

        public IEfGenericRepository<AdvertImage> AdvertImages => this.GetRepository<AdvertImage>();

        public IEfGenericRepository<User> Users => this.GetRepository<User>();

        public IEfGenericRepository<City> Cities => this.GetRepository<City>();

        public IEfGenericRepository<Category> Categories => this.GetRepository<Category>();

        public IEfGenericRepository<Manufacturer> Manufacterers => this.GetRepository<Manufacturer>();

        public IEfGenericRepository<VehicleModel> VehicleModels => this.GetRepository<VehicleModel>();

        public void SaveChanges()
        {
            this.carSystemDbContext.SaveChanges();
        }

        private IEfGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfGenericRepository<T>);
                return (IEfGenericRepository<T>)(Activator.CreateInstance(type, this.carSystemDbContext));
            }

            return (IEfGenericRepository<T>)this.repositories[typeof(T)];
        }
    }
}
