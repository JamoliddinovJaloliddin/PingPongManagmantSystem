using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class DesktopCassa : BaseEntity
    {

        public int UserId { get; set; }
        public byte StolNumber { get; set; }
        public float PlayTime { get; set; }
        public bool Play { get; set; }
        public bool Pause { get; set; }
        public bool Stop { get; set; }
        public bool Transfer { get; set; }
        public bool Calc { get; set; }
        public double BarSum { get; set; }
        public string Label { get; set; } = String.Empty;

        public string AccountBook { get; set; } = string.Empty;
    }
}
