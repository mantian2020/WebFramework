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
            context.MapRoute("Module_ModuleManage"
                , ProjectName.Module + "/Module/ModuleManage/{page}"
                , new { controller = "Module", action = "ModuleManage", page = UrlParameter.Optional }
                , null, controllerNamespaces);
            context.MapRoute("Module_EditModule"
                , ProjectName.Module + "/Module/EditModule/{moduleId}"
                , new { controller = "Module", action = "EditModule", moduleId = UrlParameter.Optional }
                , null, controllerNamespaces);
            context.MapRoute("Module_DeleteShopModules"
                , ProjectName.Module + "/Module/DeleteShopModules/{moduleId}"
                , new { controller = "Module", action = "DeleteShopModules", moduleId = UrlParameter.Optional }
                , null, controllerNamespaces);
            context.MapRoute("Module_Default"
                , ProjectName.Module + "/{controller}/{action}"
                , new { controller = "Module", action = "ModuleManage" }
                , null, controllerNamespaces);
        }
        
    }
}
