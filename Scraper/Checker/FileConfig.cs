using System;
using System.Text.Json.Serialization;
using HouseScraper.Config;

namespace HouseScraper.Scraper.Checker
{
    [Serializable]
    public class FileConfig : IConfig
    {
        [JsonPropertyName("OutputFile")]
        public string OutputFile { get; set; }
    }
}