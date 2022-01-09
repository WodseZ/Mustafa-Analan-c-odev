using System;
using System.Globalization;

namespace HaftaBasSon
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int thisWeekNumber = GetIso8601WeekOfYear(DateTime.Today);
            int year = DateTime.Now.Year;
            DateTime firstDayOfWeek = FirstDateOfWeek(year, thisWeekNumber, CultureInfo.CurrentCulture);
            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);
            Console.WriteLine("Haftanın ilk günü = " + firstDayOfWeek.Day);
            Console.WriteLine("Haftanın son günü = " + lastDayOfWeek.Day);

            Console.ReadLine();
        }

        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
    }
}