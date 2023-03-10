using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{

    public class TimeService : ITimeService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> UpdateAsync(Time time)
        {
            try
            {
                appDbContext.Entry(time).State = EntityState.Detached;
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
                appDbContext.Entry(time1).State = EntityState.Detached;
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
