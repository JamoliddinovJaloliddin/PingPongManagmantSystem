using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces
{
    public interface IBarProductService
    {
        Task<bool> CreateAsync(BarProduct barProduct);
        Task<bool> UpdateAsync(BarProduct barProduct);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<BarProduct>> GetAllAsync();
    }
}
