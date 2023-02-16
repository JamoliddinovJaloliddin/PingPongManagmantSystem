using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IDesktopCassaService
    {
        Task<bool> CreateAsync(DesktopCassa cassa);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(DesktopCassa cassa);
        Task<IEnumerable<DesktopCassa>> GetByIdAsync();
    }
}
