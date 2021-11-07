using System;
using System.Collections.Generic;

namespace HouseScraper.Config
{
    public class ConfigurationManager
    {
        private const string ConfigurationFile = "settings.json";
        private static IConfiguration Configuration { get; } = new Configuration(ConfigurationFile);

        private static ConfigurationManager _instance;
        public static ConfigurationManager Instance => _instance ??= new ConfigurationManager();

        private readonly Dictionary<Type, IConfig> _settings = new Dictionary<Type, IConfig>();

        private ConfigurationManager() { }

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