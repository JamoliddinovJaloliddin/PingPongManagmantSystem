using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
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
                var resultUser = await appDbContext.Users.FirstOrDefaultAsync(x => x.Password == user.Password);

                if (resultUser is null)
                {
                    appDbContext.Users.Add(user);
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
                        userView.Password = user.Password;
                        list.Add(userView);
                    }
                }
                else
                {
                    var resaultt = from user in appDbContext.Users.Where(u => u.IsAdmin == 0 && u.Name.ToLower().Contains(search.ToString())
                    || u.PassportInfo.Contains(search.ToString())
                    || u.Password.Contains(search.ToString())).OrderBy(x => x.Name)
                                   select user;

                    var resault = await PagedList<User>.ToPageListAsync(resaultt, @params);

                    foreach (var user in resault)
                    {
                        UserView userView = new UserView();
                        userView.Id = user.Id;
                        userView.Name = user.Name;
                        userView.Passport = user.PassportInfo;
                        userView.Password = user.Password;
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

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                var result = await appDbContext.Users.FindAsync(user.Id);

                appDbContext.Entry(result).State = EntityState.Detached;

                if (result is not null)
                {
                    var passwordResult = await appDbContext.Users.FirstOrDefaultAsync(x => x.Password == user.Password && x.Id != user.Id);
                    if (passwordResult is null)
                    {
                        user.Id = result.Id;
                        user.IsAdmin = 0;
                        appDbContext.Users.Update(user);
                        var res = await appDbContext.SaveChangesAsync();
                        if (res > 0)
                        {
                            return true;
                        }
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
