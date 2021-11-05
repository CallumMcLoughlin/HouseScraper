using System.Collections.Generic;

namespace HouseScraper.Scraper.ScrapeItems
{
    public abstract class AbstractItemFactory<T>
    {
        public abstract T FromStringList(List<string> strings);
    }
}