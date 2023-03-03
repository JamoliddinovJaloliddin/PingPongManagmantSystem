using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class SportStatisticService : ISportStatisticService
    {
        public Task<IList<SportStatisticView>> GetAllSportStatistic(string search)
        {
            throw new NotImplementedException();
        }
    }
}
