using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Time : BaseEntity
    {
        public double TimeCheapFrom { get; set; }
        public double TimeCheapUpTo { get; set; }
        public double TimeExpensiveFrom { get; set; }
        public double TimeExpensiveUpTo { get; set; }
    }
}
