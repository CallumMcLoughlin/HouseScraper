using System;
using System.Text.Json.Serialization;

namespace HouseScraper.Scraper.ScrapeItems
{
    [Serializable]
    public class Property : IEquatable<Property>
    {
        [JsonPropertyName("Url")]
        public string Url { get; set; }
        
        [JsonPropertyName("PropertyTitle")]
        public string PropertyTile { get; set; }

        [JsonPropertyName("Bedrooms")]
        public string Bedrooms { get; set; }

        [JsonPropertyName("Bathrooms")]
        public string Bathrooms { get; set; }

        [JsonPropertyName("Cost")]
        public string Cost { get; set; }

        public Property() { }
        
        public Property(string url, string title, string bedrooms, string bathrooms, string cost)
        {
            Url = url;
            PropertyTile = title;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Cost = cost;
        }

        public bool Equals(Property other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Url == other.Url && PropertyTile == other.PropertyTile && Bedrooms == other.Bedrooms && Bathrooms == other.Bathrooms && Cost == other.Cost;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Property) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Url != null ? Url.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (PropertyTile != null ? PropertyTile.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Bedrooms != null ? Bedrooms.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Bathrooms != null ? Bathrooms.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Cost != null ? Cost.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}