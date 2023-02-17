using PingPongManagmantSystem.Domain.Constans;

namespace PingPongManagmantSystem.Service.Helpers
{
    public class TimeHelper
    {
        public static float GetCurrentServerTimeParseFloat()
        {
            var res = DateTime.UtcNow.AddHours(TimeConstans.UTC).ToString("HH:mm");
            float data1 = float.Parse(res.Split(":")[0]);
            float data2 = float.Parse(res.Split(":")[1]);
            return data1 * 3600 + data2 * 60;
        }

        public static DateTime GetCurrentServerTime()
        {
            return DateTime.UtcNow.AddHours(TimeConstans.UTC);
        }
    }
}
