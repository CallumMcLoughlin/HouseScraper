using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Scraper.Checker
{
    public class PropertyFoundEventArgs : CheckerBaseEventArgs
    {
        public Property Property { get; set; }
    }
}