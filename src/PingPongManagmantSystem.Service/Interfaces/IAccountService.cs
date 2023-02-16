using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string password);
        Task<User> WindowtAsync(string password);
    }
}
