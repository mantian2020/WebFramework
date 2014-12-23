using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CoreFramework.Enum;

namespace Shop.Module
{
    public class ModuleAreaRegistration : AreaRegistration
    {

        public override string AreaName
        {
            get { return ProjectName.Module; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            string[] controllerNamespaces = new[] { "Shop." + ProjectName.Module + ".Controllers" };
            context.MapRoute("ModuleDefault"
                , ProjectName.Module + "/{controller}/{action}"
                , new { controller = "Module", action = "ModuleManage" }
                , null, controllerNamespaces);
        }
        
    }
}
