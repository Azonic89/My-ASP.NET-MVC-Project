using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarSystem.Data.Models;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Infrastucture.Contracts;
using CarSystem.Web.Models.Advert;
using Microsoft.AspNet.Identity;

namespace CarSystem.Web.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertService advertService;
        private readonly IMappingService mappingService;

        public AdvertController(IAdvertService advertService, IMappingService mappingService)
        {
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();
            Guard.WhenArgument(mappingService, nameof(mappingService)).IsNull().Throw();

            this.advertService = advertService;
            this.mappingService = mappingService;
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
                    model.MaxDistanceCoverage);

                var adv = adverts.ProjectTo<AdvertDetailViewModel>().ToList();

                return View(adv);
            }
            catch (Exception e)
            {
                this.TempData["Notification"] = "Exeption.";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
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
                //CreatedOn = DateTime.Now
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