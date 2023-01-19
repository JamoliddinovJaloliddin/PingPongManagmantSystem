using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();

    }
}
