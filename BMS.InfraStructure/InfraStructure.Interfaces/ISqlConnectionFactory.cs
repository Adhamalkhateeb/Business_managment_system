using Microsoft.Data.SqlClient;

namespace BMS.InfraStructure.InfraStructure.interfaces
{

    
    ///<summary>
    /// Provides a factory for creating SQL connections.
    /// </summary>
    public interface ISqlConnectionFactory
    {
        /// <summary>
        /// Creates and returns a new instance of <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>A new <see cref="SqlConnection"/> instance.</returns>
        SqlConnection CreateConnection();
    }
}
