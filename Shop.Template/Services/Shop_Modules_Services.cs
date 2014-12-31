using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using Shop.Template.DAL.IDAL;
using Shop.Template.Services.IServices;

namespace Shop.Template.Services
{
    public class Shop_Modules_Services : IShop_Modules_Services
    {
        private readonly IShop_Modules_DAL _shop_modules_dal;
        public Shop_Modules_Services(IShop_Modules_DAL shop_modules_dal)
        {
            _shop_modules_dal = shop_modules_dal;
        }

        public string GetModules()
        {
            List<Model.Shop_Modules> lstModules =  _shop_modules_dal.GetModules();
            return SerializeHelper.SerializeData(lstModules);
        }

        public string GetModuleIds()
        {
            string moduleIds = string.Empty;
            List<Model.Shop_Modules> lstModules = _shop_modules_dal.GetModules();
            if (lstModules != null && lstModules.Count >0)
            {
                moduleIds = string.Join(",", lstModules.Select(o => o.Shop_Modules_Id).ToArray());
            }
            return moduleIds;
        }
    }
}
