using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Events
{
    public class PropertyFoundEventArgs : CheckerBaseEventArgs
    {
        public Property Property { get; set; }
    }
}