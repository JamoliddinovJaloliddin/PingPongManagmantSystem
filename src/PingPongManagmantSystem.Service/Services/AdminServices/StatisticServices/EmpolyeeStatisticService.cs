using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class EmpolyeeStatisticService : IEmpolyeeStatsiticService
    {
        public Task<IList<SportStatisticView>> GetAllSportStatistic(string search)
        {
            throw new NotImplementedException();
        }
    }
}
