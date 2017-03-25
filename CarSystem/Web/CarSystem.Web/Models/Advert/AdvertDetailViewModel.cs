using System;
using System.Collections.Generic;
using CarSystem.Web.Infrastucture.Contracts;

namespace CarSystem.Web.Models.Advert
{
    public class AdvertDetailViewModel : IMapFrom<Data.Models.Advert>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int VehicleModelId { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public int Power { get; set; }

        public int DistanceCoverage { get; set; }

        public int CityId { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string Url => $"/adverts/{this.Id}/{this.Title.ToLower().Replace(" ", "-")}";

        public IEnumerable<AdvertImageViewModel> AdvertImages { get; set; }
    }
}