using System;
using HouseScraper.Config;
using HouseScraper.Events;
using HouseScraper.Scraper.Checker;
using HouseScraper.Scraper.ScrapeItems;
using HouseScraper.Scraper.Web;
using HouseScraper.Web;

namespace HouseScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            FileConfig config = ConfigurationManager.Instance.GetConfig<FileConfig>();
            PropertyChecker checker = new PropertyChecker(new HtmlPropertyScraper(), new FileReader(config.OutputFile));
            checker.NewPropertyEvent += OnNewProperty;
            checker.StartRoutine();
            Console.ReadLine();
        }

        private static void OnNewProperty(object sender, PropertyFoundEventArgs eventArgs)
        {
            Property property = eventArgs.Property;
            Console.WriteLine($"{property.PropertyTile}");
            Console.WriteLine($"{property.Cost}");
            Console.WriteLine($"Bedrooms: {property.Bedrooms}, Bathrooms: {property.Bathrooms}");
            Console.WriteLine($"{property.Url}");
            Console.WriteLine("");
        }
    }
}