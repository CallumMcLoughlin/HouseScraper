using System;
using System.Text.Json.Serialization;
using HouseScraper.Config;

namespace HouseScraper.Scraper.Web
{
    /// <summary>
    /// Configuration for websites, defines url to scrape, whether it's pageable, and time between scrapes
    /// </summary>
    [Serializable]
    public class WebConfig : IConfig
    {
        [JsonPropertyName("Url")] 
        public string Url { get; set; }
        
        [JsonPropertyName("BaseUrl")] 
        public string BaseUrl { get; set; }
        
        [JsonPropertyName("Pageable")] 
        public bool Pageable { get; set; }
        
        [JsonPropertyName("PaginationValue")] 
        public string PaginationValue { get; set; }
        
        [JsonPropertyName("Polltime")]
        public long Polltime { get; set; }
    }
}