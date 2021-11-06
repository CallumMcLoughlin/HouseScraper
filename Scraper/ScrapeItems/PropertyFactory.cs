using System.Collections.Generic;

namespace HouseScraper.Scraper.ScrapeItems
{
    public class PropertyFactory : AbstractItemFactory<Property>
    {
        public override Property FromStringList(List<string> strings)
        {
            return new Property(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5]);
        }
    }
}