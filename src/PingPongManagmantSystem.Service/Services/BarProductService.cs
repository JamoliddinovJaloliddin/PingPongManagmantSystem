using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces;

namespace PingPongManagmantSystem.Service.Services
{
    public class BarProductService : IBarProductService
    {
        public Task<bool> CreateAsync(BarProduct barProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BarProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BarProduct barProduct)
        {
            throw new NotImplementedException();
        }
    }
}
