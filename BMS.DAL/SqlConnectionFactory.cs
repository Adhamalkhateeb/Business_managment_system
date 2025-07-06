
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DAL
{
    internal class SqlConnectionFactory :ISqlConnectionFactory
    {
        private readonly string _connectionString;
        public string ConnectionString => _connectionString;

        public SqlConnectionFactory()
        {
            _connectionString =  ConfigReader.GetConnectionString();
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
