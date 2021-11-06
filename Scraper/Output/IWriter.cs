namespace HouseScraper.Scraper.Output
{
    public interface IWriter<in T>
    {
        public void WriteAllLines(T contents);
    }
}