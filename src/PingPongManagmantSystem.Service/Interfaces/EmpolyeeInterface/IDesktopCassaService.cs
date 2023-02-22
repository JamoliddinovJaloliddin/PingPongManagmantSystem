using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IDesktopCassaService
    {

        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(DesktopCassa cassa);
        Task<bool> CreateAsync(DesktopCassa cassa);
        Task<DesktopCassa> GetByIdAsync(int id);
        Task<IEnumerable<DesktopCassa>> GetAllAsync();
        Task<string> GetAllAccountBookAsync(int number);
    }
}
