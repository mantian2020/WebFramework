using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Shop.Template.Model;

namespace Shop.Template.Controllers
{
    public class TemplateController:Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult LeftMenu()
        {
            List<MenuEntity> lstMenu = new List<MenuEntity>();
            lstMenu.Add(new MenuEntity() { Name = "权限管理", Url = "template/index" });
            lstMenu.Add(new MenuEntity() { Name = "应用信息", Url = "template/index" });
            return PartialView(lstMenu);
        }
    }
}
