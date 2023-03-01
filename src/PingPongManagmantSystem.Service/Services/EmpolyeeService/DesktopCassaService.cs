using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.Common;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.Services.Common;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class DesktopCassaService : IDesktopCassaService
    {
        AppDbContext _appDbContext = new AppDbContext();
        ITimeService timeService = new TimeService();
        IPingPongTableService pingPongTableService = new PingPongTableService();
        ICustomerService customerService = new CustomerService();
        ITrackingDetech<DesktopCassa> trackingDetech = new TrackingDetech<DesktopCassa>();

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var pingPongTable = (DesktopCassa)await GetByIdAsync(id);
                pingPongTable.Play = true;
                pingPongTable.Pause = false;
                pingPongTable.Stop = false;
                pingPongTable.Transfer = false;
                pingPongTable.Bar = false;
                pingPongTable.Calc = false;
                pingPongTable.Label = true;
                pingPongTable.AccountBook = "";
                pingPongTable.TimeAccount = 0;
                pingPongTable.PlayTime = 0;
                pingPongTable.BarSum = 0;
                pingPongTable.UserId = 0;
                _appDbContext.DesktopCassas.Update(pingPongTable);
                var resault = await _appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            catch
            {
                return false;
            }

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

                var resault = await _appDbContext.DesktopCassas.Where(x => x.StolNumber == id).AsNoTracking().ToListAsync();
                if (resault != null)
                {
                    foreach (var item in resault)
                    {
                        desktopCassa.Id = item.Id;
                        desktopCassa.StolNumber = item.StolNumber;
                        desktopCassa.BarSum = item.BarSum;
                        desktopCassa.PlayTime = item.PlayTime;
                        desktopCassa.TimeAccount = item.TimeAccount;
                        desktopCassa.Stop = item.Stop;
                        desktopCassa.Label = item.Label;
                        desktopCassa.Bar = item.Bar;
                        desktopCassa.Transfer = item.Transfer;
                        desktopCassa.AccountBook = item.AccountBook;
                        desktopCassa.Calc = item.Calc;
                        desktopCassa.UserId = item.UserId;
                        desktopCassa.Play = item.Play;
                        desktopCassa.Pause = item.Pause;
                        desktopCassa.TransferSum = item.TransferSum;
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

        public async Task<bool> UpdateAsync(int StolNumber)
        {
            try
            {
                var res = TimeHelper.GetCurrentServerTimeParseFloat();
                var pingPongTable = (DesktopCassa)await GetByIdAsync(StolNumber);
                //trackingDetech.TrackingDeteched(pingPongTable);
                _appDbContext.Entry(pingPongTable).State = EntityState.Detached;
                var timePrice = (Time)await timeService.GetAll();
                var pingPongTablePrice = (PingPongTable)await pingPongTableService.GetByIdAsync(StolNumber);
                double resault = 0;

                if (res > timePrice.TimeExpensiveFrom * 3600 / 100 && pingPongTable.PlayTime < timePrice.TimeExpensiveFrom * 3600 / 100)
                {
                    resault = (pingPongTablePrice.PriceCheap / 3600) * (timePrice.TimeExpensiveFrom * 3600 / 100 - pingPongTable.PlayTime)
                    / (pingPongTablePrice.PriceExpensive / 3600);
                }
                else
                {
                    resault = res - pingPongTable.PlayTime;
                }
                pingPongTable.Id = StolNumber;
                pingPongTable.StolNumber = StolNumber;
                pingPongTable.TimeAccount += resault;
                pingPongTable.Pause = false;
                pingPongTable.Play = true;
                pingPongTable.PlayTime = 0;           
                _appDbContext.DesktopCassas.Update(pingPongTable);
                var rs = await _appDbContext.SaveChangesAsync();
                return rs > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateAsync(int StolNumber)
        {
            try
            {
                var res = (DesktopCassa)await GetByIdAsync(StolNumber);


                if (res.Stop != true  &&  res.Pause != true && res.Play == true)
                {
                   // trackingDetech.TrackingDeteched(res);
                   _appDbContext.Entry(res).State = EntityState.Detached;
                    res.Pause = true;
                    res.Stop = true;
                    res.Bar = true;
                    res.Play = false;
                    res.Transfer = true;
                    res.Calc = true;
                    res.Label = false;
                    res.PlayTime = TimeHelper.GetCurrentServerTimeParseFloat();
                    _appDbContext.DesktopCassas.Update(res);
                }
                else if (res.Stop == true && res.Pause == false && res.Play == true)
                {
                    _appDbContext.Entry(res).State = EntityState.Detached;
                    res.PlayTime = TimeHelper.GetCurrentServerTimeParseFloat();
                    res.Id = StolNumber;
                    res.Play = false;
                    res.Pause = true;
                    _appDbContext.Entry(res).State = EntityState.Detached;
                    _appDbContext.DesktopCassas.Update(res);
                }
                var resault = await _appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetAllAccountBookAsync(int number)
        {
            try
            {
                var timeStop = (double)TimeHelper.GetCurrentServerTimeParseFloat();

                var resault = await _appDbContext.DesktopCassas.FirstOrDefaultAsync(x => x.StolNumber == number);
                string accountBook = $"Vaqt: {resault.TimeAccount + ((timeStop - resault.PlayTime)) / 60}";

                return accountBook;
            }
            catch
            {
                return "";
            }
        }
    }
}
