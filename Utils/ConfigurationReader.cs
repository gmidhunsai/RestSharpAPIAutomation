using Microsoft.Extensions.Configuration;
using System.IO;

namespace Utils
{
    public class ConfigurationReader
    {
        private static readonly IConfigurationRoot Configuration;

        static ConfigurationReader()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
                            .AddJsonFile("Config/settings.json");
            Configuration = builder.Build();
        }

        public static string Get(string name)
        {
            return Configuration[name];
        }
    }
}