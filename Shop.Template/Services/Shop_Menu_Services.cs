using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using CommonHelper.Entity;
using CoreFramework.Services;
using Shop.Template.DAL.IDAL;
using Shop.Template.Model;
using Shop.Template.Services.IServices;

namespace Shop.Template.Services
{
    public class Shop_Menu_Services : IShop_Menu_Services
    {
        private readonly IShop_Menu_DAL _shop_menu_dal;
        public Shop_Menu_Services(IShop_Menu_DAL shop_menu_dal)
        {
            _shop_menu_dal = shop_menu_dal;
        }

        public List<Model.Shop_Menu> GetUserMenus(long shop_RoleId, string moduleIds)
        {
            return _shop_menu_dal.GetUserMenus(shop_RoleId, moduleIds);
        }

        public Model.Shop_Menu GetShopMenu(int shop_MenuId)
        {
            return _shop_menu_dal.GetShopMenu(shop_MenuId);
        }


        public string UpdateMenu(Model.Shop_Menu menu)
        {
            menu.Shop_MenuCreator = LoginServices.LoginUserName;
            bool result = _shop_menu_dal.UpdateMenu(menu);
            ResultInfo<string> resultInfo = new ResultInfo<string>();
            resultInfo.Success = result;
            if (result)
            {
                resultInfo.Msg = "更新成功";
            }
            else
            {
                resultInfo.Msg = "更新失败";
            }
            return SerializeHelper.SerializeData(resultInfo);
        }


        public string AddMenu(Model.Shop_Menu menu)
        {
            menu.Shop_MenuCreator = LoginServices.LoginUserName;
           int menuId = _shop_menu_dal.AddMenu(menu);
           ResultInfo<string> resultInfo = new ResultInfo<string>();
           if (menuId >0)
           {
               resultInfo.Success = true;
               resultInfo.Msg = "添加成功";
           }
           else
           {
               resultInfo.Success = false;
               resultInfo.Msg = "添加失败";
           }
           return SerializeHelper.SerializeData(resultInfo);
        }


        public string DeleteMenu(int shop_MenuId)
        {
            bool result = _shop_menu_dal.DeleteMenu(shop_MenuId);
            ResultInfo<string> resultInfo = new ResultInfo<string>();
            resultInfo.Success = result;
            if (result)
            {
                resultInfo.Msg = "删除成功";
            }
            else
            {
                resultInfo.Msg = "删除失败";
            }
            return SerializeHelper.SerializeData(resultInfo);
        }


        public PageInfo<Model.Shop_Menu> GetAllMenus(int? page)
        {
            int currentIndex = 1;
            currentIndex = page ?? 1;
            int pageSize = 10;
            List<Shop_Menu> lstMenus = _shop_menu_dal.GetAllMenus();
            List<Shop_Menu> tempMenus = lstMenus.Skip((currentIndex - 1) * pageSize).Take(pageSize).ToList();

            PageInfo<Model.Shop_Menu> pageInfo = new PageInfo<Model.Shop_Menu>();
            pageInfo.PageIndex = currentIndex;
            pageInfo.PageSize = pageSize;
            pageInfo.TotalCount = lstMenus.Count;
            pageInfo.Items = tempMenus;
            return pageInfo;
        }
    }
}
