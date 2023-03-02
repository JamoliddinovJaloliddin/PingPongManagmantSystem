using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces;

namespace PingPongManagmantSystem.Service.Services
{
    public class AccountService : IAccountService
    {
        AppDbContext _appDbContext = new AppDbContext();
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
            Cassa cassa = new Cassa();
            _appDbContext.Entry<Cassa>(cassa).State = EntityState.Detached;
            var data = DayHelper.GetCurrentServerDay();
            

            var user = await _appDbContext.Users.FindAsync(count);
            return user;
        }
    }
}
