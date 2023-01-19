using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.DataAccess.Repositorie
{
    public class BarProductRepositorie : IBarProductInterface
    {
        public Task<bool> CreateAsync(BarProduct entity)
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

        public Task<BarProduct> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BarProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
