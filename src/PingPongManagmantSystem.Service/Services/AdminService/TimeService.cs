using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.Common;
using PingPongManagmantSystem.Service.Services.Common;

namespace PingPongManagmantSystem.Service.Services.AdminService
{

    public class TimeService : ITimeService
    {
        AppDbContext appDbContext = new AppDbContext();
        ITrackingDetech<Time> trackingDetech = new TrackingDetech<Time>();
        public async Task<bool> UpdateAsync(Time time)
        {
            try
            {
                trackingDetech.TrackingDeteched(time);
                appDbContext.Times.Update(time);
                var res = await appDbContext.SaveChangesAsync();
                return res > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Time> GetAll()
        {
            try
            {
                Time time1 = new Time();
                var res = await appDbContext.Times.AsNoTracking().ToListAsync();
                foreach (var time in res)
                {
                    time1.TimeCheapUpTo = time.TimeCheapUpTo;
                    time1.TimeCheapFrom = time.TimeCheapFrom;
                    time1.TimeExpensiveFrom = time.TimeExpensiveFrom;
                    time1.TimeExpensiveUpTo = time.TimeExpensiveUpTo;
                }
                return time1;
            }
            catch
            {
                return null;
            }
        }
    }
}
