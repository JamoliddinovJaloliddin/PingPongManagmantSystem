using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices
{
    public interface IEmpolyeeStatsiticService
    {
        Task<IList<SportStatisticView>> GetAllSportStatistic(string search);
    }
}
