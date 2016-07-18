using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace zabawa_z_gitem
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "PrepareData2",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Search", action = "Index" }
            //    );
            //routes.MapRoute(
            //    name: "PrepareData",
            //    url: "{action}",
            //    defaults: new {controller = "Home", action = "Index"}
            //    );
            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action="HowItWorks", id = UrlParameter.Optional }
            );
        }
    }
}
