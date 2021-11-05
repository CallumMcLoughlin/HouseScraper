using System.Text.Json.Serialization;

namespace HouseScraper.Config
{
    public class WebConfig : IConfig
    {
        [JsonPropertyName("Url")] 
        public string Url { get; set; }
        
        [JsonPropertyName("Pageable")] 
        public bool Pageable { get; set; }
        
        [JsonPropertyName("PaginationValue")] 
        public string PaginationValue { get; set; }
        
        [JsonPropertyName("Polltime")]
        public long Polltime { get; set; }
    }
}