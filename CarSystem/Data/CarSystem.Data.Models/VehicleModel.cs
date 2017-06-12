using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CarSystem.Data.Models.Contracts;
using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models
{
    public class VehicleModel : IVehicleModel
    {
        private ICollection<Advert> adverts;

        public VehicleModel()
        {
            this.adverts = new HashSet<Advert>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ModelsValidationConstants.VechicleNameMinLength)]
        [MaxLength(ModelsValidationConstants.VechicleNameMaxLength)]
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer Manufacturer { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Advert> Adverts
        {
            get
            {
                return this.adverts;
            }

            set
            {
                this.adverts = value;
            }
        }
    }
}
