using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using CommonHelper.Entity;
using CoreFramework.Services;
using Shop.Module.DAL.IDAL;
using Shop.Module.Services.IServices;

namespace Shop.Module.Services
{
    public class Shop_Modules_Services : IShop_Modules_Services
    {
        private readonly IShop_Modules_DAL _shop_modules_dal;
        public Shop_Modules_Services(IShop_Modules_DAL shop_modules_dal)
        {
            _shop_modules_dal = shop_modules_dal;
        }

        public string AddShopModules(Model.Shop_Modules model)
        {
            model.Shop_Modules_Creator = LoginServices.LoginUserName;
            int result = _shop_modules_dal.AddShopModules(model);
            ResultInfo<string> resultInfo = new ResultInfo<string>();
            if (result > 0)
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

        public string UpdateShopModules(Model.Shop_Modules model)
        {
            model.Shop_Modules_Creator = LoginServices.LoginUserName;
            bool result = _shop_modules_dal.UpdateShopModules(model);
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

        public string DeleteShopModules(int moduleId)
        {
            bool result = _shop_modules_dal.DeleteShopModules(moduleId);
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


        public PageInfo<Model.Shop_Modules> GetShopModules(int? page)
        {
            int currentIndex = 1;
            currentIndex = page ?? 1;
            int pageSize = 10;
            List<Model.Shop_Modules> lstMenus = _shop_modules_dal.GetShopModules();
            List<Model.Shop_Modules> tempMenus = lstMenus.Skip((currentIndex - 1) * pageSize).Take(pageSize).ToList();

            PageInfo<Model.Shop_Modules> pageInfo = new PageInfo<Model.Shop_Modules>();
            pageInfo.PageIndex = currentIndex;
            pageInfo.PageSize = pageSize;
            pageInfo.TotalCount = lstMenus.Count;
            pageInfo.Items = tempMenus;
            return pageInfo;
        }


        public Model.Shop_Modules GetShopModule(int moduleId)
        {
            return _shop_modules_dal.GetShopModule(moduleId);
        }
    }
}
