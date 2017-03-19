using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IEfCarSystemDataProvider<Manufacturer> manufacturerDataProvider;

        public ManufacturerService(IEfCarSystemDataProvider<Manufacturer> manufacturerDataProvider)
        {
            Guard.WhenArgument(manufacturerDataProvider, nameof(manufacturerDataProvider)).IsNull().Throw();

            this.manufacturerDataProvider = manufacturerDataProvider;
        }

        public IQueryable<Manufacturer> GetAllManufacturers()
        {
            return this.manufacturerDataProvider.All();
        }

        public Manufacturer GetById(int id)
        {
            return this.manufacturerDataProvider.GetById(id);
        }
    }
}
