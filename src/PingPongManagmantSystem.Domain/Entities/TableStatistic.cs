using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class TableStatistic : BaseEntity
    {
        public string DateTime { get; set; } = String.Empty;
        public double Card { get; set; }
        public double Cash { get; set; }
        public double VipCard { get; set; }
        public double TableSum { get; set; }
    }
}
