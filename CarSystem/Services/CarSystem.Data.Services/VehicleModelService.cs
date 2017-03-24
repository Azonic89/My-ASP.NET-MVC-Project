using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IEfCarSystemDbSetCocoon<VehicleModel> vehicleModelDbSetCocoon;

        public VehicleModelService(IEfCarSystemDbSetCocoon<VehicleModel> vehicleModelDbSetCocoon)
        {
            Guard.WhenArgument(vehicleModelDbSetCocoon, nameof(vehicleModelDbSetCocoon)).IsNull().Throw();

            this.vehicleModelDbSetCocoon = vehicleModelDbSetCocoon;
        }

        public IQueryable<VehicleModel> GetAllVehicleModels()
        {
            return this.vehicleModelDbSetCocoon.All();
        }

        public VehicleModel GetById(int id)
        {
            return this.vehicleModelDbSetCocoon.GetById(id);
        }
    }
}
