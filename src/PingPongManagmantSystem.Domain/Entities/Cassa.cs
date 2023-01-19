using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Cassa : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = default!;
        public string UserName { get; set; } = String.Empty;
        public double BarProductPrice { get; set; }
        public double SportProductPrice { get; set; }
        public double TablePrice { get; set; }
        public double Card { get; set; }
        public double NoCard { get; set; }
        public double VipCard { get; set; }
        public string Check { get; set; } = String.Empty;

    }
}
