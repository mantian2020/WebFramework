using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CoreFramework.ModelBinder;
using Shop.Module.Model;
using Shop.Module.Services.IServices;

namespace Shop.Module.Controllers
{
    public class ModuleController : Controller
    {
        private readonly IShop_Modules_Services _shop_modules_services;
        public ModuleController(IShop_Modules_Services shop_modules_services)
        {
            _shop_modules_services = shop_modules_services;
        }

        public ActionResult ModuleManage(int? page)
        {
            return View(_shop_modules_services.GetShopModules(page));
        }

        public ActionResult AddShopModules([ModelBinder(typeof(CommonModelBinder<Shop_Modules>))] Shop_Modules module)
        {
            return Content(_shop_modules_services.AddShopModules(module));
        }

        public ActionResult EditModule(int moduleId)
        {
            return View(_shop_modules_services.GetShopModule(moduleId));
        }

        public ActionResult UpdateShopModules([ModelBinder(typeof(CommonModelBinder<Shop_Modules>))] Shop_Modules module)
        {
            return Content(_shop_modules_services.UpdateShopModules(module));
        }

        public ActionResult DeleteShopModules(int moduleId)
        {
            return Content(_shop_modules_services.DeleteShopModules(moduleId));
        }
    }
}
