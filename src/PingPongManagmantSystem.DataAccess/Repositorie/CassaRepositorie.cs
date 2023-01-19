using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
