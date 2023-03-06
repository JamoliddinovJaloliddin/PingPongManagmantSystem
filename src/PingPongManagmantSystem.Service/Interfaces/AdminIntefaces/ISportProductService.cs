using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ISportProductService
    {
        Task<bool> CreateAsync(SportProduct sportProduct);
        Task<bool> UpdateAsync(SportProduct sportProduct);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IList<SportProduct>> GetAllAsync(string search, PaginationParams @params);
    }
}
