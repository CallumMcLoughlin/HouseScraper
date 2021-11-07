using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Output
{
    public class JsonFileReader : IReader<List<Property>>
    {
        private readonly string _filepath;
        
        public JsonFileReader(string filepath)
        {
            _filepath = filepath;
            if (!File.Exists(_filepath))
            {
                using (File.Create(_filepath)) { }
            }
        }
        
        public List<Property> ReadAllLines()
        {
            List<Property> properties = new List<Property>();
            string jsonString = File.ReadAllText(_filepath);

            if (jsonString != "")
            {
                using JsonDocument document = JsonDocument.Parse(jsonString);
                properties = document.RootElement.Deserialize<List<Property>>();
            }
            
            return properties;
        }
    }
}