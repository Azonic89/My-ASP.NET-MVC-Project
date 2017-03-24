using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.Category
{
    public class CategoryViewModel : IMapFrom<Data.Models.Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}