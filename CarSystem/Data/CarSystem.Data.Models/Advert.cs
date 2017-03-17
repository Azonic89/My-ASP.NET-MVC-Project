using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CarSystem.Data.Models.Contracts;
using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models
{
    public class Advert : IAdvert
    {
        private ICollection<AdvertImage> advertImages;

        public Advert()
        {
            this.advertImages = new HashSet<AdvertImage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelsValidationConstants.AdvertTitleMinLength)]
        [MaxLength(ModelsValidationConstants.AdvertTitleMaxLength)]
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public int VehicleModelId { get; set; }

        [ForeignKey("VehicleModelId")]
        public virtual VehicleModel VehicleModel { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public int DistanceCoverage { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [Required]
        [MinLength(ModelsValidationConstants.AdvertDescriptionMinLength)]
        [MaxLength(ModelsValidationConstants.AdvertDescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<AdvertImage> AdvertImages
        {
            get { return this.advertImages; }
            set { this.advertImages = value; }
        }
    }
}
