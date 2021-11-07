using System;
using HouseScraper.Discord;
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
            Console.WriteLine(eventArgs.Property.PropertyTile);
            Bot.SendProperty(eventArgs.Property)
                .GetAwaiter()
                .GetResult();
        }
    }
}