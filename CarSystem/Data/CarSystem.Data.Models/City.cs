using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CarSystem.Data.Models.Contracts;
using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models
{
    public class City : ICity
    {
        private ICollection<Advert> adverts;

        public City()
        {
            this.adverts = new HashSet<Advert>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ModelsValidationConstants.CityNameMinLength)]
        [MaxLength(ModelsValidationConstants.CityNameMaxLength)]
        public string Name { get; set; }

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
