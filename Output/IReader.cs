namespace HouseScraper.Output
{
    /// <summary>
    /// Interface for readers
    /// </summary>
    /// <typeparam name="T">Type to return when reading</typeparam>
    public interface IReader<out T>
    {
        /// <summary>
        /// Read all lines
        /// </summary>
        /// <returns>Type to return when reading</returns>
        public T ReadAllLines();
    }
}