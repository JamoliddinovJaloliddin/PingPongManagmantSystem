using PingPongManagmantSystem.Domain.Constans;

namespace PingPongManagmantSystem.Service.Helpers
{
    public class DayHelper
    {
        public static string GetCurrentServerDay()
        {
            var res = DateTime.UtcNow.AddHours(TimeConstans.UTC).ToString("MM/dd/yyyy");
            return res;
        }

    }
}
