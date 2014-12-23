using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CoreFramework.Enum;

namespace Shop.Template
{
    public class TemplateAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return ProjectName.Template; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            string[] controllerNamespaces = new string []{ "Shop." + ProjectName.Template + ".Controllers" };
            context.MapRoute("TemplateDefault"
                , ProjectName.Template + "/{controller}/{action}"
                , new { controller = "Template", action = "Login" }
                , null, controllerNamespaces);
            context.MapRoute("Template_Login"
                , ProjectName.Template + "/{controller}/{action}/{userName}/{password}"
                , new { controller = "Template", action = "CheckLogin", userName = UrlParameter.Optional, password = UrlParameter.Optional }
                , null, controllerNamespaces);
        }
    }
}
