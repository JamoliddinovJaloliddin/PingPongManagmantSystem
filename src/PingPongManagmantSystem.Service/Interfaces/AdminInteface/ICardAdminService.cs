using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ICardAdminService
    {
        Task<IList<Card>> GetAllAsync(string search);
        Task<bool> DeleteAsync(int id);
    }
}
