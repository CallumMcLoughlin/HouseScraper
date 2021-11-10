using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using HouseScraper.Scraper.ScrapeItems;

namespace HouseScraper.Output
{
    /// <summary>
    /// Write JSON formatted objects to a file
    /// </summary>
    public class JsonFileWriter : IWriter<List<Property>>
    {
        private readonly string _filepath;
        
        /// <summary>
        /// Constructor, sets and optionally creates file to write to
        /// </summary>
        /// <param name="filepath"></param>
        public JsonFileWriter(string filepath)
        {
            _filepath = filepath;
            if (!File.Exists(_filepath))
            {
                using (File.Create(_filepath)) { }
            }
        }
        
        /// <summary>
        /// Write all property objects to a file from a list of properties
        /// </summary>
        /// <param name="contents">List of property objects</param>
        public void WriteAllLines(List<Property> contents)
        {
            File.WriteAllText(_filepath, JsonSerializer.Serialize(contents, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}