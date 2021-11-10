using System;
using System.Text.Json.Serialization;
using HouseScraper.Config;

namespace HouseScraper.Scraper.Checker
{
    /// <summary>
    /// Configuration for output file for checkers
    /// </summary>
    [Serializable]
    public class FileConfig : IConfig
    {
        [JsonPropertyName("OutputFile")]
        public string OutputFile { get; set; }
    }
}