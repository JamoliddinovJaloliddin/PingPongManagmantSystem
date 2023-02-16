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
            appDbContext.Times.Update(time);
            var res = await appDbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IList<Time>> GetAll()
        {
            try
            {
                var res = appDbContext.Times.AsNoTracking().ToList();
                return res;
            }
            catch
            {
                return null;
            }
        }
    }
}
