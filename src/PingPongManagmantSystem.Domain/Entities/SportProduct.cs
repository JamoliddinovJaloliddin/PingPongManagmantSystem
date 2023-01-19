using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class SportProduct : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public double ArrivalPrice { get; set; }
        public double SalePrice { get; set; }
        public int Count { get; set; }
    }
}
