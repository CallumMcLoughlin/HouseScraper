using System;
using System.Text.Json.Serialization;
using HouseScraper.Config;

namespace HouseScraper.Discord
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