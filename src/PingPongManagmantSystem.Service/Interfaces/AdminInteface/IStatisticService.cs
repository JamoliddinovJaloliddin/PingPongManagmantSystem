using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface IStatisticService
    {
        Task<IList<BarStatisticView>> GetAllBarStatistic();
        Task<IList<SportStatisticView>> GetAllSportStatistic();
        Task<IList<TableStatisticView>> GetAllAsyncStatistic();
    }
}
