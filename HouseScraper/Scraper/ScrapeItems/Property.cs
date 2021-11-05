namespace HouseScraper.Scraper.ScrapeItems
{
    public class Property
    {
        public string Url { get; }
        public string PropertyTile { get; }
        public string Bedrooms { get; }
        public string Bathrooms { get; }
        public string Cost { get; }

        public Property(string url, string title, string bedrooms, string bathrooms, string cost)
        {
            Url = url;
            PropertyTile = title;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            Cost = cost;
        }
    }
}