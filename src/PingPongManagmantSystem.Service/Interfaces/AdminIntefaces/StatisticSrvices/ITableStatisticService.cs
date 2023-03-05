using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices
{
    public interface ITableStatisticService
    {
        Task<bool> UpdateAsync(double totalPrice, string paymentType);
        
    }
}
