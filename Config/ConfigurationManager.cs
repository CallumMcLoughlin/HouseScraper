using System;
using System.Collections.Generic;

namespace HouseScraper.Config
{
    /// <summary>
    /// Class to manage configuration
    /// </summary>
    public class ConfigurationManager
    {
        /// <summary>
        /// File to read configuration values from
        /// </summary>
        private const string ConfigurationFile = "settings.json";
        private static IConfiguration Configuration { get; } = new Configuration(ConfigurationFile);

        /// <summary>
        /// Singleton instance
        /// </summary>
        private static ConfigurationManager _instance;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static ConfigurationManager Instance => _instance ??= new ConfigurationManager();

        /// <summary>
        /// Cache of the read configuration values
        /// </summary>
        private readonly Dictionary<Type, IConfig> _settings = new Dictionary<Type, IConfig>();

        private ConfigurationManager() { }

        /// <summary>
        /// Get configuration from cache or config file
        /// </summary>
        /// <typeparam name="T">Configuration type</typeparam>
        /// <returns>Configuration instance</returns>
        public T GetConfig<T>() where T : IConfig
        {
            if (_settings.TryGetValue(typeof(T), out IConfig config))
            {
                return (T) config;
            }
            
            config = Configuration.GetConfig<T>();

            _settings[typeof(T)] = config ?? throw new ConfigException($"Missing configuration value for type {typeof(T).Name}");
            return (T) config;
        }
    }
}