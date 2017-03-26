using System.Collections.Generic;
using CarSystem.Data.Models;

namespace CarSystem.Web.Areas.Admin.Models
{
    public class AllAdvertsViewModel
    {
        public ICollection<AdvertViewModel> AllAdverts { get; set; }
    }
}