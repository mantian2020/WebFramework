using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.Infrastructure.Interfaces;
using Shop.Module.Model;

namespace Shop.Module.DAL.IDAL
{
    public interface IShop_Modules_DAL:IDependency
    {
        int AddShopModules(Shop_Modules model);
        bool UpdateShopModules(Shop_Modules model);
        bool DeleteShopModules(int moduleId);
        List<Shop_Modules> GetShopModules();
        Shop_Modules GetShopModule(int moduleId);
    }
}
