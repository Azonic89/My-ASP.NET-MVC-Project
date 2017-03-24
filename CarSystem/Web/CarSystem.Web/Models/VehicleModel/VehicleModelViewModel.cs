using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.VehicleModel
{
    public class VehicleModelViewModel : IMapFrom<Data.Models.VehicleModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}