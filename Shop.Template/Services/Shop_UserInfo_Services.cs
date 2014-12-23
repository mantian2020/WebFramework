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
    class Shop_UserInfo_Services : IShop_UserInfo_Services
    {
        public Model.Shop_UserInfo GetUserInfo(string userName, string password)
        {
           IShop_UserInfo_DAL dal = new Shop_UserInfo_DAL();
            return dal.GetUserInfo(userName, password);
        }
    }
}
