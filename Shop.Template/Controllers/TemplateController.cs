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
        public TemplateController(IShop_UserInfo_Services shop_userinfo_services
                                ,IShop_Menu_Services shop_menu_services)
        {
            _shop_userinfo_services = shop_userinfo_services;
            _shop_menu_services = shop_menu_services;
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
        public ActionResult MenuManage()
        {
            return View();
        }

        /// <summary>
        /// 异步用户登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string CheckLogin(string userName, string password)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            Shop_UserInfo userInfo = _shop_userinfo_services.GetUserInfo(userName, password);
            List<Shop_Menu> lstMenus = _shop_menu_services.GetUserMenus(0);
            //获取一级菜单
            List<Shop_Menu> lstFirstMenus = lstMenus.Where(o => o.Shop_ParentId == 0).ToList();
            //封装用户菜单
            List<Menu> lstUserMenus = new List<Menu>();
            if (lstFirstMenus != null && lstFirstMenus.Count > 0)
            {
                foreach (Shop_Menu item in lstFirstMenus)
                {
                    Menu menu = new Menu();
                    menu.Name = item.Shop_MenuName;
                    menu.Url = item.Shop_MenuUrl;
                    menu.SecondMenus = new List<Menu>();
                    menu.MenuUrls = new List<string>();
                    menu.MenuUrls.Add(menu.Url);
                    //获取二级菜单
                    var temp = lstMenus.Where(o => o.Shop_ParentId == item.Shop_MenuId).ToList();
                    if (temp.Count > 0)
                    {
                        temp.ForEach(
                            o =>
                            {
                                menu.SecondMenus.Add(new Menu() {Name = o.Shop_MenuName, Url = o.Shop_MenuUrl});
                                menu.MenuUrls.Add(o.Shop_MenuUrl);
                            });
                        menu.HaveSecondMenus = true;
                    }
                    else
                    {
                        menu.HaveSecondMenus = false;
                    }
                    lstUserMenus.Add(menu);
                }
            }
            if (userInfo != null)
            {
                LoginServices.Login(userInfo.Shop_UserName, lstUserMenus);
                result.Success = true;
                result.Msg = "登录成功";
            }
            return SerializeHelper.SerializeData<ResultInfo<string>>(result);
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
