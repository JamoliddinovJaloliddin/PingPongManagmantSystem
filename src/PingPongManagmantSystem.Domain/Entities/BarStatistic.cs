using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class BarStatistic : BaseEntity
    {
        public string DateTime { get; set; } = String.Empty;
        public double Card { get; set; }
        public double Cash { get; set; }
        public double BarSum { get; set; }
        public double NumberOfSaleBar { get; set; }
    }
}
