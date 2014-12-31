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
    public class Shop_UserInfo_DAL : IShop_UserInfo_DAL
    {
        private static IDataHelper dataHelper = new MySqlDataHelper();

        public Model.Shop_UserInfo GetUserInfo(string userName, string password)
        {
            Model.Shop_UserInfo userInfo = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Shop_UserId,Shop_UserName,Shop_UserPassword,Shop_UserCreateTime,Shop_UserCreator,Shop_UserVaild,Shop_UserRoleList FROM shop_userinfo");
            strSql.Append(" WHERE Shop_UserName=@Shop_UserName AND Shop_UserPassword=@Shop_UserPassword limit 1");
            MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@Shop_UserName",MySqlDbType.VarChar), 
                    new MySqlParameter("@Shop_UserPassword",MySqlDbType.VarChar)
                };
            parameters[0].Value = userName;
            parameters[1].Value = password;
            DataTable dtUserInfo = dataHelper.GetDataTable(Config.ShopConnectionString, CommandType.Text, strSql.ToString(), parameters);
            if (dtUserInfo != null && dtUserInfo.Rows.Count > 0)
            {
                userInfo = new Shop_UserInfo();
                DataRow dr = dtUserInfo.Rows[0];
                userInfo.Shop_UserId = dr.IsNull("Shop_UserId") ? 0 : Convert.ToInt32(dr["Shop_UserId"]);
                userInfo.Shop_UserName = dr.IsNull("Shop_UserName") ? string.Empty : dr["Shop_UserName"].ToString();
                userInfo.Shop_UserPassword = dr.IsNull("Shop_UserPassword") ? string.Empty : dr["Shop_UserPassword"].ToString();
                userInfo.Shop_UserRoleList = dr.IsNull("Shop_UserRoleList") ? 0 : Convert.ToInt32(dr["Shop_UserRoleList"]);
            }
            return userInfo;
        }

    }
}
