using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class SportCount : BaseEntity
    {
        public string Name { get; set; } = "";
        public double Price { get; set; } = 0;
        public int Count { get; set; } = 0;
    }
}
