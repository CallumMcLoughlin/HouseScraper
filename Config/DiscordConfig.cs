using System;
using System.Text.Json.Serialization;

namespace HouseScraper.Config
{
    [Serializable]
    public class DiscordConfig : IConfig
    {
        [JsonPropertyName("DiscordToken")]
        public string Token { get; set; }
        
        [JsonPropertyName("ChannelId")]
        public ulong ChannelId { get; set; }
    }
}