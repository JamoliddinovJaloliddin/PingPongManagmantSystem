using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; } = "";
        public double Price { get; set; } = 0;
        public double TimeLimit { get; set; } = 0;
        public string Payment { get; set; } = "";
        public string Phone { get; set; } = "";
        public string DateTime { get; set; } = "";


    }
}
