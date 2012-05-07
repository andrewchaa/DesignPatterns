using System;
using JonSkeetDesignPatterns;
using JonSkeetDesignPatterns.DependencyInjection;

namespace DesignPatterns.DependencyInjection
{
    public class DiaryPresenter
    {
        private readonly Diary _diary;
        private readonly License _license;

        public DiaryPresenter(Diary diary, License license)
        {
            _diary = diary;
            _license = license;
        }

        public void Start()
        {
            Console.WriteLine("Today is: {0}", _diary.FormatToday());
            Console.WriteLine("License expired? {0}", _license.HasExpired);
        }
    }
}
