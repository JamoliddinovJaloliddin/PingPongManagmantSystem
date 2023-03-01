using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class UserService : IUserService
    {
        AppDbContext db = new AppDbContext();
        public async Task<bool> CreateAsync(User user)
        {
            try
            {
                db.Users.Add(user);
                var res = await db.SaveChangesAsync();
                if (res > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                var resault = await db.SaveChangesAsync();
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

        public async Task<IList<UserView>> GetAllAsync(string search)
        {
            try
            {
                List<UserView> list = new List<UserView>();
                if (search == "")
                {
                    var resault = db.Users.Where(u => u.IsAdmin == 0).AsNoTracking();
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
                    var resault = db.Users.Where(u => u.IsAdmin == 0 && u.Name.Contains(search.ToString()) 
                    || u.PassportInfo.Contains(search.ToString()) 
                    || u.Password.Contains(search.ToString())).AsNoTracking();
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

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                user.IsAdmin = 0;
                db.Users.Update(user);
                var res = await db.SaveChangesAsync();
                if (res > 0)
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
    }
}
