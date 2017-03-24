﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using CarSystem.Data.Services.Contracts;
using CarSystem.Web.Models.Category;
using CarSystem.Web.Models.City;
using CarSystem.Web.Models.Manufacturer;
using CarSystem.Web.Models.VehicleModel;

namespace CarSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IVehicleModelService vehicleModelService;
        private readonly IManufacturerService manufacturerService;
        private readonly ICityService cityService;

        public HomeController(ICategoryService categoryService,
            IVehicleModelService vehicleModelService,
            IManufacturerService manufacturerService,
            ICityService cityService)
        {
            Guard.WhenArgument(categoryService, nameof(categoryService)).IsNull().Throw();
            Guard.WhenArgument(vehicleModelService, nameof(vehicleModelService)).IsNull().Throw();
            Guard.WhenArgument(manufacturerService, nameof(manufacturerService)).IsNull().Throw();
            Guard.WhenArgument(cityService, nameof(cityService)).IsNull().Throw();

            this.categoryService = categoryService;
            this.vehicleModelService = vehicleModelService;
            this.manufacturerService = manufacturerService;
            this.cityService = cityService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoryService.GetAllCategories().ProjectTo<CategoryViewModel>().ToList();
            var vehicleModels = vehicleModelService.GetAllVehicleModels().ProjectTo<VehicleModelViewModel>().ToList();
            var manufacturers = manufacturerService.GetAllManufacturers().ProjectTo<ManufacturerViewModel>().ToList();
            var cities = cityService.GetAllCities().ProjectTo<CityViewModel>().ToList();
            var years = this.YearGenerator(1950, DateTime.Now.Year);

            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.Manufacturers = new SelectList(manufacturers, "Id", "Name");
            ViewBag.VehicleModels = new SelectList(vehicleModels, "Id", "Name");
            ViewBag.Cities = new SelectList(cities, "Id", "Name");
            ViewBag.Years = new SelectList(years, "year");

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private IEnumerable<decimal> YearGenerator(decimal min, decimal max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }

            var numbers = new List<decimal>();

            for (decimal i = max; i >= min; i--)
            {
                numbers.Add(i);
            }

            return numbers;
        }
    }
}