using System.Collections.Generic;

namespace HouseScraper.Scraper.ScrapeItems
{
    /// <summary>
    /// Abstract factory for getting items
    /// </summary>
    /// <typeparam name="T">Type of item to make</typeparam>
    public abstract class AbstractItemFactory<T>
    {
        /// <summary>
        /// Make a new item from a list of strings
        /// </summary>
        /// <param name="strings">Strings of item attributes</param>
        /// <returns>Item</returns>
        public abstract T FromStringList(List<string> strings);
    }
}