using Moq;
using NUnit.Framework;
using NodaTime;


namespace JonSkeetDesignPatterns
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
