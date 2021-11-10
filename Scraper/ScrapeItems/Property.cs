using System;
using System.Text.Json.Serialization;

namespace HouseScraper.Scraper.ScrapeItems
{
    /// <summary>
    /// Property class, contains information about a single property
    /// </summary>
    [Serializable]
    public class Property : IEquatable<Property>
    {
        [JsonPropertyName("Url")]
        public string Url { get; set; }

        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }
        
        [JsonPropertyName("PropertyTitle")]
        public string PropertyTile { get; set; }

        [JsonPropertyName("Bedrooms")]
        public string Bedrooms { get; set; }

        [JsonPropertyName("Bathrooms")]
        public string Bathrooms { get; set; }

        [JsonPropertyName("Cost")]
        public string Cost { get; set; }

        public Property() { }

        /// <summary>
        /// Make new property from stringified values
        /// </summary>
        /// <param name="url">Url of property</param>
        /// <param name="imageUrl">Image url of property</param>
        /// <param name="title">Title of property</param>
        /// <param name="bedrooms">Number of bedrooms</param>
        /// <param name="bathrooms">Number of bathrooms</param>
        /// <param name="cost">Cost of property</param>
        public Property(string url, string imageUrl, string title, string bedrooms, string bathrooms, string cost)
        {
            Url = url;
            ImageUrl = imageUrl;
            PropertyTile = title;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Cost = cost;
        }

        /// <summary>
        /// Compare two properties
        /// </summary>
        /// <param name="other">Other property to compare to</param>
        /// <returns>True if properties are equal, false otherwise</returns>
        public bool Equals(Property other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Url == other.Url && PropertyTile == other.PropertyTile && Bedrooms == other.Bedrooms && Bathrooms == other.Bathrooms && Cost == other.Cost;
        }

        /// <summary>
        /// Compare two properties
        /// </summary>
        /// <param name="obj">Other property to compare to</param>
        /// <returns>True if properties are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Property) obj);
        }

        /// <summary>
        /// Get hash of property
        /// </summary>
        /// <returns>Hash of property</returns>
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