using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface ICardService
    {
        Task<bool> CreateAsync(Card card);
        Task<bool> UpdateAsync(Card card);
        Task<bool> DeleteAsync(int id);
        Task<Card> GetByIdAsync(string customer);
        Task<IEnumerable<Card>> GetAllAsync();
    }
}
