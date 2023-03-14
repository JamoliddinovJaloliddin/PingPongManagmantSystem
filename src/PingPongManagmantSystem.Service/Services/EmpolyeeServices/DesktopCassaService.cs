using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class DesktopCassaService : IDesktopCassaService
    {
    
        ITimeService timeService = new TimeService();
        IPingPongTableService pingPongTableService = new PingPongTableService();
        ICustomerService customerService = new CustomerService();


        public async Task<bool> DeleteAsync(int id, double totalSum)
        {
            try
            {
                Cassa cassa = new Cassa();
                AppDbContext _appDbContext = new AppDbContext();
                _appDbContext.Entry<Cassa>(cassa).State = EntityState.Detached;

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
                pingPongTable.UserId = GlobalVariable.UserId;
                pingPongTable.TransferSum = 0;
                pingPongTable.TransferTime = 0;
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
                AppDbContext _appDbContext = new AppDbContext();
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
                AppDbContext _appDbContext = new AppDbContext();

                var result = await _appDbContext.DesktopCassas.FindAsync(id);
                if (result != null)
                {


                    _appDbContext.Entry(result).State = EntityState.Detached;

                    desktopCassa.Id = result.Id;
                    desktopCassa.StolNumber = result.StolNumber;
                    desktopCassa.BarSum = result.BarSum;
                    desktopCassa.PlayTime = result.PlayTime;
                    desktopCassa.TimeAccount = result.TimeAccount;
                    desktopCassa.Stop = result.Stop;
                    desktopCassa.Label = result.Label;
                    desktopCassa.Bar = result.Bar;
                    desktopCassa.Transfer = result.Transfer;
                    desktopCassa.AccountBook = result.AccountBook;
                    desktopCassa.Calc = result.Calc;
                    desktopCassa.UserId = result.UserId;
                    desktopCassa.Play = result.Play;
                    desktopCassa.Pause = result.Pause;
                    desktopCassa.TransferSum = result.TransferSum;
                    desktopCassa.TransferTime = result.TransferTime;
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
                AppDbContext _appDbContext = new AppDbContext();
                var res = TimeHelper.GetCurrentServerTimeParseFloat();
                var pingPongTable = (DesktopCassa)await GetByIdAsync(StolNumber);

                var timePrice = (Time)await timeService.GetAll();
                var pingPongTablePrice = (PingPongTable)await pingPongTableService.GetByIdAsync(StolNumber);
                double resault = 0;

                if (res > timePrice.TimeExpensiveFrom * 3600 / 100 && pingPongTable.PlayTime < timePrice.TimeExpensiveFrom * 3600 / 100)
                {
                    resault = Math.Floor((pingPongTablePrice.PriceCheap / 3600) * (timePrice.TimeExpensiveFrom * 3600 / 100 - pingPongTable.PlayTime)
                    / (pingPongTablePrice.PriceExpensive / 3600));
                }
                else if (res > 0 && res < 14400 && pingPongTable.PlayTime <= 86400 && pingPongTable.PlayTime >= timePrice.TimeExpensiveUpTo * 3600 / 100)
                {
                    resault = Math.Floor((86400 - pingPongTable.PlayTime) + res);
                }
                else
                {
                    resault = Math.Floor(res - pingPongTable.PlayTime);
                }
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
                AppDbContext _appDbContext = new AppDbContext();
                var res = (DesktopCassa)await GetByIdAsync(StolNumber);


                if (res.Stop != true && res.Pause != true && res.Play == true)
                {
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
                    res.PlayTime = TimeHelper.GetCurrentServerTimeParseFloat();
                    res.Play = false;
                    res.Pause = true;
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
                AppDbContext _appDbContext = new AppDbContext();
                var timeStop = (double)TimeHelper.GetCurrentServerTimeParseFloat();

                var result = await _appDbContext.DesktopCassas.FirstOrDefaultAsync(x => x.StolNumber == number);
                double time = 0;
                if (result.PlayTime > 0)
                {
                    if (result.PlayTime < 14400 && timeStop < 14400)
                    {
                        time = (timeStop - result.PlayTime) + result.TimeAccount + result.TransferTime;
                    }
                    else if (result.PlayTime > 14400 && timeStop <= 86400)
                    {
                        time = timeStop - result.PlayTime + result.TimeAccount + result.TransferTime;
                    }
                    else if (result.PlayTime <= 86400 && timeStop < 14400)
                    {
                        time = 86400 - result.PlayTime + timeStop + result.TimeAccount + result.TransferTime;
                    }
                    else
                    {
                        time = timeStop - result.PlayTime + result.TimeAccount + result.TransferTime;
                    }
                }
                else
                {
                    time = result.TimeAccount + result.TransferTime;
                }

                if (time >= 3600)
                {
                    time = Math.Round(time / 3600, 2);
                    string resultTime = (time.ToString().Split(".")[0]);
                    double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                    resultMinut = Math.Floor(36 * resultMinut / 60);
                    return $"{resultTime}.{resultMinut} soat";
                }
                else
                {
                    time = Math.Floor(time / 60);
                    return $"{time.ToString()} daqiqa";
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}
