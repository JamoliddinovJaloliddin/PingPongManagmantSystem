using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class PingPongTable : BaseEntity
    {
        public string Status { get; set; } = String.Empty;
        public double PriceCheap { get; set; }
        public double PriceExpensive { get; set; }
    }
}
