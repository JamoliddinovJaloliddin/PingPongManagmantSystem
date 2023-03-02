using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class BarProduct : BaseEntity
    {
        public string Name { get; set; } = "";
        public double ArrivalPrice { get; set; } = 0;
        public double SalePrice { get; set; } = 0;
        public int Count { get; set; } = 0;
        public string DateTime { get; set; } = "";

    }
}
