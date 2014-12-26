using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper.Entity;
using CoreFramework.Infrastructure.Interfaces;
using Shop.Template.Model;

namespace Shop.Template.Services.IServices
{
    public interface IShop_Menu_Services: IDependency
    {
        List<Shop_Menu> GetUserMenus(int shop_RoleId);
        /// <summary>
        /// 根据菜单ID，获取一条菜单
        /// </summary>
        /// <param name="shop_MenuId"></param>
        /// <returns></returns>
        Shop_Menu GetShopMenu(int shop_MenuId);
        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        string UpdateMenu(Shop_Menu menu);

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        string AddMenu(Shop_Menu menu);
    }
}
