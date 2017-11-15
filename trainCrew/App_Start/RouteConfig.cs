using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace trainCrew
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                 name: "Menu",
                url: "{controller}/{action}/{name}"
       );
            routes.MapRoute(
               name: "SystemUser",
               url: "{controller}/{action}/{name}/{id}"
     );
            routes.MapRoute(
                name: "Driver",
               url: "{controller}/{action}/{id}"
      );

        }
    }
}
