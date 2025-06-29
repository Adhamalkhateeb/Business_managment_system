using System.Configuration;

namespace Utilities
{
    public static  class ConfigReader
    {
        public static string GetConnectionString() => ConfigurationManager.ConnectionStrings["BMSConnectionString"].ConnectionString;

        public static string GetSettings(string Key) => ConfigurationManager.AppSettings[Key];

    }
}
