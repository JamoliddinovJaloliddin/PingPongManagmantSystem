using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class StatisticService : ITableStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<IList<TableStatisticView>> GetAllAsyncStatistic(string search)
        {
            try
            {
                IList<TableStatisticView> tableStatisticViews = new List<TableStatisticView>();
                if (search == "")
                {

                }
                else
                {

                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
