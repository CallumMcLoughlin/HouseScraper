namespace HouseScraper.Scraper.Web
{
    /// <summary>
    /// Interface for defining scraper objects
    /// </summary>
    /// <typeparam name="T">Type to scrape</typeparam>
    public interface IScraper<out T>
    {
        /// <summary>
        /// Perform a scrape
        /// </summary>
        /// <returns>Type to scrape</returns>
        T Scrape();
    }
}