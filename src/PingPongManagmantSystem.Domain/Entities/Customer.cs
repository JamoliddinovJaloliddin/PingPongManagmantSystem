using PingPongManagmantSystem.Domain.Common;


namespace PingPongManagmantSystem.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Status { get; set; } = String.Empty;
        public double Percent { get; set; }
    }
}
