using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class DesktopCassaService : IDesktopCassaService
    {
        AppDbContext _appDbContext = new AppDbContext();

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DesktopCassa>> GetAllAsync()
        {
            try
            {
                var res = await _appDbContext.DesktopCassas.OrderBy(x => x.StolNumber).AsNoTracking().ToListAsync();
                return res;
            }
            catch
            {
                return null;
            }
        }

        public Task<IEnumerable<DesktopCassa>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }



        public async Task<bool> UpdateAsync(DesktopCassa cassa)
        {
            try
            {
                var res = TimeHelper.GetCurrentServerTimeParseFloat();
                var pingPongtable = _appDbContext.DesktopCassas.Where(x => x.StolNumber == cassa.StolNumber).AsNoTracking();
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
