using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminService;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class DesktopCassaService : IDesktopCassaService
    {
        AppDbContext _appDbContext = new AppDbContext();
        ITimeService timeService = new TimeService();
        IPingPongTableService pingPongTableService = new PingPongTableService();

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

        public async Task<DesktopCassa> GetByIdAsync(int id)
        {
            try
            {
                DesktopCassa desktopCassa = new DesktopCassa();

                var resault = (IEnumerable<DesktopCassa>)_appDbContext.DesktopCassas.Where(x => x.StolNumber == id).AsNoTracking();
                if (resault != null)
                {
                    foreach (var item in resault)
                    { 
                        desktopCassa.StolNumber = item.StolNumber;
                        desktopCassa.AccountBook = item.AccountBook;
                        desktopCassa.BarSum = item.BarSum;
                        desktopCassa.PlayTime = item.PlayTime;
                        desktopCassa.TimeAccount = item.TimeAccount;
                    }
                    
                    return desktopCassa;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }



        public async Task<bool> UpdateAsync(DesktopCassa cassa)
        {
            try
            {
                var res = TimeHelper.GetCurrentServerTimeParseFloat();
                var pingPongTable = (DesktopCassa) await GetByIdAsync(cassa.StolNumber);
                var timePrice = (Time)await timeService.GetAll();
                var pingPongTablePrice = (PingPongTable) await pingPongTableService.GetByIdAsync(cassa.StolNumber);

                double resault = 0;

                if (res > timePrice.TimeExpensiveFrom && pingPongTable.PlayTime < timePrice.TimeExpensiveFrom)
                {
                    resault = (pingPongTablePrice.PriceCheap / 3600) * (timePrice.TimeExpensiveFrom - pingPongTable.PlayTime)
                    / (pingPongTablePrice.PriceExpensive / 3600) + (res - timePrice.TimeExpensiveFrom);
                }
                else
                {
                    resault = res - pingPongTable.PlayTime;
                }

                cassa.TimeAccount += resault;
                cassa.Id = pingPongTable.Id;
                cassa.Play = true;
                _appDbContext.DesktopCassas.Update(cassa);
                var rs = await _appDbContext.SaveChangesAsync();
                return rs > 0;
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
