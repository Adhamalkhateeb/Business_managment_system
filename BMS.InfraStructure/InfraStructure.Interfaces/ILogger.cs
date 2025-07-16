using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.InfraStructure.InfraStructure.interfaces
{
    public interface ILogger
    {
        Task  LogError(string message);
    }
}
