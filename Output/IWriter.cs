namespace HouseScraper.Output
{
    /// <summary>
    /// Interface for writers
    /// </summary>
    /// <typeparam name="T">Type to write when writing</typeparam>
    public interface IWriter<in T>
    {
        /// <summary>
        /// Write all lines to a file
        /// </summary>
        /// <typeparam name="T">Type of contents to write to file</typeparam>
        public void WriteAllLines(T contents);
    }
}