using System;
using Discord.WebSocket;
using HouseScraper.Discord;
using HouseScraper.Events.Scraper;
using HouseScraper.Scraper.Checker;
using HouseScraper.Scraper.Web;

namespace HouseScraper
{
    class Program
    {
        private static readonly NotificationBot Bot = new NotificationBot();
        private static readonly PropertyChecker Checker = new PropertyChecker(new HtmlPropertyScraper());
        
        static void Main(string[] args)
        {
            Bot.BotReady += (sender, client) =>
            {
                Checker.NewPropertyEvent += OnNewProperty;
                Checker.StartRoutine();
            };
            Bot.RunAsync().GetAwaiter().GetResult();
        }

        private static void OnNewProperty(object sender, PropertyFoundEventArgs eventArgs)
        {
            Bot.SendProperty(eventArgs.Property)
                .GetAwaiter()
                .GetResult();
        }
    }
}