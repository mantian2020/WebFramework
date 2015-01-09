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
using Shop.Module.DAL.IDAL;
using Shop.Module.Model;

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
            strSql.Append("`Shop_Modules_Sort`,");
            strSql.Append("`Shop_Modules_Creator`,");
            strSql.Append("`Shop_Modules_IsValid`)");
            strSql.Append("VALUES");
            strSql.Append("(@Shop_Modules_Name,");
            strSql.Append("@Shop_Modules_Description,");
            strSql.Append("@Shop_Modules_IsStart,");
            strSql.Append("now(),");
            strSql.Append("@Shop_Modules_Sort,");
            strSql.Append("@Shop_Modules_Creator,");
            strSql.Append("@Shop_Modules_IsValid);SELECT LAST_INSERT_ID();");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_Modules_Name",MySqlDbType.VarChar), 
                    new MySqlParameter("@Shop_Modules_Description",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_Modules_IsStart",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_Modules_Sort",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_Modules_Creator",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_Modules_IsValid",MySqlDbType.Int32)
                };
            parameters[0].Value = model.Shop_Modules_Name;
            parameters[1].Value = model.Shop_Modules_Description;
            parameters[2].Value = model.Shop_Modules_IsStart;
            parameters[3].Value = model.Shop_Modules_Sort;
            parameters[4].Value = model.Shop_Modules_Creator;
            parameters[5].Value = model.Shop_Modules_IsValid;
            object result = dataHelper.ExecuteScalar(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public bool UpdateShopModules(Model.Shop_Modules model)
        {
            string sql = @"UPDATE `shop_modules` 
                            SET `Shop_Modules_Name` = @Shop_Modules_Name, 
                            `Shop_Modules_Description` = @Shop_Modules_Description, 
                            `Shop_Modules_IsStart` = @Shop_Modules_IsStart, 
                            `Shop_Modules_IsValid` = @Shop_Modules_IsValid, 
                            `Shop_Modules_AddTime` = now(), 
                            `Shop_Modules_Sort` = @Shop_Modules_Sort,
                            `Shop_Modules_Creator` = @Shop_Modules_Creator
                            WHERE `Shop_Modules_Id` = @Shop_Modules_Id;";
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_Modules_Name",MySqlDbType.VarChar), 
                    new MySqlParameter("@Shop_Modules_Description",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_Modules_IsStart",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_Modules_Sort",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_Modules_IsValid",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_Modules_Creator",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_Modules_Id",MySqlDbType.Int32)
                };
            parameters[0].Value = model.Shop_Modules_Name;
            parameters[1].Value = model.Shop_Modules_Description;
            parameters[2].Value = model.Shop_Modules_IsStart;
            parameters[3].Value = model.Shop_Modules_Sort;
            parameters[4].Value = model.Shop_Modules_IsValid;
            parameters[5].Value = model.Shop_Modules_Creator;
            parameters[6].Value = model.Shop_Modules_Id;
            int result = dataHelper.ExecuteNonQuery(Config.ShopConnectionString, CommandType.Text, sql, parameters);
            return result > 0 ? true : false;
        }


        public bool DeleteShopModules(int moduleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE `shop_modules` SET `Shop_Modules_IsValid` = 0");
            strSql.Append(" WHERE Shop_Modules_Id=@Shop_Modules_Id");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_Modules_Id",MySqlDbType.Int32)
                };
            parameters[0].Value = moduleId;
            int result = dataHelper.ExecuteNonQuery(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            return result > 0 ? true : false;
        }

        public List<Model.Shop_Modules> GetShopModules()
        {
            List<Model.Shop_Modules> lstModules = new List<Shop_Modules>();
            string strSql = @"SELECT `Shop_Modules_Id`, 
                            `Shop_Modules_Name`, 
                            `Shop_Modules_Description`, 
                            `Shop_Modules_IsStart`, 
                            `Shop_Modules_IsValid`, 
                            `Shop_Modules_AddTime`, 
                            `Shop_Modules_Creator`, 
                            `Shop_Modules_Sort`
                            FROM `shop_modules` 
                            WHERE Shop_Modules_IsValid=1";
            DataTable dtModules = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql);
            if (dtModules != null && dtModules.Rows.Count > 0)
            {
                foreach (DataRow dr in dtModules.Rows)
                {
                    Shop_Modules model = new Shop_Modules();
                    model.Shop_Modules_Id = dr["Shop_Modules_Id"].ToInt();
                    model.Shop_Modules_Name = dr["Shop_Modules_Name"].ToStrings();
                    model.Shop_Modules_Description = dr["Shop_Modules_Description"].ToStrings();
                    model.Shop_Modules_IsStart = dr["Shop_Modules_IsStart"].ToInt();
                    model.Shop_Modules_IsValid = dr["Shop_Modules_IsValid"].ToInt();
                    model.Shop_Modules_AddTime = dr["Shop_Modules_AddTime"].ToTime();
                    model.Shop_Modules_Creator = dr["Shop_Modules_Creator"].ToStrings();
                    model.Shop_Modules_Sort = dr["Shop_Modules_Sort"].ToInt();
                    lstModules.Add(model);
                }
            }
            return lstModules;
        }


        public Shop_Modules GetShopModule(int moduleId)
        {
            Model.Shop_Modules model = new Shop_Modules();
            string strSql = @"SELECT `Shop_Modules_Id`, 
                            `Shop_Modules_Name`, 
                            `Shop_Modules_Description`, 
                            `Shop_Modules_IsStart`, 
                            `Shop_Modules_IsValid`, 
                            `Shop_Modules_AddTime`, 
                            `Shop_Modules_Creator`, 
                            `Shop_Modules_Sort`
                            FROM `shop_modules` 
                            WHERE Shop_Modules_Id=@Shop_Modules_Id";
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_Modules_Id",MySqlDbType.Int32)
                };
            parameters[0].Value = moduleId;
            DataRow dr = dataHelper.GetDataRow(Config.ShopConnectionString, CommandType.Text, strSql,parameters);
            if (dr != null )
            {
                model.Shop_Modules_Id = dr["Shop_Modules_Id"].ToInt();
                model.Shop_Modules_Name = dr["Shop_Modules_Name"].ToStrings();
                model.Shop_Modules_Description = dr["Shop_Modules_Description"].ToStrings();
                model.Shop_Modules_IsStart = dr["Shop_Modules_IsStart"].ToInt();
                model.Shop_Modules_IsValid = dr["Shop_Modules_IsValid"].ToInt();
                model.Shop_Modules_AddTime = dr["Shop_Modules_AddTime"].ToTime();
                model.Shop_Modules_Creator = dr["Shop_Modules_Creator"].ToStrings();
                model.Shop_Modules_Sort = dr["Shop_Modules_Sort"].ToInt();
            }
            return model;
        }
    }
}
