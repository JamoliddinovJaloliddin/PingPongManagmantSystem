using PingPongManagmantSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
