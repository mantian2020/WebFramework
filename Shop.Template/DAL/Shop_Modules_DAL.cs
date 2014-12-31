using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using CoreFramework.DBHelper;
using Shop.Template.DAL.IDAL;
using Shop.Template.Model;

namespace Shop.Template.DAL
{
    public class Shop_Modules_DAL : IShop_Modules_DAL
    {
        private static IDataHelper dataHelper = new MySqlDataHelper();
        public List<Model.Shop_Modules> GetModules()
        {
            List<Model.Shop_Modules> lstModules = new List<Shop_Modules>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT Shop_Modules_Id,Shop_Modules_Name,Shop_Modules_Description
                            ,Shop_Modules_IsStart,Shop_Modules_IsValid,Shop_Modules_Sort 
                            FROM shop_modules 
                            WHERE Shop_Modules_IsValid=1 AND Shop_Modules_IsStart=1");
            DataTable dtModules = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql.ToString());
            if (dtModules != null && dtModules.Rows.Count > 0)
            {
                foreach (DataRow dr in dtModules.Rows)
                {
                    Model.Shop_Modules model = new Shop_Modules();
                    model.Shop_Modules_Id = dr.IsNull("Shop_Modules_Id") ? 0 : Convert.ToInt32(dr["Shop_Modules_Id"]);
                    model.Shop_Modules_Name = dr.IsNull("Shop_Modules_Name") ? string.Empty : dr["Shop_Modules_Name"].ToString();
                    model.Shop_Modules_Description = dr.IsNull("Shop_Modules_Description") ? string.Empty : dr["Shop_Modules_Description"].ToString();
                    model.Shop_Modules_IsStart = dr.IsNull("Shop_Modules_IsStart") ? 0 : Convert.ToInt32(dr["Shop_Modules_IsStart"]);
                    model.Shop_Modules_IsValid = dr.IsNull("Shop_Modules_IsValid") ? 0 : Convert.ToInt32(dr["Shop_Modules_IsValid"]);
                    model.Shop_Modules_Sort = dr.IsNull("Shop_Modules_Sort") ? 0 : Convert.ToInt32(dr["Shop_Modules_Sort"]);
                    lstModules.Add(model);
                }
            }
            return lstModules;
        }
    }
}
