using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IDesktopCassaService
    {

        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(DesktopCassa cassa);
        Task<IEnumerable<DesktopCassa>> GetByIdAsync();
        Task<IEnumerable<DesktopCassa>> GetAllAsync();
    }
}
