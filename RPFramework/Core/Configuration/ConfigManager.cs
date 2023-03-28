using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RPFramework.Core.Configuration.Models;
using RPFramework.Core.Utils;

namespace RPFramework.Core.Configuration
{
    public class ConfigManager
    {
        public static IConfiguration Configuration =>
            new ConfigurationBuilder().AddJsonFile(PathHelper.GetAssemblyFile(Constants.AppsetingsPath)).Build();

        [JsonProperty(nameof(BrowserOptions))]
        public static BrowserOptions BrowserOptions { get; set; }

        public static string? GetProperty(string section, string key) => Configuration.GetSection(section)[key];
        
        static ConfigManager()
        {
            var path = PathHelper.GetAssemblyFile(Constants.AppsetingsPath);
            JsonConvert.DeserializeObject<ConfigManager>(File.ReadAllText(path));
        }
    }
}
