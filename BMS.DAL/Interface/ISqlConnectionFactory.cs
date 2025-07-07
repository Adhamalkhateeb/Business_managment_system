using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.DAL.Interface
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
