using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string Status { get; set; } = String.Empty;
        public double Price { get; set; }
        public double TimeLimit { get; set; }

    }
}
