﻿using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Entities;

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
