using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Time
    {
        public string TimeCheapFrom { get; set; } = String.Empty;
        public string TimeCheapUpTo { get; set; } = String.Empty;
        public string TimeExpensiveFrom { get; set; } = String.Empty;
        public string TimeExpensiveUpTo { get; set; } = String.Empty;
    }
}
