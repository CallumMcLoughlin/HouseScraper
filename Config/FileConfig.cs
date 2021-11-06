using System;
using System.Text.Json.Serialization;

namespace HouseScraper.Config
{
    [Serializable]
    public class FileConfig : IConfig
    {
        [JsonPropertyName("OutputFile")]
        public string OutputFile { get; set; }
    }
}