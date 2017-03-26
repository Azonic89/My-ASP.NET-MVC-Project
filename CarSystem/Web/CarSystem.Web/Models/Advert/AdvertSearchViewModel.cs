using System.ComponentModel.DataAnnotations;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.Advert
{
    public class AdvertSearchViewModel 
    {
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Manufacturer")]
        public int? ManufacturerId { get; set; }

        [Display(Name = "Vehicle Model")]
        public int? VehicleModelId { get; set; }

        [Display(Name = "City")]
        public int? CityId { get; set; }

        [Display(Name = "Year From")]
        public int? MinYear { get; set; }

        [Display(Name = "Year To")]
        public int? MaxYear { get; set; }

        [Display(Name = "Price From")]
        public decimal? MinPrice { get; set; }

        [Display(Name = "Price to")]
        public decimal? MaxPrice { get; set; }

        [Display(Name = "Power From")]
        public int? MinPower { get; set; }

        [Display(Name = "Power To")]
        public int? MaxPower { get; set; }

        [Display(Name = "Distance Coverage From")]       
        public int? MinDistanceCoverage { get; set; }

        [Display(Name = "Distance Coverage To")]
        public int? MaxDistanceCoverage { get; set; }
    }
}