using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSystem.Web.Models.Advert
{
    public class AdvertCreateViewModel
    {
        public string Title { get; set; }

        public int VehicleModelId { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Power { get; set; }

        public int DistanceCoverage { get; set; }

        public int CityId { get; set; }

        public string Description { get; set; }

        public IEnumerable<AdvertImageViewModel> FilesToBeUploaded { get; set; }
    }
}