namespace HouseScraper.Web
{
    public interface IReader<out T>
    {
        public T ReadAllLines();
    }
}