using PingPongManagmantSystem.Domain.Constans;

namespace PingPongManagmantSystem.Service.Helpers
{
    public class DayHelper
    {
        public static string GetCurrentServerDay()
        {
            var res = DateTime.UtcNow.AddHours(TimeConstans.UTC).ToString("dd/MM/yyyy");
            return res;
        }

        public static string GetCurrentDay()
        {
            var res = DateTime.UtcNow.AddHours(TimeConstans.UTC).ToString("dd/");
            return res;
        }

    }
}
