using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
