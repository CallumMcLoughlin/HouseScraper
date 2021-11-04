namespace HouseScraper.Config
{
    public interface IConfiguration
    {
        T GetConfig<T>() where T : IConfig;
    }
}