using System.Linq;

using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Contracts
{
    public interface IManufacturerService
    {
        IQueryable<Manufacturer> GetAllManufacturers();

        Manufacturer GetById(int id);
    }
}