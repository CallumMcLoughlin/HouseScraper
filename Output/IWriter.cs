namespace HouseScraper.Output
{
    public interface IWriter<in T>
    {
        public void WriteAllLines(T contents);
    }
}