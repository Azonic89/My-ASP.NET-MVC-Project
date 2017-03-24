using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IEfCarSystemDbSetCocoon<Manufacturer> manufacturerDbSetCocoon;

        public ManufacturerService(IEfCarSystemDbSetCocoon<Manufacturer> manufacturerDbSetCocoon)
        {
            Guard.WhenArgument(manufacturerDbSetCocoon, nameof(manufacturerDbSetCocoon)).IsNull().Throw();

            this.manufacturerDbSetCocoon = manufacturerDbSetCocoon;
        }

        public IQueryable<Manufacturer> GetAllManufacturers()
        {
            return this.manufacturerDbSetCocoon.All();
        }

        public Manufacturer GetById(int id)
        {
            return this.manufacturerDbSetCocoon.GetById(id);
        }
    }
}
