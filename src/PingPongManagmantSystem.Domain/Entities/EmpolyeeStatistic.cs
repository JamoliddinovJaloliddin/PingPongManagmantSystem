using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class EmpolyeeStatistic : BaseEntity
    {
        public int UserId { get; set; }  
        public string DateTime { get; set; } = String.Empty;
        public double BarSum { get; set; }
        public double VipCardSum { get; set; }
        public double ViCardToSell { get; set; }
        public double SportSum { get; set; }
        public double TableSum { get; set; }
    }
}
