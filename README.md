## About The Project

TradeMe Property Scraper

This is a script that is able to poll and scrape TradeMe rental properties using a predefined search criteria URL and a few other configuration variables. 
Mainly used to keep track and alert of any new properties being added onto TradeMe. 

Outputs results in a json format, and also to a Discord channel through a bot.

## Getting Started

Clone and open the project in your favorite IDE/Editor!

## Prerequisites

- .NET 5.0 SDK (For building and deploying)
- .NET 5.0 Runtime
- Docker (optional)
- Docker-compose (optional)

### Running the Project

This program is designed to work with .NET 5.0 and can be run independently or within a Docker container.

To run independently:
```sh
cd /path/to/repo
dotnet run
```

Alternatively, you're able to publish the application, [in that case follow the following guide](https://docs.microsoft.com/en-us/dotnet/core/deploying/#examples).

#### Running within Docker

- (Requires Docker, Docker-Compose)

To run as a docker container, some initial set up is required, build the container with the following command
```
cd /path/to/repo
docker build -t my_docker_container ./
```

Then to start the application
```
docker-compose up -d
```

And to stop

```
docker-compose down
```

From within the repo folder.

## Configuration

This repo comes with a base `settings.json` file that needs some variables in order to run properly. 

For TradeMe in particular, to find the url needed [go here](https://www.trademe.co.nz/a/property/residential/rent), 
enter in your filters and then click search. The corresponding URL in the browser is your main url. The base url 
 for TradeMe in particular is `https://www.trademe.co.nz/a/` which is to be prepended to every link. 

An example config for finding rental properties in Auckland for specific
suburbs and bedrooms:

```json
{
  "WebConfig" : {
    "Url": "https://www.trademe.co.nz/a/property/residential/rent/auckland/auckland-city/search?suburb=149&suburb=89&suburb=125&bedrooms_min=3",
    "BaseUrl": "https://www.trademe.co.nz/a/",
    "Pageable": true,
    "PaginationValue": "&page=",
    "Polltime": 7200
  },
  
  "FileConfig": {
    "OutputFile": "data.json"
  },
  
  "DiscordConfig": {
    "DiscordToken": "",
    "ChannelId": 1234567
  }
}
```

### Config Variables

- WebConfig
    - Url, Url to scrape
    - BaseUrl, Url prepended to all results to make them valid links (scraping doesn't give the base domain)
    - Pageable, Does the website have multiple pages of search results
    - PaginationValue, If `Pageable` is true, this is the value appended to the search criteria to get the next page
    - Polltime, How long (in seconds) to wait before scraping again, default 2 hours.

- FileConfig
    - OutputFile, File to output all found properties

- DiscordConfig
    - DiscordToken, Token to log in to Discord bot
    - ChannelId, Where to post new scraped items

## Additional Notes

**FOR EDUCATIONAL USE ONLY, DO NOT USE THIS ON ANY LIVE WEBSITE**

## Contributing

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Acknowledgements
* [dotnet](https://github.com/dotnet)
* [Html Agility Pack](https://html-agility-pack.net/)
* [Discord.Net](https://github.com/discord-net/Discord.Net)