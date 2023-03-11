using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Cassa : BaseEntity
    {
        public string UserName { get; set; } = "";
        public double BarProductPrice { get; set; } = 0;
        public double TablePrice { get; set; } = 0;
        public string SumPrice { get; set; } = "";
        public string Check { get; set; } = "";
        public string TypeOfPrice { get; set; } = "";
        public string DateTime { get; set; } = "";
    }
}
