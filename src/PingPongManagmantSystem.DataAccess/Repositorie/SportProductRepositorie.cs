using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.DataAccess.Repositorie
{
    public class SportProductRepositorie : ISportProductInterface
    {
        public Task<bool> CreateAsync(SportProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SportProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SportProduct> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(SportProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
