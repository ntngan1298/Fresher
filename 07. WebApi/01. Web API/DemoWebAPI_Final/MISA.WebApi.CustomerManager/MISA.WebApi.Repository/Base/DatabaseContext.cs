using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Repository
{
    public class DatabaseContext: IDatabaseContext
    {
        private readonly string _connectionString;
        private SqlConnection _connection;
        public DatabaseContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CustomerDemoConnection"].ConnectionString; ;
        }

        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }


        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
