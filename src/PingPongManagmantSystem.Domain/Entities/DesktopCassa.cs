using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class DesktopCassa : BaseEntity
    {
        public int UserId { get; set; } 
        public int StolNumber { get; set; }
        public double PlayTime { get; set; }
        public bool Play { get; set; }
        public bool Pause { get; set; }
        public bool Stop { get; set; }
        public bool Transfer { get; set; }
        public bool Calc { get; set; }
        public bool Bar { get; set; }
        public double BarSum { get; set; }
        public bool Label { get; set; }
        public double TimeAccount { get; set; }
        public string AccountBook { get; set; } = "";
        public double TransferSum { get; set; } = 0;
    }
}
