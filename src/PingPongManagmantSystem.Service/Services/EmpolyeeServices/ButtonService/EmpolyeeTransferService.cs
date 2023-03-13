using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface.ButtonService;
using PingPongManagmantSystem.Service.Services.AdminService;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService.ButtonService
{
    public class EmpolyeeTransferService : IEmpolyeeTransferService
    {
        AppDbContext appDbContext = new AppDbContext();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        ITimeService timeService = new TimeService();
        IPingPongTableService pingPongTableService = new PingPongTableService();

        public async Task<bool> CheckTransfer()
        {
            try
            {
                var result = await appDbContext.DesktopCassas.FirstOrDefaultAsync(x => x.Stop == false);
                if (result is not null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<int>> GetAllAsync()
        {
            try
            {
                var resault = await appDbContext.DesktopCassas.Where(x => x.Play == true).AsNoTracking().Select(x => x.StolNumber).ToListAsync();
                return resault;
            }
            catch
            {
                return null;
            }
        }


    }
}
