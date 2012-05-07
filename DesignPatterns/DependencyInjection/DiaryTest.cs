using JonSkeetDesignPatterns.DependencyInjection;
using Moq;
using NUnit.Framework;
using NodaTime;

namespace DesignPatterns.DependencyInjection
{
    [TestFixture]
    public class DiaryTest
    {
        [Test]
        public void FormatToday_Iso_Utc()
        {
            var clock = new Mock<IClock>();
            var diary = new Diary(clock.Object, CalendarSystem.Iso, DateTimeZone.Utc);

            string today = diary.FormatToday();
            Assert.AreEqual("1970-01-01", today);
        }

        [Test]
        public void Main()
        {
            var injector = new CustomInjector();
            var presenter = injector.CreateDiaryPresenter();
            presenter.Start();
        }

        [Test]
        public void Main_With_Generic_Injector()
        {
            var injector = new Injector();
            injector.Bind<IClock, SystemClock>();
            injector.Bind<DateTimeZone>(DateTimeZone.GetSystemDefault());
            injector.Bind<Instant>(Instant.FromUtc(2000, 1,1,0,0,0));
            injector.Bind<CalendarSystem>(CalendarSystem.Iso);
            
            var presenter = injector.Resolve<DiaryPresenter>();
            presenter.Start();
        }

        /*
        [Test]
        public void FormatToday_Iso_Utc1()
        {
            var zone = DateTimeZone.ForOffset(Offset.FromHours(-8));
            var clock = new Mock<IClock>();
            var diary = new Diary(clock.Object, CalendarSystem.Iso, DateTimeZone.Utc);

            string today = diary.FormatToday();
            Assert.AreEqual("1970-01-01", today);
        }
        */

    }
}