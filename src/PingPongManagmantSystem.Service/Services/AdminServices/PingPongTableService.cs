using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class PingPongTableService : IPingPongTableService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> CreateAsync(PingPongTable user)
        {
            try
            {
                appDbContext.PingPongTables.Add(user);
                var resault = await appDbContext.SaveChangesAsync();
                return resault > 0;
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
                var item = await appDbContext.PingPongTables.FindAsync(id);
                if (item is not null)
                {
                    appDbContext.PingPongTables.Remove(item);
                    var resault = await appDbContext.SaveChangesAsync();
                    return resault > 0;
                }
                return false;

            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<PingPongTable>> GetAllAsync(string search, PaginationParams @params)
        {
            try
            {
                IList<PingPongTable> list = new List<PingPongTable>();
                if (search == "")
                {
                    var itemm = from pingPong in appDbContext.PingPongTables.OrderBy(x => x.Id)
                                select pingPong;
                    var item = await PagedList<PingPongTable>.ToPageListAsync(itemm, @params);

                    foreach (var ite in item)
                    {
                        PingPongTable pingPongTable = new PingPongTable();
                        pingPongTable.Id = ite.Id;
                        pingPongTable.Number = ite.Number;
                        pingPongTable.PriceCheap = ite.PriceCheap;
                        pingPongTable.PriceExpensive = ite.PriceExpensive;
                        list.Add(pingPongTable);
                    }
                }
                else
                {
                    var itemm = from pingPong in appDbContext.PingPongTables.Where(x => x.Number.ToString().Contains(search)
                    || x.PriceCheap.ToString().Contains(search)
                    || x.PriceExpensive.ToString().Contains(search)
                    ).OrderBy(x => x.Id)
                                select pingPong;

                    var item = await PagedList<PingPongTable>.ToPageListAsync(itemm, @params);
                    foreach (var ite in item)
                    {
                        PingPongTable pingPongTable = new PingPongTable();
                        pingPongTable.Id = ite.Id;
                        pingPongTable.Number = ite.Number;
                        pingPongTable.PriceCheap = ite.PriceCheap;
                        pingPongTable.PriceExpensive = ite.PriceExpensive;
                        list.Add(pingPongTable);
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }

        }

        public async Task<PingPongTable> GetByIdAsync(int id)
        {
            try
            {
                PingPongTable pingPongTable = new PingPongTable();
                var res = appDbContext.PingPongTables.Where(x => x.Number == id).AsNoTracking();
                foreach (var item in res)
                {
                    pingPongTable.Number = item.Number;
                    pingPongTable.PriceCheap = item.PriceCheap;
                    pingPongTable.PriceExpensive = item.PriceExpensive;
                }
                return pingPongTable;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(PingPongTable user)
        {
            try
            {
                var resultTable = await appDbContext.PingPongTables.FindAsync(user.Id);

                appDbContext.Entry(resultTable).State = EntityState.Detached;

                if (resultTable is not null)
                {
                    user.Id = resultTable.Id;
                    appDbContext.PingPongTables.Update(user);
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
    }
}
