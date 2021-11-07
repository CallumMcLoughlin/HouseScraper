namespace HouseScraper.Output
{
    public interface IReader<out T>
    {
        public T ReadAllLines();
    }
}