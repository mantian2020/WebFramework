using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Template.DAL;
using Shop.Template.DAL.IDAL;
using Shop.Template.Services.IServices;

namespace Shop.Template.Services
{
    public class Shop_UserInfo_Services : IShop_UserInfo_Services
    {
        private readonly IShop_UserInfo_DAL _shop_userInfo_dal;
        public Shop_UserInfo_Services(IShop_UserInfo_DAL shop_userInfo_dal)
        {
            _shop_userInfo_dal = shop_userInfo_dal;
        }

        public Model.Shop_UserInfo GetUserInfo(string userName, string password)
        {
           return _shop_userInfo_dal.GetUserInfo(userName, password);
        }
    }
}
