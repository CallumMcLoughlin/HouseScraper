using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Events.Scraper
{
    public class PropertyFoundEventArgs : CheckerBaseEventArgs
    {
        public Property Property { get; set; }
    }
}