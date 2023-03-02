using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ISportProductService
    {
        Task<bool> CreateAsync(SportProduct sportProduct);
        Task<bool> UpdateAsync(SportProduct sportProduct);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IList<SportProduct>> GetAllAsync(string search);
    }
}
