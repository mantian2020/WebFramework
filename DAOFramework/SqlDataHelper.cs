using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOFramework
{
    public class SqlDataHelper:IDataHelper
    {
        public int ExecuteNonQuery(string connectionString, string cmdText)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string connectionString, string cmdText)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public object ExecuteScalar(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet GetDataSet(string connectionString, string cmdText)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet GetDataSet(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet GetDataSet(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet GetDataSet(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetDataTable(string connectionString, string cmdText)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetDataTable(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetDataTable(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetDataTable(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataRow GetDataRow(string connectionString, string cmdText)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataRow GetDataRow(string connectionString, System.Data.CommandType cmdType, string cmdText)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataRow GetDataRow(string connectionString, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataRow GetDataRow(string connectionString, System.Data.Common.DbTransaction trans, System.Data.CommandType cmdType, string cmdText, params System.Data.Common.DbParameter[] commandParameters)
        {
            throw new NotImplementedException();
        }

        public bool TestConnection()
        {
            throw new NotImplementedException();
        }
    }
}
