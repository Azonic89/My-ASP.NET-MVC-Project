using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class CityService : ICityService
    {
        private readonly IEfCarSystemDbSetCocoon<City> cityDbSetCocoon;

        public CityService(IEfCarSystemDbSetCocoon<City> cityDbSetCocoon)
        {
            Guard.WhenArgument(cityDbSetCocoon, nameof(cityDbSetCocoon)).IsNull().Throw();

            this.cityDbSetCocoon = cityDbSetCocoon;
        }

        public IQueryable<City> GetAllCities()
        {
            return this.cityDbSetCocoon.All();
        }

        public City GetById(int id)
        {
            return this.cityDbSetCocoon.GetById(id);
        }
    }
}
