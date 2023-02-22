using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class BarCount : BaseEntity
    {
        public double Price { get; set; } = 0;
        public int Count { get; set; } = 0;
        public string Name { get; set; } = "";

    }
}
