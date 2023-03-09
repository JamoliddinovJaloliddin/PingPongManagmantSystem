using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Security;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class UserService : IUserService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> CreateAsync(User user)
        {
            try
            {
                int countNumber = 0;
                var resultUser = await appDbContext.Users.Where(x => x.IsAdmin == 0).AsNoTracking().ToListAsync();

                foreach (var item in resultUser)
                {
                    var result = PassowrdHash.Verify(password: user.PasswordHasher, hash: item.PasswordHasher, salt: item.Salt);
                    if (result)
                    {
                        countNumber++;
                    }
                }

                if (countNumber == 0)
                {
                    var result = PassowrdHash.Hash(user.PasswordHasher);
                    user.PasswordHasher = result.Hash;
                    user.Salt = result.Salt;
                    user.IsAdmin = 0;
                    appDbContext.Users.Add(user);
                    var res = await appDbContext.SaveChangesAsync();
                    countNumber = 0;
                    return res > 0;
                }
                countNumber = 0;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = appDbContext.Users.Find(id);
                appDbContext.Users.Remove(user);
                var resault = await appDbContext.SaveChangesAsync();
                if (resault > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<UserView>> GetAllAsync(string search, PaginationParams @params)
        {
            try
            {
                List<UserView> list = new List<UserView>();
                if (search == "")
                {

                    var resaultt = from user in appDbContext.Users.Where(u => u.IsAdmin == 0).OrderBy(u => u.Name)
                                   select user;

                    var resault = await PagedList<User>.ToPageListAsync(resaultt, @params);

                    foreach (var user in resault)
                    {
                        UserView userView = new UserView();
                        userView.Id = user.Id;
                        userView.Name = user.Name;
                        userView.Passport = user.PassportInfo;
                        list.Add(userView);
                    }
                }
                else
                {
                    var resaultt = from user in appDbContext.Users.Where(u => u.IsAdmin == 0 && u.Name.ToLower().Contains(search.ToString())
                    || u.PassportInfo.Contains(search.ToString())
                    ).OrderBy(x => x.Name)
                                   select user;

                    var resault = await PagedList<User>.ToPageListAsync(resaultt, @params);

                    foreach (var user in resault)
                    {
                        UserView userView = new UserView();
                        userView.Id = user.Id;
                        userView.Name = user.Name;
                        userView.Passport = user.PassportInfo;
                        list.Add(userView);
                    }
                }
                if (list is not null)
                {
                    return list;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAdminAsync(string password)
        {
            try
            {
                var resultUser = (User)await appDbContext.Users.FirstOrDefaultAsync(x => x.IsAdmin == 1);

                if (resultUser is not null)
                {
                    appDbContext.Entry(resultUser).State = EntityState.Detached;

                    var newPassword = PassowrdHash.Hash(password);
                    resultUser.PasswordHasher = newPassword.Hash;
                    resultUser.Salt = newPassword.Salt;

                    appDbContext.Users.Update(resultUser);
                    var result = await appDbContext.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                int countNumber = 0;
                var resultUser = await appDbContext.Users.Where(x => x.IsAdmin == 0).AsNoTracking().ToListAsync();

                foreach (var item in resultUser)
                {
                    var results = PassowrdHash.Verify(password: user.PasswordHasher, hash: item.PasswordHasher, salt: item.Salt);
                    if (results)
                    {
                        countNumber++;
                    }
                }

                if (countNumber == 0)
                {
                    var result = await appDbContext.Users.FindAsync(user.Id);

                    appDbContext.Entry(result).State = EntityState.Detached;

                    if (result is not null)
                    {
                        var userPassowrd = PassowrdHash.Hash(user.PasswordHasher);


                        user.Id = result.Id;
                        user.IsAdmin = 0;
                        user.PasswordHasher = userPassowrd.Hash;
                        user.Salt = userPassowrd.Salt;
                        appDbContext.Users.Update(user);
                        var res = await appDbContext.SaveChangesAsync();
                        if (res > 0)
                        {
                            countNumber = 0;
                            return true;
                        }
                    }
                }
                countNumber = 0;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
