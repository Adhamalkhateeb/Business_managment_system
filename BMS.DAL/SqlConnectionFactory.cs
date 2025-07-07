
using BMS.DAL.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DAL
{
    /// <summary>
    /// Factory class for creating SQL connections.
    /// </summary>
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Gets the connection string used by the factory.
        /// </summary>
        public string ConnectionString => _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlConnectionFactory"/> class.
        /// </summary>
        public SqlConnectionFactory()
        {
            _connectionString = ConfigReader.GetConnectionString();
        }

        /// <summary>
        /// Creates and returns a new <see cref="SqlConnection"/> instance.
        /// </summary>
        /// <returns>A new SQL connection.</returns>
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
