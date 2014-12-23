using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Infrastructure.Interfaces;
using Shop.Template.Model;

namespace Shop.Template.DAL.IDAL
{
    public interface IShop_UserInfo_DAL:IDependency
    {
        /// <summary>
        /// 校验用户信息是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Shop_UserInfo GetUserInfo(string userName, string password);
    }
}
