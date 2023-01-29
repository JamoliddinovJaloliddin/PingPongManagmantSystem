using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class DesktopCassaService : IDesktopCassaService
    {
        AppDbContext appDbContext = new AppDbContext();

        public async Task<bool> CreateAsync(DesktopCassa cassa)
        {
            try
            {
                float res = TimeHelper.GetCurrentServerTimeParseFloat();
                cassa.PlayTime = res;
                appDbContext.DesktopCassas.Add(cassa);
                var resault = await appDbContext.SaveChangesAsync();
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
            throw new NotImplementedException();
        }
    }
}
