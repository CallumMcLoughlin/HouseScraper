namespace HouseScraper.Config
{
    /// <summary>
    /// IConfiguration interface specifying classes that can retrieve config
    /// </summary>
    public interface IConfiguration
    {
        T GetConfig<T>() where T : IConfig;
    }
}