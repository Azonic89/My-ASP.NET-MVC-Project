using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
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

        public AdvertController(IAdvertService advertService, IMappingService mappingService)
        {
            Guard.WhenArgument(advertService, nameof(advertService)).IsNull().Throw();

            this.advertService = advertService;
        }
        // GET: Advert
        public ActionResult Index()
        {
            return View();
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
                Description = model.Description
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
    }
}