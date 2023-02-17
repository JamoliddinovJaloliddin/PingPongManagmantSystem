using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class PingPongTable : BaseEntity
    {
        public int Number { get; set; }
        public double PriceCheap { get; set; }
        public double PriceExpensive { get; set; }
    }
}
