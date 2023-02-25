using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ICassaService
    {
        Task<bool> CreateAsync(Cassa cassa);
        Task<bool> UpdateAsync(Cassa cassa);
        Task<bool> DeleteAsync(int id);
        Task<string> GetByIdAsync(int id);
        Task<List<Cassa>> GetAllAsync();
    }
}
