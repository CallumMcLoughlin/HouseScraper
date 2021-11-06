using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Scraper.Output
{
    public class JsonFileWriter : IWriter<List<Property>>
    {
        private readonly string _filepath;
        
        public JsonFileWriter(string filepath)
        {
            _filepath = filepath;
            if (!File.Exists(_filepath))
            {
                using (File.Create(_filepath)) { }
            }
        }
        
        public void WriteAllLines(List<Property> contents)
        {
            File.WriteAllText(_filepath, JsonSerializer.Serialize(contents, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}