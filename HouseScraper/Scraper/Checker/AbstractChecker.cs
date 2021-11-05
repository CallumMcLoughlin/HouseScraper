using HouseScraper.Events;
using HouseScraper.Web;

namespace HouseScraper.Checker
{
    public abstract class AbstractChecker : IChecker
    {
        public abstract void StartRoutine();
        public abstract void StopRoutine();
        protected abstract void OnLoop();
    }
}