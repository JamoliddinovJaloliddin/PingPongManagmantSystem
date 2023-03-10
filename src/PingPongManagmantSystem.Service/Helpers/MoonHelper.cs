using PingPongManagmantSystem.Domain.Constans;

namespace PingPongManagmantSystem.Service.Helpers
{
    public class MoonHelper
    {
        public static string GetCurrentMoon()
        {
            var res = DateTime.UtcNow.AddHours(TimeConstans.UTC).ToString("MM");
            res = $"/{res}/";
            return res;
        }
    }
}
