namespace HouseScraper.Scraper.Web
{
    public interface IScraper<out T>
    {
        T Scrape();
    }
}