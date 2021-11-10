using System.IO;
using System.Text.Json;

namespace HouseScraper.Config
{
    /// <summary>
    /// Configuration reader and extractor class
    /// </summary>
    public class Configuration : IConfiguration
    {
        /// <summary>
        /// JSON formatted string of config properties
        /// </summary>
        private string ReadConfig { get; }
        
        /// <summary>
        /// Configuration constructor, reads a json formatted config file
        /// </summary>
        /// <param name="configFile">Filepath of configuration file</param>
        /// <exception cref="FileNotFoundException">If the file is not found</exception>
        public Configuration(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException();
            }
            ReadConfig = File.ReadAllText(configFile);
        }

        /// <summary>
        /// Get specific configuration value
        /// </summary>
        /// <typeparam name="T">Configuration type</typeparam>
        /// <returns>Configuration instance</returns>
        public T GetConfig<T>() where T : IConfig
        {
            using JsonDocument document = JsonDocument.Parse(ReadConfig);
            return document.RootElement.GetProperty(typeof(T).Name).Deserialize<T>();
        }
    }
}