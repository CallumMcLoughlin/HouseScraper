namespace HouseScraper.Web
{
    public interface IScraper<out T>
    {
        T Scrape();
    }
}