using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminService;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class EmpolyeeTransferService : IEmpolyeeTransferService
    {
        AppDbContext appDbContext = new AppDbContext();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        ITimeService timeService = new TimeService();
        IPingPongTableService pingPongTableService = new PingPongTableService();

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
