using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper.Entity;
using CoreFramework.Infrastructure.Interfaces;
using Shop.Module.Model;

namespace Shop.Module.Services.IServices
{
    public interface IShop_Modules_Services : IDependency
    {
        string AddShopModules(Shop_Modules model);
        string UpdateShopModules(Shop_Modules model);
        string DeleteShopModules(int moduleId);
        PageInfo<Model.Shop_Modules> GetShopModules(int? page);
        Shop_Modules GetShopModule(int moduleId);
    }
}
