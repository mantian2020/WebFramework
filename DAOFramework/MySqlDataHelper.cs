using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DAOFramework
{
    public class MySqlDataHelper : IDataHelper
    {
        public int ExecuteNonQuery(string connectionString, string cmdText)
        {
            return ExecuteNonQuery(connectionString, null, CommandType.Text, cmdText, null);
        }

        public int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(connectionString, null, cmdType, cmdText, null);
        }

        public int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString,null, cmdType, cmdText, commandParameters);
        }

        public int ExecuteNonQuery(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return val;
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public object ExecuteScalar(string connectionString, string cmdText)
        {
            return ExecuteScalar(connectionString, null, CommandType.Text, cmdText, null);
        }

        public object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(connectionString, null, cmdType, cmdText, null);
        }

        public object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            return ExecuteScalar(connectionString, null, cmdType, cmdText, commandParameters);
        }

        public object ExecuteScalar(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                        object val = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(val, null)) || (Object.Equals(val, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return val;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public DataSet GetDataSet(string connectionString, string cmdText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                return ExecuteDataSet(conn, null,CommandType.Text, cmdText, null);
            }
        }

        public DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                return ExecuteDataSet(conn, null, cmdType, cmdText, null);
            }
        }

        public DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                return ExecuteDataSet(conn, null, cmdType, cmdText, commandParameters);
            }
        }

        public DataSet GetDataSet(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                return ExecuteDataSet(conn, trans, cmdType, cmdText, commandParameters);
            }
        }

        public DataTable GetDataTable(string connectionString, string cmdText)
        {
            return GetDataSet(connectionString,cmdText).Tables[0];
        }

        public DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText)
        {
            return GetDataSet(connectionString, cmdType, cmdText).Tables[0];
        }

        public DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            return GetDataSet(connectionString, cmdType, cmdText, commandParameters).Tables[0];
        }

        public DataTable GetDataTable(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            return GetDataSet(connectionString, trans, cmdType, cmdText, commandParameters).Tables[0];
        }

        public DataRow GetDataRow(string connectionString, string cmdText)
        {
            DataTable dt = GetDataTable(connectionString, cmdText);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataRow GetDataRow(string connectionString, CommandType cmdType, string cmdText)
        {
            DataTable dt = GetDataTable(connectionString,cmdType, cmdText);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataRow GetDataRow(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            DataTable dt = GetDataTable(connectionString, cmdType, cmdText, commandParameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public DataRow GetDataRow(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            DataTable dt = GetDataTable(connectionString,trans, cmdType, cmdText, commandParameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public bool TestConnection(string connectionString)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
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
        /// 执行SQL语句,返回结果集
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="transaction">事务</param>
        /// <param name="commandType">命令类型(存储过程,命令文本, 其它.)</param>
        /// <param name="commandText">SQL语句或存储过程名称</param>
        /// <param name="parms">查询参数</param>
        /// <returns>返回结果集</returns>
        private static DataSet ExecuteDataSet(MySqlConnection connection, DbTransaction transaction, CommandType commandType, string commandText, params DbParameter[] parms)
        {
            MySqlCommand command = new MySqlCommand();

            PrepareCommand(command, connection, transaction, commandType, commandText, parms);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (commandText.IndexOf("@") > 0)
            {
                commandText = commandText.ToLower();
                int index = commandText.IndexOf("where ");
                if (index < 0)
                {
                    index = commandText.IndexOf("\nwhere");
                }
                if (index > 0)
                {
                    ds.ExtendedProperties.Add("SQL", commandText.Substring(0, index - 1));  //将获取的语句保存在表的一个附属数组里，方便更新时生成CommandBuilder
                }
                else
                {
                    ds.ExtendedProperties.Add("SQL", commandText);  //将获取的语句保存在表的一个附属数组里，方便更新时生成CommandBuilder
                }
            }
            else
            {
                ds.ExtendedProperties.Add("SQL", commandText);  //将获取的语句保存在表的一个附属数组里，方便更新时生成CommandBuilder
            }

            foreach (DataTable dt in ds.Tables)
            {
                dt.ExtendedProperties.Add("SQL", ds.ExtendedProperties["SQL"]);
            }

            command.Parameters.Clear();
            return ds;
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
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, DbTransaction trans, CommandType cmdType, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = (MySqlTransaction)trans;
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
