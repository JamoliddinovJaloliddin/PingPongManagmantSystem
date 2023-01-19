using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.DataAccess.Repositorie
{
    public class CassaRepositorie : ICassaInretface
    {
        public Task<bool> CreateAsync(Cassa entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cassa>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cassa> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Cassa entity)
        {
            throw new NotImplementedException();
        }
    }
}
