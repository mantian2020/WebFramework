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

namespace Shop.Template.Controllers
{
    public class TemplateController : CommonController
    {
        private readonly IShop_UserInfo_Services _shop_userinfo_services;
        public TemplateController(IShop_UserInfo_Services shop_userinfo_services)
        {
            _shop_userinfo_services = shop_userinfo_services;
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
        /// 异步用户登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string CheckLogin(string userName, string password)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            Shop_UserInfo userInfo = _shop_userinfo_services.GetUserInfo(userName, password);
            if (userInfo != null)
            {
                LoginServices.Login(userInfo.Shop_UserName, null);
                result.Success = true;
                result.Msg = "登录成功";
            }
            return SerializeHelper.SerializeData<ResultInfo<string>>(result);
        }

        [LoginFilter(Message = "Template_Index")]
        public ActionResult Index()
        {
            return View();
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
