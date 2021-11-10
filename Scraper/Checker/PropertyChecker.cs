using System;
using System.Collections.Generic;
using System.Threading;
using HouseScraper.Config;
using HouseScraper.Output;
using HouseScraper.Scraper.ScrapeItems;
using HouseScraper.Scraper.Web;

namespace HouseScraper.Scraper.Checker
{
    /// <summary>
    /// Checker for checking for new properties
    /// </summary>
    public class PropertyChecker : AbstractChecker
    {
        /// <summary>
        /// New property found event, fired whenever a new property is found
        /// </summary>
        public event EventHandler<PropertyFoundEventArgs> NewPropertyEvent;
        private Timer _eventTimer;
        
        private readonly WebConfig _webConfig = ConfigurationManager.Instance.GetConfig<WebConfig>();
        private readonly FileConfig _fileConfig = ConfigurationManager.Instance.GetConfig<FileConfig>();
        
        private readonly IScraper<List<Property>> _scraper;
        private readonly IReader<List<Property>> _reader;
        private readonly IWriter<List<Property>> _writer;

        private readonly List<Property> _properties = new List<Property>();
        private readonly HashSet<string> _propertyLookup = new HashSet<string>();

        /// <summary>
        /// Constructor, initializes what type of scraper to use
        /// </summary>
        /// <param name="propertyScraper"></param>
        public PropertyChecker(IScraper<List<Property>> propertyScraper)
        {
            _scraper = propertyScraper;
            _reader = new JsonFileReader(_fileConfig.OutputFile);
            _writer = new JsonFileWriter(_fileConfig.OutputFile);
            
            Initialize();
        }

        /// <summary>
        /// Read from reader all found properties
        /// </summary>
        private void Initialize()
        {
            _properties.AddRange(_reader.ReadAllLines());
            
            foreach (Property property in _properties)
            {
                _propertyLookup.Add(property.PropertyTile);
            }
        }

        /// <summary>
        /// Start property check routine
        /// </summary>
        public override void StartRoutine()
        {
            _eventTimer = new Timer(e =>
            {
                OnLoop();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(_webConfig.Polltime));
        }

        /// <summary>
        /// Loop to check for new properties
        /// </summary>
        protected override void OnLoop()
        {
            Console.WriteLine($"New Scrape Started {DateTime.Now}");
            
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

        /// <summary>
        /// When a new property is found, emit event with property
        /// </summary>
        /// <param name="baseEventArgs">PropertyFoundEvent with found property</param>
        private void OnCheckNotifyEvent(PropertyFoundEventArgs baseEventArgs)
        {
            NewPropertyEvent?.Invoke(this, baseEventArgs);
        }

        /// <summary>
        /// Stop check routine
        /// </summary>
        public override void StopRoutine()
        {
            _eventTimer.Dispose();
        }
    }
}