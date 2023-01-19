using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
