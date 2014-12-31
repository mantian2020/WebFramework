using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Infrastructure.Interfaces;
using Shop.Template.Model;

namespace Shop.Template.Services.IServices
{
    public interface IShop_Modules_Services : IDependency
    {
        /// <summary>
        /// 获取有效的模块
        /// </summary>
        /// <returns></returns>
        string GetModules();
        /// <summary>
        /// 获取模块IDs
        /// </summary>
        /// <returns></returns>
        string GetModuleIds();
    }
}
