using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class CityService : ICityService
    {
        private readonly IEfCarSystemDataProvider<City> cityDataProvider;

        public CityService(IEfCarSystemDataProvider<City> cityDataProvider)
        {
            Guard.WhenArgument(cityDataProvider, nameof(cityDataProvider)).IsNull().Throw();

            this.cityDataProvider = cityDataProvider;
        }

        public IQueryable<City> GetAllCities()
        {
            return this.cityDataProvider.All();
        }

        public City GetById(int id)
        {
            return this.cityDataProvider.GetById(id);
        }
    }
}
