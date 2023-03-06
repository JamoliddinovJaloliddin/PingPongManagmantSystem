using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;

namespace PingPongManagmantSystem.Service.Services
{
    public class AccountService : IAccountService
    {
        AppDbContext _appDbContext = new AppDbContext();
        ITableStatisticService tableStatistic = new TableStatisticService();
        public async Task<bool> LoginAsync(string password)
        {
            try
            {
                var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Password == password);
                if (user is null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> WindowtAsync(string count)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Password == count);
            if (user is not null)
            {
                var result = await tableStatistic.CreateAsync();
            }
            return user;
        }
    }
}
