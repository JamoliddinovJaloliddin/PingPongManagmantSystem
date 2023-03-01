using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class CassaService : ICassaService
    {
        AppDbContext appDbContext = new AppDbContext();

        public Task<bool> CreateAsync(Cassa cassa)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var cassa = await appDbContext.Cassas.FirstOrDefaultAsync(x => x.Id == id);
                if (cassa is not null)
                {
                    appDbContext.Cassas.Remove(cassa);
                    await appDbContext.SaveChangesAsync();
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Cassa>> GetAllAsync(string search)
        {
            try
            {
                List<Cassa> cassas = new List<Cassa>();
                if (search == "")
                {
                    var cassaPage = await appDbContext.Cassas.AsNoTracking().ToListAsync();
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
                        cassas.Add(cassa);
                    }
                }
                else
                {

                    var cassaPage = await appDbContext.Cassas.Where(x => 
                       x.SumPrice.Contains(search.ToLower())
                    || x.TypeOfPrice.Contains(search.ToLower())
                    || x.BarProductPrice.ToString().Contains(search)
                    || x.SportProductPrice.ToString().Contains(search)
                    || x.TypeOfPrice.Contains(search.ToLower())
                    || x.TablePrice.ToString().Contains(search)
                    || x.UserName.Contains(search.ToLower())
                    )
                        .OrderBy(x => x.Id).AsNoTracking().ToListAsync();
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

        public Task<bool> UpdateAsync(Cassa cassa)
        {
            throw new NotImplementedException();
        }
    }
}
