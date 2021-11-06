using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HouseScraper.Config
{
    [Serializable]
    public class UserConfig : IConfig
    {
        [JsonPropertyName("UUIDs")]
        public List<string> UUIds { get; set; }
        
    }
}