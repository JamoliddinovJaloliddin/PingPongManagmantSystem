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

        public static implicit operator Card(List<Card> v)
        {
            return new Card()
            {
                CardNumber = v[0].CardNumber,
                Price = v[1].Price,
                TimeLimit = v[2].TimeLimit,
                Payment = v[3].Payment,
                Phone = v[4].Phone,
                DateTime = v[5].DateTime
            };
        }
    }
}
