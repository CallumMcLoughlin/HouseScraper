using System.Text.Json.Serialization;

namespace HouseScraper.Config
{
    public class FileConfig : IConfig
    {
        [JsonPropertyName("OutputFile")]
        public string OutputFile { get; set; }
    }
}