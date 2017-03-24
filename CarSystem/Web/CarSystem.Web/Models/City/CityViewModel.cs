using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.City
{
    public class CityViewModel : IMapFrom<Data.Models.City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}