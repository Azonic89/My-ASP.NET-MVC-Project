using System.Linq;

using Bytes2you.Validation;

using CarSystem.Data.Contracts;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;

namespace CarSystem.Data.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IEfCarSystemDataProvider<VehicleModel> vehicleModelDataProvider;

        public VehicleModelService(IEfCarSystemDataProvider<VehicleModel> vehicleModelDataProvider)
        {
            Guard.WhenArgument(vehicleModelDataProvider, nameof(vehicleModelDataProvider)).IsNull().Throw();

            this.vehicleModelDataProvider = vehicleModelDataProvider;
        }

        public IQueryable<VehicleModel> GetAllVehicleModels()
        {
            return this.vehicleModelDataProvider.All();
        }

        public VehicleModel GetById(int id)
        {
            return this.vehicleModelDataProvider.GetById(id);
        }
    }
}
