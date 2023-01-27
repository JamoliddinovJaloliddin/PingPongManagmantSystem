using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces;

namespace PingPongManagmantSystem.Service.Services
{
    public class AccountService : IAccountService
    {


        public async Task<bool> LoginAsync(string password)
        {
            try
            {

                //var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Password == password);
                //if (user is null)
                //{
                //    return false;
                //}
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> WindowtAsync(string count)
        {
            //var user = await _appDbContext.Users.FindAsync(count);
            User user = null;
            return user;
        }
    }
}
