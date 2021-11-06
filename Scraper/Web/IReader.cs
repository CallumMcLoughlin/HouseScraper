namespace HouseScraper.Scraper.Web
{
    public interface IReader<out T>
    {
        public T ReadAllLines();
    }
}