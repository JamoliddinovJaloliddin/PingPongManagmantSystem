using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface IBarProductService
    {
        Task<bool> CreateAsync(BarProduct barProduct);
        Task<bool> UpdateAsync(BarProduct barProduct);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IList<BarProduct>> GetAllAsync(string search, PaginationParams @params);
    }
}
