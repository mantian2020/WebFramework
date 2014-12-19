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
            get { return ProjectName.Authority; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            string[] controllerNamespaces = new[] { "Shop." + ProjectName.Template + ".Controllers" };
            context.MapRoute("TemplateDefault"
                , ProjectName.Template + "/{controller}/{action}"
                , new { controller = "Template", action = "Login" }
                , null, controllerNamespaces);
        }
    }
}
