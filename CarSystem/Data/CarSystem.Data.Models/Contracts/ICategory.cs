using System.Collections.Generic;

namespace CarSystem.Data.Models.Contracts
{
    public interface ICategory
    {
        int Id { get; set; }

        string Name { get; set; }

        ICollection<VehicleModel> VehicleModels { get; set; }
    }
}