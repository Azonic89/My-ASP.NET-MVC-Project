using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.Advert
{
    public class AdvertCreateViewModel : IMapFrom<Data.Models.Advert>
    {
        public string Title { get; set; }

        [Display(Name = "Vehicle Model")]
        public int VehicleModelId { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Power { get; set; }

        [Display(Name = "Distance Coverage")]
        public int DistanceCoverage { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        public string Description { get; set; }

        public IEnumerable<AdvertImageViewModel> FilesToBeUploaded { get; set; }
    }
}