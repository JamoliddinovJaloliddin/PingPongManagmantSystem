using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Cassa : BaseEntity
    {
        public string UserName { get; set; } = String.Empty;
        public double BarProductPrice { get; set; }
        public double SportProductPrice { get; set; }
        public double TablePrice { get; set; }
        public string SumPrice { get; set; } = String.Empty;
        public string Check { get; set; } = String.Empty;
        public string TypeOfPrice { get; set; } = String.Empty;
    }
}
