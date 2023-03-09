using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class CassaService : ICassaService
    {
        AppDbContext appDbContext = new AppDbContext();

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var cassa = await appDbContext.Cassas.FirstOrDefaultAsync(x => x.Id == id);
                if (cassa is not null)
                {
                    appDbContext.Cassas.Remove(cassa);
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

        public async Task<List<Cassa>> GetAllAsync(string search, PaginationParams @params)
        {
            try
            {
                List<Cassa> cassas = new List<Cassa>();
                if (search == "")
                {
                    var cassaPages = from cassa in appDbContext.Cassas.OrderBy(x => x.DateTime)
                                     select cassa;

                    var cassaPage = await PagedList<Cassa>.ToPageListAsync(cassaPages, @params);

                    foreach (var item in cassaPage)
                    {
                        Cassa cassa = new Cassa();
                        appDbContext.Entry<Cassa>(cassa).State = EntityState.Detached;
                        cassa.Id = item.Id;
                        cassa.SumPrice = item.SumPrice;
                        cassa.SportProductPrice = item.SportProductPrice;
                        cassa.BarProductPrice = item.BarProductPrice;
                        cassa.TypeOfPrice = item.TypeOfPrice;
                        cassa.TablePrice = item.TablePrice;
                        cassa.Check = item.Check;
                        cassa.UserName = item.UserName;
                        cassa.DateTime = item.DateTime;
                        cassas.Add(cassa);
                    }
                }
                else
                {
                    var cassaPages = from cass in appDbContext.Cassas.Where(x =>
                       x.SumPrice.Contains(search.ToLower())
                    || x.TypeOfPrice.Contains(search.ToLower())
                    || x.BarProductPrice.ToString().Contains(search)
                    || x.SportProductPrice.ToString().Contains(search)
                    || x.TypeOfPrice.Contains(search.ToLower())
                    || x.TablePrice.ToString().Contains(search)
                    || x.UserName.Contains(search.ToLower())
                    || x.DateTime.Contains(search.ToLower())
                    ).OrderBy(x => x.Id)
                                     select cass;

                    var cassaPage = await PagedList<Cassa>.ToPageListAsync(cassaPages, @params);

                    Cassa cassa = new Cassa();
                    foreach (var item in cassaPage)
                    {
                        cassa.Id = item.Id;
                        cassa.SumPrice = item.SumPrice;
                        cassa.SportProductPrice = item.SportProductPrice;
                        cassa.BarProductPrice = item.BarProductPrice;
                        cassa.TypeOfPrice = item.TypeOfPrice;
                        cassa.TablePrice = item.TablePrice;
                        cassa.Check = item.Check;
                        cassa.UserName = item.UserName;
                        cassa.DateTime = item.DateTime;
                        cassas.Add(cassa);
                    }
                }
                return cassas;

            }
            catch
            {
                return null;
            }

        }

        public async Task<string> GetByIdAsync(int id)
        {
            try
            {
                var resault = await appDbContext.Cassas.FirstOrDefaultAsync(x => x.Id == id);
                if (resault is not null)
                {
                    return resault.Check;
                }
                return "Ma'lumot yo'q";
            }
            catch
            {
                return "";
            }
        }
    }
}
