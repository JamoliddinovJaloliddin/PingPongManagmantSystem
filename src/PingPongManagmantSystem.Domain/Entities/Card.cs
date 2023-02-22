using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; } = String.Empty;
        public double Price { get; set; }
        public double TimeLimit { get; set; }
        public string Payment { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;

        public static implicit operator Card(List<Card> v)
        {
            return new Card()
            {
                CardNumber = v[0].CardNumber,
                Price = v[1].Price,
                TimeLimit = v[2].TimeLimit,
                Payment = v[3].Payment,
                Phone = v[4].Phone,
            };
        }
    }
}
