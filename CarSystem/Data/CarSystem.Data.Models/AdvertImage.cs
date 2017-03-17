using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSystem.Data.Models
{
    public class AdvertImage
    {
        [Key]
        public int Id { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageName { get; set; }

        public int AdvertImageId { get; set; }

        [ForeignKey("AdvertImageId")]
        public virtual Advert Advert { get; set; }
    }
}
