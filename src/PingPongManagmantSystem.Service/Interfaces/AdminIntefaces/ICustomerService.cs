using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ICustomerService
    {
        Task<bool> CreateAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);
        Task<IList<Customer>> GetAllAsync(string search, PaginationParams @params);
        Task<Customer> GetByIdAsync(string customer);
    }
}
