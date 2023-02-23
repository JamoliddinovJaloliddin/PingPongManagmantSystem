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

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cassa>> GetAllAsync()
        {
            try
            {
                List<Cassa> cassas = new List<Cassa>();
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
                return cassas;
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

        public Task<bool> UpdateAsync(Cassa cassa)
        {
            throw new NotImplementedException();
        }
    }
}
