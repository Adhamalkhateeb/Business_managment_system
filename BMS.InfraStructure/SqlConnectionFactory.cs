
using BMS.InfraStructure.InfraStructure.interfaces;
using Microsoft.Data.SqlClient;
using BMS.InfraStructure.Core.Interfaces;




namespace BMS.InfraStructure
{
    /// <summary>
    /// Factory class for creating SQL connections.
    /// </summary>
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private readonly IConfigReader _configReader;


        public SqlConnectionFactory(IConfigReader configReader)
        {
            _configReader = configReader ?? throw new ArgumentNullException(nameof(configReader));
            _connectionString = _configReader.GetConnectionString("BMS");
        }



        /// <summary>
        /// Gets the connection string used by the factory.
        /// </summary>
        public string ConnectionString => _connectionString;

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
