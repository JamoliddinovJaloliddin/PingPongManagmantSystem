using PingPongManagmantSystem.Domain.Constans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
