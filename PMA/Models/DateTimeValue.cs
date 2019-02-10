using System;
using System.Globalization;

namespace PMA
{
    public class DateTimeValue
    {
        public DateTimeValue()
        {

        }

        public string DayStr { get; set; }
        public bool UrlParams { get; set; }
        public DateTime CalDate { get; set; }

        public static int GetOffSet()
        {
            // determine date offset to previous sunday from selected date
            DayOfWeek dow = DateTime.Parse(DateTime.Now.ToString(CultureInfo.CurrentCulture)).DayOfWeek;
            var down = (int)Enum.Parse(typeof(DayNumberOfWeek), dow.ToString());
            int offset = (0 - down);

            return offset;
        }
    }

    public class NewDate
    {
        public DateTime CalDate { get; set; }
    }

    public enum DayNumberOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6
    }
}