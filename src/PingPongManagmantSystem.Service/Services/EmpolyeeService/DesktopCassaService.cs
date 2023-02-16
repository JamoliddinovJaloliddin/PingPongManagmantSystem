using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class DesktopCassaService : IDesktopCassaService
    {
        private readonly AppDbContext _appDbContext;

        public DesktopCassaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> CreateAsync(DesktopCassa cassa)
        {
            try
            {
                float res = TimeHelper.GetCurrentServerTimeParseFloat();
                cassa.PlayTime = res;
                _appDbContext.DesktopCassas.Add(cassa);
                var resault = await _appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DesktopCassa>> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(DesktopCassa cassa)
        {
            try
            {
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
