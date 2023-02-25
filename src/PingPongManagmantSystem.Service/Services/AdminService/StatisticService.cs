using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class StatisticService : IStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<IList<TableStatisticView>> GetAllAsyncStatistic()
        {
            try
            {

                return null;
            }
            catch
            {
                return null;
            }
        }

        public Task<IList<BarStatisticView>> GetAllBarStatistic()
        {
            try
            {
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<SportStatisticView>> GetAllSportStatistic()
        {
            try
            {
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
