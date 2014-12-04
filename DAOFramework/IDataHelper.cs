using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOFramework
{
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public interface IDataHelper
    {
        #region ExecuteNonQuery

        /// <summary>
        /// 执行SQL返回影响行数
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string connectionString,string cmdText);

        /// <summary>
        /// 执行SQL返回影响行数
        /// </summary>
        /// <param name="cmdType">SQL类型</param>
        /// <param name="cmdText">SQL</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行SQL返回影响行数
        /// </summary>
        /// <param name="cmdType">SQL类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行SQL返回影响行数
        /// </summary>
        /// <param name="trans">链接事务</param>
        /// <param name="cmdType">SQL类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// 返回查询的第一行第一列
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <returns>第一行第一列</returns>
        object ExecuteScalar(string connectionString, string cmdText);

        /// <summary>
        /// 返回查询的第一行第一列
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <returns>第一行第一列</returns>
        object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 返回查询的第一行第一列
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>第一行第一列</returns>
        object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 返回查询的第一行第一列
        /// </summary>
        /// <param name="trans">链接事务</param>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>第一行第一列</returns>
        object ExecuteScalar(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        #endregion

        #region GetDataSet

        /// <summary>
        /// 执行查询返回DataSet
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <returns>DataSet</returns>
        DataSet GetDataSet(string connectionString, string cmdText);

        /// <summary>
        /// 执行查询返回DataSet
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <returns>DataSet</returns>
        DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行查询返回DataSet
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataSet</returns>
        DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行查询返回DataSet
        /// </summary>
        /// <param name="trans">链接事务</param>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataSet</returns>
        DataSet GetDataSet(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        #endregion

        #region GetDataTable

        /// <summary>
        /// 执行查询返回数据表
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <returns>DataTable</returns>
        DataTable GetDataTable(string connectionString, string cmdText);

        /// <summary>
        /// 执行查询返回数据表
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <returns>DataTable</returns>
        DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行查询返回数据表
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataTable</returns>
        DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行查询返回数据表
        /// </summary>
        /// <param name="trans">链接事务</param>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataTable</returns>
        DataTable GetDataTable(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        #endregion

        #region GetDataRow

        /// <summary>
        /// 执行查询返回数据行
        /// </summary>
        /// <param name="cmdText">SQL</param>
        /// <returns>DataRow</returns>
        DataRow GetDataRow(string connectionString, string cmdText);

        /// <summary>
        /// 执行查询返回数据行
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <returns>DataRow</returns>
        DataRow GetDataRow(string connectionString, CommandType cmdType, string cmdText);

        /// <summary>
        /// 执行查询返回数据行
        /// </summary>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataRow</returns>
        DataRow GetDataRow(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行查询返回数据行
        /// </summary>
        /// <param name="trans">链接事务</param>
        /// <param name="cmdType">脚本类型</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="commandParameters">参数</param>
        /// <returns>DataRow</returns>
        DataRow GetDataRow(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        #endregion

        /// <summary>
        /// 测试数据库链接
        /// </summary>
        /// <returns>是否链接成功</returns>
        bool TestConnection();
    }
}
