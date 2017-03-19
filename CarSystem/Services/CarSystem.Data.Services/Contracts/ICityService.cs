using System.Linq;

using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Contracts
{
    public interface ICityService
    {
        IQueryable<City> GetAllCities();

        City GetById(int id);
    }
}