namespace HouseScraper.Output
{
    public class FileReader : IReader<string[]>
    {
        private readonly string _filepath;
        
        public FileReader(string filepath)
        {
            _filepath = filepath;
            if (!System.IO.File.Exists(_filepath))
            {
                using (System.IO.File.Create(_filepath)) { }
            }
        }

        public string[] ReadAllLines()
        {
            return System.IO.File.ReadAllLines(_filepath);
        }
    }
}