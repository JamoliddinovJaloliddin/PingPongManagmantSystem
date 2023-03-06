using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface IPingPongTableService
    {
        Task<bool> CreateAsync(PingPongTable user);
        Task<bool> UpdateAsync(PingPongTable user);
        Task<bool> DeleteAsync(int id);
        Task<PingPongTable> GetByIdAsync(int id);
        Task<IList<PingPongTable>> GetAllAsync(string search, PaginationParams @params);
    }
}
