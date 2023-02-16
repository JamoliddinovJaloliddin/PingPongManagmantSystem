using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class DesktopCassa : BaseEntity
    {
        public byte StolNumber { get; set; }
        public float PlayTime { get; set; }
        public bool Pause { get; set; }
        public bool Stop { get; set; }
        public bool Busy { get; set; }
        public double BarSum { get; set; }
    }
}
