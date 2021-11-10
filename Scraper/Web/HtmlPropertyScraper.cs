using System.Collections.Generic;
using System.Linq;
using HouseScraper.Config;
using HouseScraper.Scraper.ScrapeItems;
using HtmlAgilityPack;

namespace HouseScraper.Scraper.Web
{
    /// <summary>
    /// Scraper to scrape items from HTML
    /// </summary>
    public class HtmlPropertyScraper : IScraper<List<Property>>
    {
        private readonly HtmlWeb _htmlViewer = new HtmlWeb();
        private readonly PropertyFactory _factory = new PropertyFactory();
        private readonly WebConfig _config;

        /// <summary>
        /// Constructor, reads configuration 
        /// </summary>
        public HtmlPropertyScraper()
        {
            _config = ConfigurationManager.Instance.GetConfig<WebConfig>();
        }

        /// <summary>
        /// Scrape HTML and find all properties
        /// </summary>
        /// <returns>List of properties scraped</returns>
        public List<Property> Scrape()
        {
            // If the website we're scraping has pages, loop through all pages
            if (_config.Pageable)
            {
                int currentPage = 1;
                HtmlDocument document = _htmlViewer.Load(_config.Url + _config.PaginationValue + currentPage);
                List<Property> currentProperties = GetProperties(document);
                List<Property> allProperties = new List<Property>();
                while (currentProperties != null)
                {
                    allProperties.AddRange(currentProperties);

                    currentPage++;
                    document = _htmlViewer.Load(_config.Url + _config.PaginationValue + currentPage);
                    currentProperties = GetProperties(document);
                }

                return allProperties;
            }
            else
            {
                HtmlDocument document = _htmlViewer.Load(_config.Url);
                return GetProperties(document);
            }
        }

        /// <summary>
        /// Get all properties from specific HTML page
        /// </summary>
        /// <param name="document">HTML page</param>
        /// <returns>List of properties on document</returns>
        private List<Property> GetProperties(HtmlDocument document)
        {
            //Skip first two, they're always ads
            return document.DocumentNode
                .SelectNodes("//tg-col[@order]")?
                .Skip(2)
                .Select(ParseHtmlNode)
                .ToList();
            
        }

        /// <summary>
        /// Parse a specific HTML node to retrieve a singular property
        /// </summary>
        /// <param name="node">Html node</param>
        /// <returns>Property</returns>
        private Property ParseHtmlNode(HtmlNode node)
        {
            string url = node.ChildNodes.FindFirst("a").GetAttributeValue("href", string.Empty);
            if (url != string.Empty)
            {
                url = _config.BaseUrl + url;
            }

            string imageUrl = node.ChildNodes.FindFirst("picture")?.ChildNodes.FindFirst("img")?.GetAttributeValue("src", string.Empty);
            string title = node.ChildNodes.FindFirst("tm-property-search-card-listing-title").InnerText;
            string bedAndBath = node.ChildNodes.FindFirst("tm-property-search-card-attribute-icons").InnerText;
            string beds = bedAndBath.Split(' ')[1];
            string baths = bedAndBath.Split(' ')[3];
            string price = node.ChildNodes.FindFirst("tm-property-search-card-price-attribute").InnerText;

            List<string> values = new List<string>()
            {
                url, imageUrl, title, beds, baths, price
            };
            
            return _factory.FromStringList(values);
        }
    }
}