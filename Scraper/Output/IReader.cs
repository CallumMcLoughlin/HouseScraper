namespace HouseScraper.Scraper.Output
{
    public interface IReader<out T>
    {
        public T ReadAllLines();
    }
}