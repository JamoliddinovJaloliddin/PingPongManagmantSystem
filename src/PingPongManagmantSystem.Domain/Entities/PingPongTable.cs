using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class PingPongTable : BaseEntity
    {
        public int Number { get; set; } = 0;
        public double PriceCheap { get; set; } = 0;
        public double PriceExpensive { get; set; } = 0;
    }
}
