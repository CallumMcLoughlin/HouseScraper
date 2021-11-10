using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Scraper.Checker
{
    /// <summary>
    /// Event fired when a new property is found
    /// </summary>
    public class PropertyFoundEventArgs : CheckerBaseEventArgs
    {
        /// <summary>
        /// Found property
        /// </summary>
        public Property Property { get; set; }
    }
}