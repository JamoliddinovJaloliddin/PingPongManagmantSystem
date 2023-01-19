using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.DataAccess.Repositorie
{
    public class CardInterfaces : ICardInterface
    {
        public Task<bool> CreateAsync(Card entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Card> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
