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
        public List<Model.Shop_Menu> GetUserMenus(int shop_RoleId)
        {
            List<Model.Shop_Menu> lstMenus = new List<Shop_Menu>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT 	`Shop_MenuId`, ");
            strSql.Append("`Shop_MenuName`, ");
            strSql.Append("`Shop_MenuUrl`, ");
            strSql.Append("`Shop_RoleId`,");
            strSql.Append("`Shop_ParentId`");
            strSql.Append(" FROM `shop_menu` ");
            strSql.Append(" WHERE Shop_RoleId=@Shop_RoleId");
             MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_RoleId",MySqlDbType.Int32)
                };
            parameters[0].Value = shop_RoleId;
            DataTable dtMenus = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (dtMenus != null && dtMenus.Rows.Count > 0)
            {
                foreach (DataRow dr in dtMenus.Rows)
                {
                    Shop_Menu model = new Shop_Menu();
                    model.Shop_MenuId = dr.IsNull("Shop_MenuId") ? 0 : Convert.ToInt32(dr["Shop_MenuId"]);
                    model.Shop_MenuName = dr.IsNull("Shop_MenuName") ? string.Empty : dr["Shop_MenuName"].ToString();
                    model.Shop_MenuUrl = dr.IsNull("Shop_MenuUrl") ? string.Empty : dr["Shop_MenuUrl"].ToString();
                    model.Shop_RoleId = dr.IsNull("Shop_RoleId") ? 0 : Convert.ToInt32(dr["Shop_RoleId"]);
                    model.Shop_ParentId = dr.IsNull("Shop_ParentId") ? 0 : Convert.ToInt32(dr["Shop_ParentId"]);
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
            strSql.Append("SELECT 	`Shop_MenuId`, ");
            strSql.Append("`Shop_MenuName`, ");
            strSql.Append("`Shop_MenuUrl`, ");
            strSql.Append("`Shop_RoleId`,");
            strSql.Append("`Shop_ParentId`");
            strSql.Append(" FROM `shop_menu` ");
            strSql.Append(" WHERE Shop_MenuId=@Shop_MenuId limit 1");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_MenuId",MySqlDbType.Int32)
                };
            parameters[0].Value = shop_MenuId;
            DataTable dtMenus = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (dtMenus != null && dtMenus.Rows.Count > 0)
            {
                DataRow dr = dtMenus.Rows[0];
                model.Shop_MenuId = dr.IsNull("Shop_MenuId") ? 0 : Convert.ToInt32(dr["Shop_MenuId"]);
                model.Shop_MenuName = dr.IsNull("Shop_MenuName") ? string.Empty : dr["Shop_MenuName"].ToString();
                model.Shop_MenuUrl = dr.IsNull("Shop_MenuUrl") ? string.Empty : dr["Shop_MenuUrl"].ToString();
                model.Shop_RoleId = dr.IsNull("Shop_RoleId") ? 0 : Convert.ToInt32(dr["Shop_RoleId"]);
                model.Shop_ParentId = dr.IsNull("Shop_ParentId") ? 0 : Convert.ToInt32(dr["Shop_ParentId"]);
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
            strSql.Append("UPDATE shop_menu");
            strSql.Append(" SET Shop_MenuName=@Shop_MenuName,");
            strSql.Append(" Shop_MenuUrl=@Shop_MenuUrl,");
            strSql.Append(" Shop_RoleId=@Shop_RoleId,");
            strSql.Append(" Shop_ParentId=@Shop_ParentId");
            strSql.Append(" WHERE Shop_MenuId=@Shop_MenuId");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_MenuId",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_MenuName",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_MenuUrl",MySqlDbType.VarChar),
                    new MySqlParameter("@Shop_RoleId",MySqlDbType.Int32),
                    new MySqlParameter("@Shop_ParentId",MySqlDbType.Int32)
                };
            parameters[0].Value = menu.Shop_MenuId;
            parameters[1].Value = menu.Shop_MenuName;
            parameters[2].Value = menu.Shop_MenuUrl;
            parameters[3].Value = menu.Shop_RoleId;
            parameters[4].Value = menu.Shop_ParentId;
            int result = dataHelper.ExecuteNonQuery(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            return result > 0 ? true : false;
        }
    }
}
