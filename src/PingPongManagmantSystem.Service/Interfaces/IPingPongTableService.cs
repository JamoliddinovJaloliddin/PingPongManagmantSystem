using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces
{
    public interface IPingPongTableService
    {
        Task<bool> CreateAsync(PingPongTable user);
        Task<bool> UpdateAsync(PingPongTable user);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<PingPongTable>> GetAllAsync();
    }
}
