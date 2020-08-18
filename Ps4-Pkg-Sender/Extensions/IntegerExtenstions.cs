namespace Ps4_Pkg_Sender.Extensions {
    public static class IntegerExtenstions {

        public static string SecondsToHumanReadableTime(this int timeInSeconds, bool minimalFormat) {
            return Utilities.TimeFormatUtil.GetCountdownFormat(timeInSeconds,minimalFormat);
        }

        public static long ToMilliseconds(this int num) {
            return num * 1000;
        }
    }
}
