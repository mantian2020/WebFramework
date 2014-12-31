using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using CommonHelper.Entity;
using CoreFramework.Services;
using Shop.Template.DAL;
using Shop.Template.DAL.IDAL;
using Shop.Template.Model;
using Shop.Template.Services.IServices;
using SSOFramework;

namespace Shop.Template.Services
{
    public class Shop_UserInfo_Services : IShop_UserInfo_Services
    {
        private readonly IShop_UserInfo_DAL _shop_userInfo_dal;
        private readonly IShop_Menu_DAL _shop_menu_dal;
        public Shop_UserInfo_Services(IShop_UserInfo_DAL shop_userInfo_dal, IShop_Menu_DAL shop_menu_dal)
        {
            _shop_userInfo_dal = shop_userInfo_dal;
            _shop_menu_dal = shop_menu_dal;
        }

        public Model.Shop_UserInfo GetUserInfo(string userName, string password)
        {
           return _shop_userInfo_dal.GetUserInfo(userName, password);
        }


        public string CheckLogin(string userName, string password)
        {
            ResultInfo<string> result = new ResultInfo<string>();
            Shop_UserInfo userInfo = _shop_userInfo_dal.GetUserInfo(userName, password);
            string moduleIds = ModuleServices.GetModulesIds();
            List<Shop_Menu> lstMenus = _shop_menu_dal.GetUserMenus(userInfo.Shop_UserRoleList,moduleIds);
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
                                menu.SecondMenus.Add(new Menu() { Name = o.Shop_MenuName, Url = o.Shop_MenuUrl });
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
    }
}
