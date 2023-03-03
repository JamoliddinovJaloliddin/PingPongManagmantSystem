using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class BarStatisticService : IBarStatisticService
    {
        public Task<IList<BarStatisticView>> GetAllBarStatistic(string search)
        {
            throw new NotImplementedException();
        }
    }
}
