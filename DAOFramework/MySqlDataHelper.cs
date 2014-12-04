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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
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

        public int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, cmdType, cmdText, null);
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

        public int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
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
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
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

        public object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, cmdType, cmdText, null);
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

        public object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
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
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(cmdText, conn);
                    command.Fill(ds, "ds");
                    return ds;
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

        public DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(cmdText, conn);
                    command.Fill(ds, "ds");
                    return ds;
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

        public DataSet GetDataSet(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public DataSet GetDataSet(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string connectionString, string cmdText)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public DataRow GetDataRow(string connectionString, string cmdText)
        {
            throw new NotImplementedException();
        }

        public DataRow GetDataRow(string connectionString, CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        public DataRow GetDataRow(string connectionString, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public DataRow GetDataRow(string connectionString, DbTransaction trans, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public bool TestConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        private MySqlParameter[] ConvertToMySqlParameter(DbParameter[] commandParameters)
        {
            if (commandParameters != null && commandParameters.Length > 0)
            {
                MySqlParameter[] parameters = new MySqlParameter[commandParameters.Length];
                for (int i = 0; i < commandParameters.Length; i++)
                {
                    parameters[i] = (MySqlParameter)commandParameters[i];
                }
                return parameters;
            }
            return null;
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
