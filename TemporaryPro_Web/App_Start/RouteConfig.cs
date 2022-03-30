using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TemporaryPro_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // routes.MapRoute("AddContollerRoute", "Arae/{action}/{id}/{*catchall}", new { controller = "QrC", action = "Index", id = UrlParameter.Optional }, new[] { "URLsAndRoutes.AdditionalControllers" });

            routes.MapRoute(
                name: "myRout",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "QrCodeInfo", action = "QrFormInfo", id = UrlParameter.Optional }
            );
     
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
