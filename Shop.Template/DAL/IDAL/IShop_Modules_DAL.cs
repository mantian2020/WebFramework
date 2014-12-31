using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Infrastructure.Interfaces;
using Shop.Template.Model;

namespace Shop.Template.DAL.IDAL
{
    public interface IShop_Modules_DAL : IDependency
    {
        /// <summary>
        /// 获取有效的模块
        /// </summary>
        /// <returns></returns>
        List<Shop_Modules> GetModules();

    }
}
