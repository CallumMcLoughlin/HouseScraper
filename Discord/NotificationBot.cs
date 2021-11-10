using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using HouseScraper.Config;
using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Discord
{
    /// <summary>
    /// Handle sending notifications to a Discord channel and server
    /// </summary>
    public class NotificationBot
    {
        /// <summary>
        /// Event raised when bot is ready to be used
        /// </summary>
        public event EventHandler<DiscordSocketClient> BotReady;
        
        private readonly DiscordSocketClient _client;
        private readonly DiscordConfig _config;
       
        private ISocketMessageChannel _channel;

        /// <summary>
        /// Constructor for Discord bot, reads config and logs in
        /// </summary>
        public NotificationBot()
        {
            _config = ConfigurationManager.Instance.GetConfig<DiscordConfig>();
            _client = new DiscordSocketClient();
            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
        }

        /// <summary>
        /// Run the bot
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            Console.WriteLine("Starting up...");
            await _client.LoginAsync(TokenType.Bot, _config.Token);
            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }
        
        /// <summary>
        /// Log bot events
        /// </summary>
        /// <param name="log">Message to be logged</param>
        /// <returns></returns>
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
        
        /// <summary>
        /// On bot ready, sets up channel and emits BotReady event
        /// </summary>
        /// <returns></returns>
        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");
            BotReady?.Invoke(this, null);
            _channel = (ISocketMessageChannel)_client.GetChannel(_config.ChannelId);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Send property to Discord channel
        /// </summary>
        /// <param name="property">Property to send</param>
        /// <returns></returns>
        public async Task SendProperty(Property property)
        {
            EmbedBuilder message = new EmbedBuilder()
                .WithTitle(property.PropertyTile)
                .WithFields(
                    new EmbedFieldBuilder().WithName("Cost").WithValue(property.Cost).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Bedrooms").WithValue(property.Bedrooms).WithIsInline(true),
                    new EmbedFieldBuilder().WithName("Bathrooms").WithValue(property.Bathrooms).WithIsInline(true))
                .WithUrl(property.Url)
                .WithColor(Color.Red);
            if (property.ImageUrl != null)
                message.WithImageUrl(property.ImageUrl);
            
            await _channel.SendMessageAsync(embed: message.Build());
        }
    }
}