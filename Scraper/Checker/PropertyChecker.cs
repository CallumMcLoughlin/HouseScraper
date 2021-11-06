using System;
using System.Collections.Generic;
using System.Threading;
using HouseScraper.Config;
using HouseScraper.Events.Scraper;
using HouseScraper.Scraper.ScrapeItems;
using HouseScraper.Scraper.Web;

namespace HouseScraper.Scraper.Checker
{
    public class PropertyChecker : AbstractChecker
    {
        public event EventHandler<PropertyFoundEventArgs> NewPropertyEvent;
        private Timer _eventTimer;
        
        private readonly WebConfig _webConfig = ConfigurationManager.Instance.GetConfig<WebConfig>();
        private readonly FileConfig _fileConfig = ConfigurationManager.Instance.GetConfig<FileConfig>();
        
        private readonly IScraper<List<Property>> _scraper;
        private readonly IReader<List<Property>> _reader;
        private readonly IWriter<List<Property>> _writer;

        private readonly List<Property> _properties = new List<Property>();
        private readonly HashSet<string> _propertyLookup = new HashSet<string>();
        
        public PropertyChecker(IScraper<List<Property>> propertyScraper)
        {
            _scraper = propertyScraper;
            _reader = new JsonFileReader(_fileConfig.OutputFile);
            _writer = new JsonFileWriter(_fileConfig.OutputFile);
            
            Initialize();
        }

        private void Initialize()
        {
            _properties.AddRange(_reader.ReadAllLines());
            
            foreach (Property property in _properties)
            {
                _propertyLookup.Add(property.PropertyTile);
            }
        }

        public override void StartRoutine()
        {
            _eventTimer = new Timer(e =>
            {
                OnLoop();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(_webConfig.Polltime));
        }

        protected override void OnLoop()
        {
            List<Property> scrapedProperties = _scraper.Scrape();
            foreach (Property scrapedProperty in scrapedProperties)
            {
                if (!_propertyLookup.Contains(scrapedProperty.PropertyTile))
                {
                    PropertyFoundEventArgs foundEventArgs = new PropertyFoundEventArgs
                    {
                        Property = scrapedProperty
                    };
                    _properties.Add(scrapedProperty);
                    _propertyLookup.Add(scrapedProperty.PropertyTile);
                    OnCheckNotifyEvent(foundEventArgs);
                }
            }
            
            _writer.WriteAllLines(_properties);
        }
        
        private void OnCheckNotifyEvent(PropertyFoundEventArgs baseEventArgs)
        {
            NewPropertyEvent?.Invoke(this, baseEventArgs);
        }

        public override void StopRoutine()
        {
            _eventTimer.Dispose();
        }
    }
}