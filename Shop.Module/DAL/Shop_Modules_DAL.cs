using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using CoreFramework.DBHelper;
using MySql.Data.MySqlClient;
using Shop.Module.DAL.Interface;

namespace Shop.Module.DAL
{
    public class Shop_Modules_DAL : IShop_Modules_DAL
    {
        private static IDataHelper dataHelper = new MySqlDataHelper();
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddShopModules(Model.Shop_Modules model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO `shop_modules` ");
            strSql.Append("(`Shop_Modules_Name`, ");
            strSql.Append("`Shop_Modules_Description`, ");
            strSql.Append("`Shop_Modules_IsStart`, ");
            strSql.Append("`Shop_Modules_AddTime`, ");
            strSql.Append("`Shop_Modules_IsValid`)");
            strSql.Append("VALUES");
            strSql.Append("(@Shop_Modules_Name,");
            strSql.Append("@Shop_Modules_Description,");
            strSql.Append("@Shop_Modules_IsStart,");
            strSql.Append("now(),");
            strSql.Append("@Shop_Modules_IsValid);SELECT LAST_INSERT_ID();");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_Modules_Name",MySqlDbType.VarChar), 
                    new MySqlParameter("@Shop_Modules_Description",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_Modules_IsStart",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_Modules_IsValid",MySqlDbType.Int32)
                };
            parameters[0].Value = model.Shop_Modules_Name;
            parameters[1].Value = model.Shop_Modules_Description;
            parameters[2].Value = model.Shop_Modules_IsStart;
            parameters[3].Value = model.Shop_Modules_IsValid;
            object result = dataHelper.ExecuteScalar(Config.ShopConnectionString, CommandType.Text, string.Empty, parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public int UpdateShopModules(Model.Shop_Modules model)
        {

            return 0;
        }
    }
}
