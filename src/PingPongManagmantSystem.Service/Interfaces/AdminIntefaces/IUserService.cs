using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface IUserService
    {
        Task<bool> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IList<UserView>> GetAllAsync(string search);

    }
}
