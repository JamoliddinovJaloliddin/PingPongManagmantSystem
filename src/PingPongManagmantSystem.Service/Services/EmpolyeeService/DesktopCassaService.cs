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
                var pingPongTable = (DesktopCassa)_appDbContext.DesktopCassas.Where(x => x.StolNumber == cassa.StolNumber).AsNoTracking();
                var timePrice = (Time)_appDbContext.Times.AsNoTracking();
                var pingPongTablePrice = (PingPongTable)_appDbContext.PingPongTables.Where(x => x.Number == cassa.StolNumber).AsNoTracking();

                var resault = 0.0;

                if (res > float.Parse(timePrice.TimeExpensiveFrom))
                {
                    resault = ((pingPongTablePrice.PriceCheap / 3600) * (float.Parse(timePrice.TimeExpensiveFrom) - pingPongTable.PlayTime)
                    / (pingPongTablePrice.PriceExpensive / 3600)) + (res - float.Parse(timePrice.TimeExpensiveFrom));
                }
                else
                {
                    resault = res - pingPongTable.PlayTime;
                }

                cassa.Id = pingPongTable.Id;
                _appDbContext.DesktopCassas.Update(cassa);
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCreateAsync(DesktopCassa cassa)
        {
            try
            {
                var res = await _appDbContext.DesktopCassas.Where(x => x.StolNumber == cassa.StolNumber).AsNoTracking().ToListAsync();

                int id = 0;
                foreach (var item in res)
                {
                    id = item.Id;
                    break;
                }
                cassa.Id = id;
                cassa.PlayTime = TimeHelper.GetCurrentServerTimeParseFloat();
                _appDbContext.DesktopCassas.Update(cassa);
                var resault = await _appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
