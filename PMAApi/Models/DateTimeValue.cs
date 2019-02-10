using System;
using System.Globalization;

namespace PMA
{
    /// <summary>
    ///  Formated date display POCO
    /// </summary>
    public class DateTimeValue
    {

        public DateTimeValue()
        {

        }

        public string DayStr { get; set; }
        public bool UrlParams { get; set; }
        public DateTime CalDate { get; set; }

        /// <summary>
        /// determines day offset to previous sunday from current date
        /// </summary>
        /// <returns></returns>
        public static int GetOffSet()
        {
            DayOfWeek dow = DateTime.Parse(DateTime.Now.ToString(CultureInfo.CurrentCulture)).DayOfWeek;
            var down = (int)Enum.Parse(typeof(DayNumberOfWeek), dow.ToString());
            int offset = (0 - down);

            return offset;
        }
    }

    /// <summary>
    /// new date POCO
    /// </summary>
    public class NewDate
    {
        public DateTime CalDate { get; set; }
    }

    /// <summary>
    /// Day of week enum
    /// </summary>
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