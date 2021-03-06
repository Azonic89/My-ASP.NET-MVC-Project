﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarSystem.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Display advert",
                url: "adverts/{id}/{url}",
                defaults: new { controller = "Advert", action = "Detail" },
                namespaces: new [] { "CarSystem.Web.Controllers "}
                );

            routes.MapRoute(
                name: "Adverts list",
                url: "adverts/{model}/{id}",
                defaults: new { controller = "Advert", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CarSystem.Web.Controllers " }


            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { "CarSystem.Web.Controllers "}
            );
        }
    }
}
