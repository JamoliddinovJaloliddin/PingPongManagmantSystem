using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class SportCount : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
