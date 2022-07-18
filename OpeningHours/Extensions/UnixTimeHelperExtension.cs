using System;

namespace OpeningHours.Extensions
{

    public static class UnixTimeHelperExtension
    {

        public static long ToUnixTime(this DateTime time)
        {
            var totalSeconds = (long)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


            return totalSeconds;
        }
     
        public static DateTime ToDateTime(this long unixTime)
        {
            return new DateTime(1970, 1, 1).Add(TimeSpan.FromSeconds(unixTime));
        }

        public static string TimeofTheDay(this DateTime dateTime)
        {
            var t = dateTime.TimeOfDay;

            return new DateTime(t.Ticks).ToString("h:mm tt");
        }
    }

}
