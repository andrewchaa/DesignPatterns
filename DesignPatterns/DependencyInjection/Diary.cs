using NodaTime;
using NodaTime.Text;

namespace JonSkeetDesignPatterns.DependencyInjection
{
    public class Diary
    {
        private readonly LocalDatePattern _outputPattern = LocalDatePattern.CreateWithInvariantInfo("yyyy-MM-dd");

        private readonly IClock _clock;
        private readonly CalendarSystem _calendar;
        private readonly DateTimeZone _timeZone;

        public Diary(IClock clock, CalendarSystem calendar, DateTimeZone timeZone)
        {
            _clock = clock;
            _calendar = calendar;
            _timeZone = timeZone;
        }

        public string FormatToday()
        {
            LocalDate date = _clock.Now.InZone(_timeZone, _calendar).LocalDateTime.Date;
            return _outputPattern.Format(date);

        }
    }
}
