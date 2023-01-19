using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class PingPongTable : BaseEntity
    {
        public string Status { get; set; } = String.Empty;
        public string TimeCheapFrom { get; set; } = String.Empty;
        public string TimeCheapUpTo { get; set; } = String.Empty;
        public string TimeExpensiveFrom { get; set; } = String.Empty;
        public string TimeExpensiveUpTo { get; set; } = String.Empty;
    }
}
