using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.Manufacturer
{
    public class ManufacturerViewModel : IMapFrom<Data.Models.Manufacturer>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}