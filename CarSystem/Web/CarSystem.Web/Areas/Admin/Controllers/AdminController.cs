using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Areas.Admin.Models;

namespace CarSystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdvertService advertService;

        public AdminController(IAdvertService advertService)
        {
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();

            this.advertService = advertService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllAdverts()
        {
            var adverts = this.advertService.GetAllAdverts().ToList();
            var model = new AllAdvertsViewModel { AllAdverts = new Collection<AdvertViewModel>() };

            foreach (var advert in adverts)
            {
                var modelAdvert = new AdvertViewModel
                {
                    Title = advert.Title,
                    Price = advert.Price,
                    Description = advert.Description,
                    Year = advert.Year,
                    Id = advert.Id,
                    Power = advert.Power,
                    DistanceCoverage = advert.DistanceCoverage
                };

                model.AllAdverts.Add(modelAdvert);
            }

            return Json(model.AllAdverts, JsonRequestBehavior.AllowGet);
        }

        public string UpdateAdvert(AdvertViewModel advertViewModel)
        {
            var advert = this.advertService.GetById(advertViewModel.Id);

            this.ConvertToAdvert(advertViewModel, advert);

            var msg = "Update Advert Successfully!";
            if (ModelState.IsValid)
            {
                this.advertService.UpdateAdvert(advert);
            }
            else
            {
                msg = "Invalid Model State!!!";
            }

            return msg;
        }

        public string DeleteAdvert(AdvertViewModel advertViewModel)
        {
            var advert = this.advertService.GetById(advertViewModel.Id);

            this.ConvertToAdvert(advertViewModel, advert);


            var msg = "Deleted Advert Succefully";
            if (ModelState.IsValid)
            {
                this.advertService.DeleteAdvertById(advert.Id);
            }
            else
            {
                msg = "nvalid Model State!!!";
            }

            return msg;
        }

        private void ConvertToAdvert(AdvertViewModel advertViewModel, Advert advert)
        {
            advert.Title = advertViewModel.Title;
            advert.Price = advertViewModel.Price;
            advert.Description = advertViewModel.Description;
            advert.Year = advertViewModel.Year;
            advert.Power = advertViewModel.Power;
            advert.DistanceCoverage = advertViewModel.DistanceCoverage;

        }
    }
}