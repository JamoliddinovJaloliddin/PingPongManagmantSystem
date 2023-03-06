using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices
{
    public interface IEmpolyeeStatsiticService
    {
        Task<IList<EmpolyeeStatisticView>> GetAllEmpolyeeStatistic(string search);

        Task<bool> CreateBarAsync(double totalPrice, string paymentType);
        Task<bool> CreateSportAsync(double totalPrice, string paymentType);
        Task<bool> CreateTableAsync(double totalPrice, string paymentType);
    }
}
