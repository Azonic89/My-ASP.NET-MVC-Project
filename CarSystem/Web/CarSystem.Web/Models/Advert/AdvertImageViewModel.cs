using CarSystem.Data.Models;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.Advert
{
    public class AdvertImageViewModel : IMapFrom<AdvertImage>
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public byte[] ImageData { get; set; }
    }
}