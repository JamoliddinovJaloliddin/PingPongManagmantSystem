using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices
{
    public interface IBarStatisticService
    {
        Task<IList<BarStatisticView>> GetAllBarStatistic(string search);
        Task<bool> UpdateAsync(Dictionary<string, int> keyValuePairs, string paymentType);
    }
}
