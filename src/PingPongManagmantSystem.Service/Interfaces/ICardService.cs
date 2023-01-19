using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces
{
    public interface ICardService
    {
        Task<bool> CreateAsync(Card card);
        Task<bool> UpdateAsync(Card card);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<Card>> GetAllAsync();
    }
}
