using System;

namespace Ps4_Pkg_Sender.Utilities {
    public class TimeFormatUtil {

        private static string FormatDay(double days, bool minimal) {
            return FormatTime(days, minimal ? "d" : "day");
        }

        private static string FormatHour(double hours, bool minimal) {
            return FormatTime(hours, minimal ? "h" : "hr");
        }

        private static string FormatMinutes(double minutes, bool minimal) {
            return FormatTime(minutes, minimal ? "m" : "min");
        }

        private static string FormatSeconds(double seconds, bool minimal) {
            return FormatTime(seconds, minimal ? "s" : "sec");
        }

        private static string FormatTime(double x, String nonPlural) {
            //Checks whether or not a plural should be added
            string str = nonPlural;
            if (x > 1)
                str += "s";

            return $"{x} {str} ";
        }

        public static String GetCountdownFormat(double timeInSeconds, bool minimalFormat) {
            var duration = TimeSpan.FromSeconds(timeInSeconds);
            long days = duration.Days;
            long hours = duration.Hours;
            int minutes = duration.Minutes;
            int seconds = duration.Seconds;
            String timeString = "";
            if (days > 0) {
                timeString += FormatDay(days, minimalFormat);
            }
            if (hours > 0) {
                timeString += FormatHour(hours, minimalFormat);
            }
            if (minutes > 0) {
                timeString += FormatMinutes(minutes, minimalFormat);
            }
            if (seconds > 0) {
                timeString += FormatSeconds(seconds, minimalFormat);
            }
            return timeString;
        }
    }
}
