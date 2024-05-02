namespace UKW.Util.time {
    public static class DateTimeUtil {
        public static long currentTimeMillis() {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + 32400000; // 대한민국 표준시 기준 +9시간(32400000ms) 추가
        }

        public static string timeStampToFormatString(this long timeLongMs, string format = "yyyy-MM-dd HH:mm:ss") {
            return DateTimeOffset.FromUnixTimeMilliseconds(timeLongMs).ToString(format);
        }

        public static DateTime timeStampToDateTime(long ticks) {
            return DateTimeOffset.FromUnixTimeSeconds(ticks).DateTime;
        }
    }
}
