using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarSystem.Web.Models.Advert
{
    public class AdvertImageViewModel
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public byte[] ImageData { get; set; }
    }
}