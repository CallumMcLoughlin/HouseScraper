namespace HouseScraper.Scraper.Web
{
    public interface IWriter<in T>
    {
        public void WriteAllLines(T contents);
    }
}