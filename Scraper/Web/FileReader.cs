using System.IO;

namespace HouseScraper.Scraper.Web
{
    public class FileReader : IReader<string[]>
    {
        private readonly string _filepath;
        
        public FileReader(string filepath)
        {
            _filepath = filepath;
            if (!File.Exists(_filepath))
            {
                using (File.Create(_filepath)) { }
            }
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(_filepath);
        }
    }
}