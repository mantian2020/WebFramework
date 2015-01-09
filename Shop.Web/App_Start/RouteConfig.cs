using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CoreFramework.Enum;

namespace Shop.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Template", action = "Login", id = UrlParameter.Optional },
                constraints:null,
                namespaces: new string[] { "Shop." + ProjectName.Template + ".Controllers" }
            );
        }
    }
}