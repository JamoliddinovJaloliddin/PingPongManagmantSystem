﻿using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class CustomerService : ICustomerService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> CreateAsync(Customer customer)
        {
            appDbContext.Customers.Add(customer);
            var res = await appDbContext.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var res = await appDbContext.Customers.FindAsync(id);
            if (res is not null)
            {
                appDbContext.Remove(res);
                var resault = await appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            return false;
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            IList<Customer> customers = new List<Customer>();
            var resault = appDbContext.Customers.OrderBy(x => x.Status).AsNoTracking();
            if (resault is not null)
            {
                foreach (var res in resault)
                {
                    Customer customer = new Customer();
                    customer.Id = res.Id;
                    customer.Status = res.Status;
                    customer.Percent = res.Percent;
                    customers.Add(customer);
                }
                return customers;
            }
            return null;
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            appDbContext.Update(customer);
            var resault = await appDbContext.SaveChangesAsync();
            return resault > 0;
        }
    }
}
