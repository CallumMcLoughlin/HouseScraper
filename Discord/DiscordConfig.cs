using System;
using System.Text.Json.Serialization;
using HouseScraper.Config;

namespace HouseScraper.Discord
{
    /// <summary>
    /// POCO to manage Discord configuration for authentication and channel settings
    /// </summary>
    [Serializable]
    public class DiscordConfig : IConfig
    {
        /// <summary>
        /// Bot token
        /// </summary>
        [JsonPropertyName("DiscordToken")]
        public string Token { get; set; }
        
        /// <summary>
        /// Channel ID to send messages in
        /// </summary>
        [JsonPropertyName("ChannelId")]
        public ulong ChannelId { get; set; }
    }
}