using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices
{
    public interface ITableStatisticService
    {
        Task<bool> CreateAsync();
        Task<bool> UpdateBarAsync(Dictionary<string, int> keyValuePairs);
        Task<bool> UpdateProductAsync(Dictionary<string, int> keyValuePairs);
        Task<bool> UpdateTableAsync();
        Task<IList<TableStatisticView>> GetAllAsyncStatistic(string search);
    }
}
