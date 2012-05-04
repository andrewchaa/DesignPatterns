using NodaTime;

namespace JonSkeetDesignPatterns
{
    public class License
    {
        private readonly Instant _expiry;
        private readonly IClock _clock;

        public License(Instant expiry, IClock clock)
        {
            _expiry = expiry;
            _clock = clock;
        }

        public bool HasExpired
        {
            get { return _clock.Now >= _expiry; }
        }
    }
}
