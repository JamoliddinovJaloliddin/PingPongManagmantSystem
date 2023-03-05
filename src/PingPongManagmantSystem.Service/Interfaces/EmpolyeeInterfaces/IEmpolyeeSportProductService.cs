using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IEmpolyeeSportProductService
    {
        public Task<IList<SportCount>> GetAllAsync();
        public Task<List<SportCount>> GetAllSportProductAsync();
        public Task<bool> CreateAsync(int id, SportCount sportCount);
        public Task<bool> DeleteSportCountAsync();
        public Task<bool> DeleteSportProductAsync(Dictionary<string, int> keyValuePairs, string paymentType);
    }
}
