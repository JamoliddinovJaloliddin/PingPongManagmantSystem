﻿using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces;

namespace PingPongManagmantSystem.Service.Services
{
    public class CassaService : ICassaService
    {
        public Task<bool> CreateAsync(Cassa cassa)
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

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Cassa cassa)
        {
            throw new NotImplementedException();
        }
    }
}