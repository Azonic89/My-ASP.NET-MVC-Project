using System.Linq;

using CarSystem.Data.Models;

namespace CarSystem.Data.Services.Contracts
{
    public interface IVehicleModelService
    {
        IQueryable<VehicleModel> GetAllVehicleModels();

        VehicleModel GetById(int id);
    }
}