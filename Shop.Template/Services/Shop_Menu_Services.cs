using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Template.DAL.IDAL;
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

        public List<Model.Shop_Menu> GetUserMenus(int shop_RoleId)
        {
            return _shop_menu_dal.GetUserMenus(shop_RoleId);
        }
    }
}
