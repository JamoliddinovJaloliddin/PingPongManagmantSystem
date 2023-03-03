using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class SportStatistic : BaseEntity
    {
        public string DateTime { get; set; } = String.Empty;
        public double Card { get; set; }
        public double Cash { get; set; }
        public double SportSum { get; set; }
        public double NumberOfSaleSport { get; set; }
    }
}
