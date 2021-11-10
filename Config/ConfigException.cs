using System;

namespace HouseScraper.Config
{
    /// <summary>
    /// Exception thrown when a config value is not found or invalid
    /// </summary>
    [Serializable]
    public class ConfigException : Exception
    {
        public ConfigException() : base() { }
        public ConfigException(string message) : base(message) { }
        public ConfigException(string message, Exception inner) : base(message, inner) { }
    }
}