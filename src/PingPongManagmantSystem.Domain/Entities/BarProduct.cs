using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class BarProduct : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public double ArrivalPrice { get; set; }
        public double SalePrice { get; set; }
        public int Count { get; set; }
        public DateTime DateTime { get; set; }

    }
}
