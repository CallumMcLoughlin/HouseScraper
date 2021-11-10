using System.Collections.Generic;

namespace HouseScraper.Scraper.ScrapeItems
{
    /// <summary>
    /// Factory to make new properties
    /// </summary>
    public class PropertyFactory : AbstractItemFactory<Property>
    {
        /// <summary>
        /// Make new property from list of stringified attributes
        /// </summary>
        /// <param name="strings">List of strings to match property attributes</param>
        /// <returns>Property</returns>
        public override Property FromStringList(List<string> strings)
        {
            return new Property(strings[0], strings[1], strings[2], strings[3], strings[4], strings[5]);
        }
    }
}