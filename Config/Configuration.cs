using System;
using System.IO;
using System.Text.Json;

namespace HouseScraper.Config
{
    public class Configuration : IConfiguration
    {
        private string ReadConfig { get; }
        
        public Configuration(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException();
            }
            ReadConfig = File.ReadAllText(configFile);
        }

        public T GetConfig<T>() where T : IConfig
        {
            using JsonDocument document = JsonDocument.Parse(ReadConfig);
            return document.RootElement.GetProperty(typeof(T).Name).Deserialize<T>();
        }
    }
}