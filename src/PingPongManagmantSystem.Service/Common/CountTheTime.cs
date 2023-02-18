using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Helpers;

namespace PingPongManagmantSystem.Service.Common
{
    public class CountTheTime
    {
        AppDbContext _appDbContext = new AppDbContext();
        public async Task<double> CountTheTimee(byte PlayTaym)
        {
            try
            {
                double number = 0;
                var res = await _appDbContext.DesktopCassas.Where(x => x.StolNumber == PlayTaym).AsNoTracking().ToListAsync();
                foreach (var item in res)
                {
                    number = item.PlayTime;
                    break;
                }
                return number;
            }
            catch
            {
                return 0;
            }
        }
    }
}
