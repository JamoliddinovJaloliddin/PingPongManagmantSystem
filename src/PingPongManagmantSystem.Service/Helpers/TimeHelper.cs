using PingPongManagmantSystem.Domain.Constans;

namespace PingPongManagmantSystem.Service.Helpers
{
    public class TimeHelper
    {
        public static float GetCurrentServerTimeParseFloat()
        {

            var res = DateTime.UtcNow.AddHours(TimeConstans.UTC).ToString("H:mm");
            float data1 = float.Parse(res.Split(":")[0]);
            float data2 = float.Parse(res.Split(":")[1]);
            return data1 * 100 + data2;
        }

        public static DateTime GetCurrentServerTimeFloatParse()
        {
            var data = DateTime.UtcNow;
            return data.AddHours(TimeConstans.UTC);
        }
    }
}
