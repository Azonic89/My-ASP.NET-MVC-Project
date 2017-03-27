using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;

using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture.Contracts;
using CarSystem.Web.Models.Advert;
using CarSystem.Web.Models.City;
using CarSystem.Web.Models.VehicleModel;

namespace CarSystem.Web.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertService advertService;
        private readonly IMappingService mappingService;
        private readonly IVehicleModelService vehicleModelService;
        private readonly ICityService cityService;

        public AdvertController(
            IAdvertService advertService,
            IMappingService mappingService,
            IVehicleModelService vehicleModelService,
            ICityService cityService)
        {
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();
            Guard.WhenArgument(mappingService, nameof(mappingService)).IsNull().Throw();
            Guard.WhenArgument(vehicleModelService, nameof(vehicleModelService)).IsNull().Throw();
            Guard.WhenArgument(cityService, nameof(cityService)).IsNull().Throw();

            this.advertService = advertService;
            this.mappingService = mappingService;
            this.vehicleModelService = vehicleModelService;
            this.cityService = cityService;
        }
        
        [HttpGet]
        public ActionResult Index(AdvertSearchViewModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!this.ModelState.IsValid)
            {
                this.TempData["Notification"] = "Exception.";

                return RedirectToAction("Index", "Home");
            }

            try
            {
                var adverts = advertService.Search(
                    model.VehicleModelId,
                    model.CityId,
                    model.MinYear,
                    model.MaxYear,
                    model.MinPrice,
                    model.MaxPrice,
                    model.MinPower,
                    model.MaxPower,
                    model.MinDistanceCoverage,
                    model.MaxDistanceCoverage)
                 .OrderBy(a => a.Id)
                 .ProjectTo<AdvertDetailViewModel>().ToList();

                return View(adverts);
            }

            catch (Exception e)
            {
                this.TempData["Notification"] = "Exception.";

                return RedirectToAction("Index", "Home");

            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var vehicleModels = vehicleModelService.GetAllVehicleModels().ProjectTo<VehicleModelViewModel>().ToList();
            var cities = cityService.GetAllCities().ProjectTo<CityViewModel>().ToList();

            ViewBag.VehicleModels = new SelectList(vehicleModels, "Id", "Name");
            ViewBag.Cities = new SelectList(cities, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(AdvertCreateViewModel model, IEnumerable<HttpPostedFileBase> uploadedFiles)
        {
            Guard.WhenArgument(model, nameof(model)).IsNull().Throw();

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var advert = new Advert()
            {
                Title = model.Title,
                VehicleModelId = model.VehicleModelId,
                UserId = this.User.Identity.GetUserId(),
                Year = model.Year,
                Price = model.Price,
                Power = model.Power,
                DistanceCoverage = model.DistanceCoverage,
                CityId = model.CityId,
                Description = model.Description,
            };

            try
            {
                this.advertService.CreateAdvert(advert, uploadedFiles);
            }
            catch (Exception)
            {
                this.TempData["Notification"] = "Exception.";
                return View(model);
            }


            this.TempData["Notification"] = "Successfully Created An Advert!!!";

            return Redirect("/");
        }

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var advert = this.advertService.GetById(id);

            if (advert == null)
            {
                return HttpNotFound();
            }

            var advertView = this.mappingService.Map<AdvertDetailViewModel>(advert);

            return View(advertView);
        }
    }
}