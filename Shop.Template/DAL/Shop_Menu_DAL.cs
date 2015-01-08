using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonHelper;
using CoreFramework.DBHelper;
using MySql.Data.MySqlClient;
using Shop.Template.DAL.IDAL;
using Shop.Template.Model;

namespace Shop.Template.DAL
{
    public class Shop_Menu_DAL : IShop_Menu_DAL
    {
        private static IDataHelper dataHelper = new MySqlDataHelper();
        public List<Model.Shop_Menu> GetUserMenus(long shop_RoleId,string moduleIds)
        {
            List<Model.Shop_Menu> lstMenus = new List<Shop_Menu>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT sm.Shop_MenuId,sm.Shop_MenuName,sm.Shop_MenuIcon,sm.Shop_MenuUrl
                            ,sm.Shop_MenuSort,sm.Shop_ParentId 
                            FROM shop_menu AS sm
                            INNER JOIN shop_role_menu AS srm
                            ON sm.Shop_ModuleId=srm.Shop_ModuleId 
                            AND sm.Shop_MenuCode&srm.Shop_MenuList=sm.Shop_MenuCode
                            WHERE srm.Shop_RoleCode&@Shop_RoleCode=srm.Shop_RoleCode 
                            AND srm.Shop_ModuleId IN (@Shop_ModuleId) AND sm.Shop_MenuVaild=1");
             MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_RoleCode",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_ModuleId",MySqlDbType.VarChar)
                };
             parameters[0].Value = shop_RoleId;
             parameters[1].Value = moduleIds;
            DataTable dtMenus = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (dtMenus != null && dtMenus.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMenus.Rows)
                {
                    Shop_Menu model = new Shop_Menu();
                    model.Shop_MenuName = dr.IsNull("Shop_MenuName") ? string.Empty : dr["Shop_MenuName"].ToString();
                    model.Shop_MenuUrl = dr.IsNull("Shop_MenuUrl") ? string.Empty : dr["Shop_MenuUrl"].ToString();
                    model.Shop_MenuIcon = dr.IsNull("Shop_MenuIcon") ? string.Empty : dr["Shop_MenuIcon"].ToString();
                    model.Shop_MenuSort = dr.IsNull("Shop_MenuSort") ? 0 : Convert.ToInt32(dr["Shop_MenuSort"]);
                    model.Shop_ParentId = dr.IsNull("Shop_ParentId") ? 0 : Convert.ToInt32(dr["Shop_ParentId"]);
                    model.Shop_MenuId = dr.IsNull("Shop_MenuId") ? 0 : Convert.ToInt32(dr["Shop_MenuId"]);
                    lstMenus.Add(model);
                }
            }
            return lstMenus;
        }

        /// <summary>
        /// 根据菜单ID，获取一条菜单
        /// </summary>
        /// <param name="shop_MenuId"></param>
        /// <returns></returns>
        public Shop_Menu GetShopMenu(int shop_MenuId)
        {
            Model.Shop_Menu model = new Model.Shop_Menu();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT 	`Shop_MenuId`, 
                            `Shop_MenuName`, 
                            `Shop_MenuUrl`, 
                            `Shop_MenuCode`, 
                            `Shop_ParentId`, 
                            `Shop_MenuCreateTime`, 
                            `Shop_MenuCreator`, 
                            `Shop_MenuVaild`, 
                            `Shop_MenuIcon`, 
                            `Shop_MenuSort`, 
                            `Shop_ModuleId`
                            FROM `shop_menu` 
                            WHERE Shop_MenuId=@Shop_MenuId limit 1");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_MenuId",MySqlDbType.Int32)
                };
            parameters[0].Value = shop_MenuId;
            DataTable dtMenus = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (dtMenus != null && dtMenus.Rows.Count > 0)
            {
                DataRow dr = dtMenus.Rows[0];
                model.Shop_MenuName = dr.IsNull("Shop_MenuName") ? string.Empty : dr["Shop_MenuName"].ToString();
                model.Shop_MenuUrl = dr.IsNull("Shop_MenuUrl") ? string.Empty : dr["Shop_MenuUrl"].ToString();
                model.Shop_MenuCode = dr.IsNull("Shop_MenuCode") ? 0 : Convert.ToInt32(dr["Shop_MenuCode"]);
                model.Shop_ParentId = dr.IsNull("Shop_ParentId") ? 0 : Convert.ToInt32(dr["Shop_ParentId"]);
                model.Shop_MenuCreateTime = dr.IsNull("Shop_MenuCreateTime")
                    ? DateTime.Now
                    : Convert.ToDateTime(dr["Shop_MenuCreateTime"]);
                model.Shop_MenuCreator = dr.IsNull("Shop_MenuCreator") ? string.Empty : dr["Shop_MenuCreator"].ToString();
                model.Shop_MenuVaild = dr.IsNull("Shop_MenuVaild") ? 0 : Convert.ToInt32(dr["Shop_MenuVaild"]);
                model.Shop_MenuSort = dr.IsNull("Shop_MenuSort") ? 0 : Convert.ToInt32(dr["Shop_MenuSort"]);
                model.Shop_MenuIcon = dr.IsNull("Shop_MenuIcon") ? string.Empty : dr["Shop_MenuIcon"].ToString();
                model.Shop_MenuId = dr.IsNull("Shop_MenuId") ? 0 : Convert.ToInt32(dr["Shop_MenuId"]);
                model.Shop_ModuleId = dr.IsNull("Shop_ModuleId") ? 0 : Convert.ToInt32(dr["Shop_ModuleId"]);
            }
            return model;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool UpdateMenu(Shop_Menu menu)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"UPDATE `shop_menu` 
                            SET `Shop_MenuName` = @Shop_MenuName , 
                            `Shop_MenuUrl` = @Shop_MenuUrl, 
                            `Shop_MenuCode` = @Shop_MenuCode , 
                            `Shop_ParentId` = @Shop_ParentId , 
                            `Shop_MenuCreateTime` = now() , 
                            `Shop_MenuCreator` = @Shop_MenuCreator , 
                            `Shop_MenuVaild` = @Shop_MenuVaild , 
                            `Shop_MenuIcon` =  @Shop_MenuIcon, 
                            `Shop_MenuSort` = @Shop_MenuSort , 
                            `Shop_ModuleId` = @Shop_ModuleId
                            WHERE `Shop_MenuId` = @Shop_MenuId;");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_MenuId",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_MenuName",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_MenuUrl",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_MenuCode",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_ParentId",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_MenuCreator",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_MenuVaild",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_MenuIcon",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_MenuSort",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_ModuleId",MySqlDbType.Int32)
                };
            parameters[0].Value = menu.Shop_MenuId;
            parameters[1].Value = menu.Shop_MenuName;
            parameters[2].Value = menu.Shop_MenuUrl;
            parameters[3].Value = menu.Shop_MenuCode;
            parameters[4].Value = menu.Shop_ParentId;
            parameters[5].Value = menu.Shop_MenuCreator;
            parameters[6].Value = menu.Shop_MenuVaild;
            parameters[7].Value = menu.Shop_MenuIcon;
            parameters[8].Value = menu.Shop_MenuSort;
            parameters[9].Value = menu.Shop_ModuleId;
            int result = dataHelper.ExecuteNonQuery(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            return result > 0 ? true : false;
        }


        public int AddMenu(Shop_Menu menu)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO `shop_menu` ");
            strSql.Append("(`Shop_MenuName`, ");
            strSql.Append("`Shop_MenuUrl`, ");
            strSql.Append("`Shop_ParentId`");
            strSql.Append(")");
            strSql.Append("VALUES");
            strSql.Append("(@Shop_MenuName, ");
            strSql.Append("@Shop_MenuUrl, ");
            strSql.Append("@Shop_ParentId);SELECT LAST_INSERT_ID();");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_MenuName",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_MenuUrl",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_ParentId",MySqlDbType.Int32)
                };
            parameters[0].Value = menu.Shop_MenuName;
            parameters[1].Value = menu.Shop_MenuUrl;
            parameters[2].Value = menu.Shop_ParentId;
            object result = dataHelper.ExecuteScalar(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            
            return result !=null ?  Convert.ToInt32(result) : 0;
        }


        public bool DeleteMenu(int shop_MenuId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM `shop_menu`  ");
            strSql.Append("WHERE Shop_MenuId=@Shop_MenuId");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_MenuId",MySqlDbType.Int32)
                };
            parameters[0].Value = shop_MenuId;
            int result = dataHelper.ExecuteNonQuery(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            return result > 0 ? true : false;
        }


        public List<Shop_Menu> GetAllMenus()
        {
            List<Shop_Menu> lstMenus = new List<Shop_Menu>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT 	`Shop_MenuId`, 
                            `Shop_MenuName`, 
                            `Shop_MenuUrl`, 
                            `Shop_MenuCode`, 
                            `Shop_ParentId`, 
                            `Shop_MenuCreateTime`, 
                            `Shop_MenuCreator`, 
                            `Shop_MenuVaild`, 
                            `Shop_MenuIcon`, 
                            `Shop_MenuSort`, 
                            `Shop_ModuleId`
                            FROM `shop_menu` 
                            WHERE Shop_MenuVaild=1");
            DataTable dtMenus = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql.ToString());
            if (dtMenus != null && dtMenus.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMenus.Rows)
                {
                    Shop_Menu model = new Shop_Menu();
                    model.Shop_MenuName = dr.IsNull("Shop_MenuName") ? string.Empty : dr["Shop_MenuName"].ToString();
                    model.Shop_MenuUrl = dr.IsNull("Shop_MenuUrl") ? string.Empty : dr["Shop_MenuUrl"].ToString();
                    model.Shop_MenuCode = dr.IsNull("Shop_MenuCode") ? 0 : Convert.ToInt32(dr["Shop_MenuCode"]);
                    model.Shop_ParentId = dr.IsNull("Shop_ParentId") ? 0 : Convert.ToInt32(dr["Shop_ParentId"]);
                    model.Shop_MenuCreateTime = dr.IsNull("Shop_MenuCreateTime")
                        ? DateTime.Now
                        : Convert.ToDateTime(dr["Shop_MenuCreateTime"]);
                    model.Shop_MenuCreator = dr.IsNull("Shop_MenuCreator") ? string.Empty : dr["Shop_MenuCreator"].ToString();
                    model.Shop_MenuVaild = dr.IsNull("Shop_MenuVaild") ? 0 : Convert.ToInt32(dr["Shop_MenuVaild"]);
                    model.Shop_MenuSort = dr.IsNull("Shop_MenuSort") ? 0 : Convert.ToInt32(dr["Shop_MenuSort"]);
                    model.Shop_MenuIcon = dr.IsNull("Shop_MenuIcon") ? string.Empty : dr["Shop_MenuIcon"].ToString();
                    model.Shop_MenuId = dr.IsNull("Shop_MenuId") ? 0 : Convert.ToInt32(dr["Shop_MenuId"]);
                    model.Shop_ModuleId = dr.IsNull("Shop_ModuleId") ? 0 : Convert.ToInt32(dr["Shop_ModuleId"]);
                    lstMenus.Add(model);
                }
            }
            return lstMenus;
        }
    }
}
