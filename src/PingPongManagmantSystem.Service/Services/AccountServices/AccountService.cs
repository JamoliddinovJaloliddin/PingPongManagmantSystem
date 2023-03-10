using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Common.Security;
using PingPongManagmantSystem.Service.Interfaces.AccountServices;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        AppDbContext _appDbContext = new AppDbContext();
        IEmpolyeeStatsiticService empolyeeStatsiticService = new EmpolyeeStatisticService();
        public async Task<int> LoginAsync(string password)
        {
            try
            {
                var resultUser = await _appDbContext.Users.AsNoTracking().ToListAsync();
                foreach (var user in resultUser)
                {
                    var result = PassowrdHash.Verify(password: password, salt: user.Salt, hash: user.PasswordHasher);
                    if (result)
                    {
                        if (user.IsAdmin == 0)
                        {
                            GlobalVariable.UserId = user.Id;
                            GlobalVariable.UserName = user.Name;
                        }



                        return user.IsAdmin;
                    }
                }
                return 2;
            }
            catch
            {
                return 2;
            }
        }
    }
}
