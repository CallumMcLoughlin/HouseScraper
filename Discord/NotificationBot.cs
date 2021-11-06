using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using HouseScraper.Config;
using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Discord
{
    public class NotificationBot
    {
        public event EventHandler<DiscordSocketClient> BotReady;
        
        private readonly DiscordSocketClient _client;
        private readonly Config.DiscordConfig _config;
       
        private ISocketMessageChannel _channel;
        
        public NotificationBot()
        {
            _config = ConfigurationManager.Instance.GetConfig<Config.DiscordConfig>();
            _client = new DiscordSocketClient();
            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Starting up...");
            await _client.LoginAsync(TokenType.Bot, _config.Token);
            await _client.StartAsync();

            await Task.Delay(Timeout.Infinite);
        }
        
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
        
        private Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");
            BotReady?.Invoke(this, null);
            _channel = (ISocketMessageChannel)_client.GetChannel(_config.ChannelId);

            return Task.CompletedTask;
        }

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