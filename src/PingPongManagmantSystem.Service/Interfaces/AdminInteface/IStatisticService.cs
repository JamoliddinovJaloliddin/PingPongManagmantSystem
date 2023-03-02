using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface IStatisticService
    {
        Task<IList<BarStatisticView>> GetAllBarStatistic(string search);
        Task<IList<SportStatisticView>> GetAllSportStatistic(string search);
        Task<IList<TableStatisticView>> GetAllAsyncStatistic(string search);
    }
}
