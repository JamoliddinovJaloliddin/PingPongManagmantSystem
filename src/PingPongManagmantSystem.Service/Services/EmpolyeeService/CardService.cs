using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class CardService : ICardService
    {
        public Task<bool> CreateAsync(Card card)
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

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
