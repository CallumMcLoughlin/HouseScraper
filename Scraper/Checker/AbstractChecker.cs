namespace HouseScraper.Scraper.Checker
{
    /// <summary>
    /// Abstract base class for all checker objects
    /// </summary>
    public abstract class AbstractChecker
    {
        /// <summary>
        /// Start check routine
        /// </summary>
        public abstract void StartRoutine();

        /// <summary>
        /// Stop check routine
        /// </summary>
        public abstract void StopRoutine();
        
        /// <summary>
        /// Fired everytime a check is performed
        /// </summary>
        protected abstract void OnLoop();
    }
}