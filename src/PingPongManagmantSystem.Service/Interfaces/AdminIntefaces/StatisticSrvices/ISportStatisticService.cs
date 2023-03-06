using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices
{
    public interface ISportStatisticService
    {
        Task<IList<SportStatisticView>> GetAllSportStatistic(string search, PaginationParams @params);
        Task<bool> UpdateAsync(Dictionary<string, int> keyValuePair, string paymentType);
    }
}
