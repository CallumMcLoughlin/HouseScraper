namespace HouseScraper.Output
{
    /// <summary>
    /// FileReader to read list of strings from a file
    /// </summary>
    public class FileReader : IReader<string[]>
    {
        private readonly string _filepath;
        
        /// <summary>
        /// Constructor, sets file to read, creates it if it doesn't exist
        /// </summary>
        /// <param name="filepath"></param>
        public FileReader(string filepath)
        {
            _filepath = filepath;
            if (!System.IO.File.Exists(_filepath))
            {
                using (System.IO.File.Create(_filepath)) { }
            }
        }
        
        /// <summary>
        /// Read all lines from specified file
        /// </summary>
        /// <returns>List of lines</returns>
        public string[] ReadAllLines()
        {
            return System.IO.File.ReadAllLines(_filepath);
        }
    }
}