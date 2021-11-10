using System;
using HouseScraper.Discord;
using HouseScraper.Scraper.Checker;
using HouseScraper.Scraper.Web;

namespace HouseScraper
{
    /// <summary>
    /// Main entrypoint
    /// </summary>
    class Program
    {
        /// <summary>
        /// Bot used to send notifications
        /// </summary>
        private static readonly NotificationBot Bot = new NotificationBot();
        
        /// <summary>
        /// Property checker that checks for new properties uploaded
        /// </summary>
        private static readonly PropertyChecker Checker = new PropertyChecker(new HtmlPropertyScraper());
        
        /// <summary>
        /// Main entrypoint
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Bot.BotReady += (sender, client) =>
            {
                Checker.NewPropertyEvent += OnNewProperty;
                Checker.StartRoutine();
            };
            Bot.RunAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Event for when a new property has been found
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void OnNewProperty(object sender, PropertyFoundEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Property.PropertyTile);
            Bot.SendProperty(eventArgs.Property)
                .GetAwaiter()
                .GetResult();
        }
    }
}