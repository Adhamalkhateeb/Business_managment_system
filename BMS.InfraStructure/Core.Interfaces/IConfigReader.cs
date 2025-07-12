using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.InfraStructure.Core.Interfaces
{
    public interface IConfigReader
    {
        string GetConnectionString(string Name);

        string GetSetting(string key);
    }
}
