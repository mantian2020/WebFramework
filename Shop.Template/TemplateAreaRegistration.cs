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
            context.MapRoute("Template_Login"
                , ProjectName.Template + "/Template/CheckLogin/{userName}/{password}"
                , new { controller = "Template", action = "CheckLogin", userName = UrlParameter.Optional, password = UrlParameter.Optional }
                , null, controllerNamespaces);
            context.MapRoute("Template_EditMenu"
                , ProjectName.Template + "/Template/EditMenu/{shop_menuId}"
                , new { controller = "Template", action = "EditMenu", shop_menuId = UrlParameter.Optional}
                , null, controllerNamespaces);
            context.MapRoute("Template_DeleteMenu"
                , ProjectName.Template + "/Template/DeleteMenu/{shop_menuId}"
                , new { controller = "Template", action = "DeleteMenu", shop_menuId = UrlParameter.Optional }
                , null, controllerNamespaces);
            context.MapRoute("Template_MenuManage"
                , ProjectName.Template + "/Template/MenuManage/{page}"
                , new { controller = "Template", action = "MenuManage", page = UrlParameter.Optional }
                , null, controllerNamespaces);
            context.MapRoute("TemplateDefault"
                , ProjectName.Template + "/{controller}/{action}"
                , new { controller = "Template", action = "Login" }
                , null, controllerNamespaces);
        }
    }
}
