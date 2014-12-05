using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOFramework
{
    public class SqlDataHelper : IDataHelper
    {
        public int ExecuteNonQuery(string connectionString, string cmdText)
        {
            return ExecuteNonQuery(connectionString, null, CommandType.Text, cmdText, null);
        }

        public int ExecuteNonQuery(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(connectionString, null, cmdType, cmdText, null);
        }

        public int ExecuteNonQuery(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, null, cmdType, cmdText, commandParameters);
        }

        public int ExecuteNonQuery(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //通过PrePareCommand方法将参数逐个加入到SqlCommand的参数集合中
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                //清空SqlCommand中的参数列表
                cmd.Parameters.Clear();
                return val;
            }
        }

        public object ExecuteScalar(string connectionString, string cmdText)
        {
            return ExecuteScalar(connectionString, null, CommandType.Text, cmdText, null);
        }

        public object ExecuteScalar(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(connectionString, null, cmdType, cmdText, null);
        }

        public object ExecuteScalar(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return ExecuteScalar(connectionString, null, cmdType, cmdText, commandParameters);
        }

        public object ExecuteScalar(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, trans, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public System.Data.DataSet GetDataSet(string connectionString, string cmdText)
        {
            return GetDataSet(connectionString, null, CommandType.Text, cmdText, null);
        }

        public System.Data.DataSet GetDataSet(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            return GetDataSet(connectionString, null, cmdType, cmdText, null);
        }

        public System.Data.DataSet GetDataSet(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return GetDataSet(connectionString, null, cmdType, cmdText, commandParameters);
        }

        public System.Data.DataSet GetDataSet(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public System.Data.DataTable GetDataTable(string connectionString, string cmdText)
        {
            return GetDataSet(connectionString, null, CommandType.Text, cmdText, null).Tables[0];
        }

        public System.Data.DataTable GetDataTable(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            return GetDataSet(connectionString, null, cmdType, cmdText, null).Tables[0];
        }

        public System.Data.DataTable GetDataTable(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return GetDataSet(connectionString, null, cmdType, cmdText, commandParameters).Tables[0];
        }

        public System.Data.DataTable GetDataTable(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            return GetDataSet(connectionString,trans,cmdType,cmdText,commandParameters).Tables[0];
        }

        public System.Data.DataRow GetDataRow(string connectionString, string cmdText)
        {
            DataTable dt = GetDataTable(connectionString, cmdText);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public System.Data.DataRow GetDataRow(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            DataTable dt = GetDataTable(connectionString, cmdType, cmdText);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public System.Data.DataRow GetDataRow(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            DataTable dt = GetDataTable(connectionString, cmdType, cmdText, commandParameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public System.Data.DataRow GetDataRow(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            DataTable dt = GetDataTable(connectionString, trans, cmdType, cmdText, commandParameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public bool TestConnection(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        ///Prepare parameters for the implementation of the command
        /// </summary>
        /// <param name="cmd">mySqlCommand command</param>
        /// <param name="conn">database connection that is existing</param>
        /// <param name="trans">database transaction processing </param>
        /// <param name="cmdType">SqlCommand command type (stored procedures, T-SQL statement, and so on.) </param>
        /// <param name="cmdText">Command text, T-SQL statements such as Select * from Products</param>
        /// <param name="cmdParms">return the command that has parameters</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, DbTransaction trans, CommandType cmdType, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = (SqlTransaction)trans;
            cmd.CommandType = CommandType.Text;//cmdType;  
            if (cmdParms != null)
            {
                foreach (DbParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
