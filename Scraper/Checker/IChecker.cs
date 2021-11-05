using System;

namespace HouseScraper.Web
{
    public interface IChecker
    {
        public abstract void StartRoutine();
        public abstract void StopRoutine();
    }
}