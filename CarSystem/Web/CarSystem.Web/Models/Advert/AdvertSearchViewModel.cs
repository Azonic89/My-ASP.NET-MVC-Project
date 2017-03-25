using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSystem.Web.Models.Advert
{
    public class AdvertSearchViewModel
    {
        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public int VehicleModelId { get; set; }

        public int CityId { get; set; }

        public int MinYear { get; set; }
        public int MaxYear { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public int MinPower { get; set; }
        public int MaxPower { get; set; }

        public int MinDistanceCoverage { get; set; }
        public int MaxDistanceCoverage { get; set; }
    }
}