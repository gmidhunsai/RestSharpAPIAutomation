using Microsoft.Extensions.Configuration;
using System.IO;

namespace Utils
{
    public class DataReader
    {
        private static readonly IConfigurationRoot Configuration;

        static DataReader()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
                            .AddJsonFile("Config/data.json");
            Configuration = builder.Build();
        }

        public static string Get(string name)
        {
            return Configuration.GetSection(name).Value;
        }
    }
}