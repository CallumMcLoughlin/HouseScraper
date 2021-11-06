namespace HouseScraper.Scraper.Checker
{
    public abstract class AbstractChecker
    {
        public abstract void StartRoutine();
        public abstract void StopRoutine();
        protected abstract void OnLoop();
    }
}