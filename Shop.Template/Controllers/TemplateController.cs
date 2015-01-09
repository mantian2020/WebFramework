using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CommonHelper;
using CommonHelper.Entity;
using CoreFramework.ActionFilters;
using CoreFramework.Controllers;
using CoreFramework.ModelBinder;
using CoreFramework.Services;
using Shop.Template.Model;
using Shop.Template.Services;
using Shop.Template.Services.IServices;
using SSOFramework;

namespace Shop.Template.Controllers
{
    public class TemplateController : CommonController
    {
        private readonly IShop_UserInfo_Services _shop_userinfo_services;
        private readonly IShop_Menu_Services _shop_menu_services;
        private readonly IShop_Modules_Services _shop_modules_services;

        public TemplateController(IShop_UserInfo_Services shop_userinfo_services
                                ,IShop_Menu_Services shop_menu_services
                                , IShop_Modules_Services shop_modules_services)
        {
            _shop_userinfo_services = shop_userinfo_services;
            _shop_menu_services = shop_menu_services;
            _shop_modules_services = shop_modules_services;
        }

        public ActionResult Login()
        {
            if (LoginServices.CheckLogin())
            {
                HttpContext.Response.Redirect("~/template/template/index");
            }
            return View();
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [LoginFilter(Message = "Template_Index")]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 菜单管理页
        /// </summary>
        /// <returns></returns>
        [LoginFilter(Message = "Template_MenuManage")]
        public ActionResult MenuManage(int? page)
        {
            return View(_shop_menu_services.GetAllMenus(page));
        }
        /// <summary>
        /// 编辑菜单
        /// </summary>
        /// <param name="shop_menuId"></param>
        /// <returns></returns>
        [LoginFilter(Message = "Template_EditMenu")]
        public ActionResult EditMenu(int shop_menuId)
        {
            Shop_Menu menu = _shop_menu_services.GetShopMenu(shop_menuId);
            return View(menu);
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="shop_menuId"></param>
        /// <returns></returns>
        public string DeleteMenu(int shop_menuId)
        {
            return _shop_menu_services.DeleteMenu(shop_menuId);
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public ActionResult AddMenu([ModelBinder(typeof (CommonModelBinder<Shop_Menu>))] Shop_Menu menu)
        {
            string result = _shop_menu_services.AddMenu(menu);
            return Content(result);
        }

        /// <summary>
        /// 保存菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateMenu([ModelBinder(typeof(CommonModelBinder<Shop_Menu>))]Shop_Menu menu)
        {
            string result = _shop_menu_services.UpdateMenu(menu);
            return Content(result);
        }

        /// <summary>
        /// 异步用户登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string CheckLogin(string userName, string password)
        {
            ModuleServices.RecordModuleIds(_shop_modules_services.GetModuleIds());
            ModuleServices.RecordModules(_shop_modules_services.GetModules());
            return _shop_userinfo_services.CheckLogin(userName, password);
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        public void SignOut()
        {
            LoginServices.SignOut();
            HttpContext.Response.Redirect("~/template/template/Login");
        }
    }
}
