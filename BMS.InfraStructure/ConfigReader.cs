using BMS.InfraStructure.Core.Interfaces;
using System.Configuration;

namespace BMS.InfraStructure
{
    public class ConfigReader  : IConfigReader
    {
        public string GetConnectionString(string name) =>
            ConfigurationManager.ConnectionStrings[name]?.ConnectionString
            ?? throw new InvalidOperationException($"Connection string '{name}' not found.");

        public string GetSetting(string key) =>
            ConfigurationManager.AppSettings[key]
            ?? throw new InvalidOperationException($"AppSetting '{key}' not found.");

    }
}
