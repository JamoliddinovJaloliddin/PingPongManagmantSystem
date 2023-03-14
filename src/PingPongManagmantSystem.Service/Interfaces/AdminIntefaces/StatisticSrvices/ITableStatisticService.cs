using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices
{
    public interface ITableStatisticService
    {

        Task<IList<TableStatisticView>> GetAllAsync(string search, PaginationParams @params);
        Task<bool> UpdateAsync(double totalPrice, string paymentType);
        Task<bool> CreateAsync();

    }
}
