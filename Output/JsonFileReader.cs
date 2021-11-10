using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Output
{
    /// <summary>
    /// Read JSON from a file
    /// </summary>
    public class JsonFileReader : IReader<List<Property>>
    {
        private readonly string _filepath;
        
        /// <summary>
        /// Constructor, sets and optionally creates file to read from
        /// </summary>
        /// <param name="filepath"></param>
        public JsonFileReader(string filepath)
        {
            _filepath = filepath;
            if (!File.Exists(_filepath))
            {
                using (File.Create(_filepath)) { }
            }
        }
        
        /// <summary>
        /// Read all JSON lines from file
        /// </summary>
        /// <returns>List of property objects</returns>
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