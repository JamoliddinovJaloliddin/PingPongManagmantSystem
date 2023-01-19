using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.DataAccess.Repositorie
{
    public class PingPongTableIRepositorie : IPingPongTableInterface
    {
        public Task<bool> CreateAsync(PingPongTable entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PingPongTable>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PingPongTable> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(PingPongTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
