using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ICardAdminService
    {
        Task<IList<Card>> GetAllAsync(string search, PaginationParams @params);
        Task<bool> DeleteAsync(int id);
    }
}
