using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices
{
    public interface ITableStatisticService
    {
        Task<IList<TableStatisticView>> GetAllAsyncStatistic(string search);
    }
}
