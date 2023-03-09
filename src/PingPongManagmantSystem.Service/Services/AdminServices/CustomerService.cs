using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class CustomerService : ICustomerService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> CreateAsync(Customer customer)
        {
            try
            {
                var resultCustomer = await appDbContext.Customers.FirstOrDefaultAsync(x => x.Status == customer.Status);

                if (resultCustomer is null)
                {
                    appDbContext.Customers.Add(customer);
                    var res = await appDbContext.SaveChangesAsync();
                    return res > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
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

        public async Task<IList<Customer>> GetAllAsync(string search, PaginationParams @params)
        {
            IList<Customer> customers = new List<Customer>();
            if (search == "")
            {
                var resaultt = from custom in appDbContext.Customers.OrderBy(x => x.Status)
                               select custom;

                var resault = await PagedList<Customer>.ToPageListAsync(resaultt, @params);

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
            }
            else
            {
                var resaultt = from customr in appDbContext.Customers.Where(x => x.Status.Contains(search)).OrderBy(x => x.Status)
                               select customr;

                var resault = await PagedList<Customer>.ToPageListAsync(resaultt, @params);

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
            }

            return null;
        }

        public async Task<Customer> GetByIdAsync(string customer)
        {
            try
            {
                Customer customerUser = new Customer();

                var resault = await appDbContext.Customers.Where(x => x.Status == customer).AsNoTracking().ToListAsync();
                foreach (var res in resault)
                {
                    customerUser.Status = res.Status;
                    customerUser.Percent = res.Percent;
                }
                return customerUser;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
            {
                var resultCustomer = await appDbContext.Customers.FindAsync(customer.Id);
                appDbContext.Entry(resultCustomer).State = EntityState.Detached;

                if (resultCustomer is not null)
                {
                    var customerOld = await appDbContext.Customers.FirstOrDefaultAsync(x => x.Status == customer.Status && x.Id != customer.Id);

                    if (customerOld is null)
                    {
                        appDbContext.Update(customer);
                        var resault = await appDbContext.SaveChangesAsync();
                        return resault > 0;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
