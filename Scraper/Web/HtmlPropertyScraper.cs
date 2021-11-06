using System.Collections.Generic;
using System.IO;
using System.Linq;
using HouseScraper.Config;
using HouseScraper.Scraper.ScrapeItems;
using HtmlAgilityPack;

namespace HouseScraper.Scraper.Web
{
    public class HtmlPropertyScraper : IScraper<List<Property>>
    {
        private readonly HtmlWeb _htmlViewer = new HtmlWeb();
        private readonly PropertyFactory _factory = new PropertyFactory();
        private readonly WebConfig _config;

        public HtmlPropertyScraper()
        {
            _config = ConfigurationManager.Instance.GetConfig<WebConfig>();
        }

        public List<Property> Scrape()
        {
            _config.Pageable = false;

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
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(File.ReadAllText("out.txt"));
                //HtmlDocument document = _htmlViewer.Load(_config.Url);
                return GetProperties(document);
            }
        }

        private List<Property> GetProperties(HtmlDocument document)
        {
            return document.DocumentNode
                .SelectNodes("//tg-col[@order]")?
                .Skip(2)
                .Select(ParseHtmlNode)
                .ToList();
            
        }

        private Property ParseHtmlNode(HtmlNode node)
        {
            string url = node.ChildNodes.FindFirst("a").GetAttributeValue("href", string.Empty);
            string title = node.ChildNodes.FindFirst("tm-property-search-card-listing-title").InnerText;
            string bedAndBath = node.ChildNodes.FindFirst("tm-property-search-card-attribute-icons").InnerText;
            string beds = bedAndBath.Split(' ')[1];
            string baths = bedAndBath.Split(' ')[3];
            string price = node.ChildNodes.FindFirst("tm-property-search-card-price-attribute").InnerText;

            List<string> values = new List<string>()
            {
                url, title, beds, baths, price
            };
            
            return _factory.FromStringList(values);
        }
    }
}