using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IEmpolyeeBarProductService
    {
        Task<IList<BarCount>> GetAllAsync();
        Task<IList<BarCount>> GetAllBarCountAsync();
        Task<bool> CreateAsync(int number, BarCount barCount);
        Task<bool> DeleteBarCountAsync(int id, string account, double sum);
        Task<bool> DeleteBarProductAsync(Dictionary<string, int> keyValuePairs, string paymentType);
    }
}
