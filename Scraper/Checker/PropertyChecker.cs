using System;
using System.Collections.Generic;
using System.Threading;
using HouseScraper.Checker;
using HouseScraper.Config;
using HouseScraper.Events;
using HouseScraper.Scraper.ScrapeItems;
using HouseScraper.Web;

namespace HouseScraper.Scraper.Checker
{
    public class PropertyChecker : AbstractChecker
    {
        public event EventHandler<PropertyFoundEventArgs> NewPropertyEvent;
        private Timer _eventTimer;
        
        private readonly WebConfig _config;
        
        private readonly IScraper<List<Property>> _scraper;
        private readonly IReader<string[]> _reader;
        private readonly HashSet<string> _propertyLookup = new HashSet<string>();
        
        public PropertyChecker(IScraper<List<Property>> propertyScraper, IReader<string[]> reader)
        {
            _config = ConfigurationManager.Instance.GetConfig<WebConfig>();
            _scraper = propertyScraper;
            _reader = reader;
            
            Initialize();
        }

        private void Initialize()
        {
            foreach (string line in _reader.ReadAllLines())
            {
//                _propertyLookup.Add(line);
            }
        }

        public override void StartRoutine()
        {
            _eventTimer = new Timer(e =>
            {
                OnLoop();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(_config.Polltime));
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
                    _propertyLookup.Add(scrapedProperty.PropertyTile);
                    OnCheckNotifyEvent(foundEventArgs);
                }
            }
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