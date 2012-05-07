using DesignPatterns;
using DesignPatterns.DependencyInjection;
using NodaTime;

namespace JonSkeetDesignPatterns.DependencyInjection
{
    public class CustomInjector
    {
        public IClock CreateClock()
        {
            return SystemClock.Instance;
        }

        public License CreateLicense()
        {
            return new License(Instant.UnixEpoch, CreateClock());
        }

        public Diary CreateDiary()
        {
            return new Diary(CreateClock(), CalendarSystem.Iso, DateTimeZone.GetSystemDefault());
        }

        public DiaryPresenter CreateDiaryPresenter()
        {
            return new DiaryPresenter(CreateDiary(), CreateLicense());
        }
    }
}
