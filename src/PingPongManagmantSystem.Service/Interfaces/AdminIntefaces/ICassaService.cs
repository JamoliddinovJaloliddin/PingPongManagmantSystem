using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ICassaService
    {
        Task<bool> DeleteAsync(int id);
        Task<string> GetByIdAsync(int id);
        Task<List<Cassa>> GetAllAsync(string search, PaginationParams @params);
    }
}
