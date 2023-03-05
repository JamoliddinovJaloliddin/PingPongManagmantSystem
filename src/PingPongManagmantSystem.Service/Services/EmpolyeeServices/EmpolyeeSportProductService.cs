using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.Common;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using PingPongManagmantSystem.Service.Services.Common;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class EmpolyeeSportProductService : IEmpolyeeSportProductService
    {
        AppDbContext appDbContext = new AppDbContext();
        ITableStatisticService tableStatisticService = new TableStatisticService();
        ITrackingDetech trackingDetech = new TrackingDetech();
        

        public async Task<bool> CreateAsync(int number, SportCount sportCount)
        {
            try
            {
                var countResult = await appDbContext.SportCounts.FindAsync(sportCount.Id);

                if (number == 1)
                {
                    appDbContext.Entry(countResult).State = EntityState.Detached;
                    countResult.Count++;
                    appDbContext.SportCounts.Update(countResult);
                }
                else if (number == 2)
                {
                    if (sportCount.Count > 0)
                    {
                        appDbContext.Entry(countResult).State = EntityState.Detached;
                        countResult.Count--;
                        appDbContext.SportCounts.Update(countResult);
                    }
                }
                var res = await appDbContext.SaveChangesAsync();
                return res > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteSportCountAsync()
        {
            try
            {
                var sportCount = await appDbContext.SportCounts.AsNoTracking().ToListAsync();
                foreach (var item in sportCount)
                {
                    var itemCount = (SportCount)await appDbContext.SportCounts.FindAsync(item.Id);
                    appDbContext.Entry(itemCount).State = EntityState.Detached;
                    appDbContext.SportCounts.Remove(itemCount);
                }
                var resa = await appDbContext.SaveChangesAsync();
                return resa > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteSportProductAsync(Dictionary<string, int> keyValuePairs)
        {
            try
            {
                foreach (var product in keyValuePairs)
                {
                    var res = await appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == product.Key);
                    if (res is not null)
                    {
                        //var result = await tableStatisticService.UpdateProductAsync(keyValuePairs);


                        trackingDetech.TrackingDeteched(res);
                        res.Count -= product.Value;
                        appDbContext.SportProducts.Update(res);
                    }
                }
                var resault = await appDbContext.SaveChangesAsync();

                return resault > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<SportCount>> GetAllAsync()
        {
            try
            {
                List<SportCount> sportProducts = new List<SportCount>();
                
                var sportPro = await appDbContext.SportProducts.OrderBy(x => x.Name).AsNoTracking().ToListAsync();

                foreach (var item in sportPro)
                {
                    SportCount sportCount = new SportCount();

                    appDbContext.Entry(sportCount).State = EntityState.Detached;
                    sportCount.Name = item.Name;
                    sportCount.Count = 0;
                    sportCount.Price = item.SalePrice;
                    appDbContext.SportCounts.Add(sportCount);
                }
                var res = await appDbContext.SaveChangesAsync();

                var sportCountt = await appDbContext.SportCounts.AsNoTracking().ToListAsync();
                foreach (var item in sportCountt)
                {
                    sportProducts.Add(item);
                }
                return sportProducts;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<SportCount>> GetAllSportProductAsync()
        {
            try
            {
                List<SportCount> sportProducts = new List<SportCount>();
                var sportPro = await appDbContext.SportCounts.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
                if (sportPro is not null)
                {
                    foreach (var bar in sportPro)
                    {
                        SportCount sportProduct = new SportCount();
                        appDbContext.Entry(sportProduct).State = EntityState.Detached;
                        sportProduct.Id = bar.Id;
                        sportProduct.Name = bar.Name;
                        sportProduct.Price = bar.Price;
                        sportProduct.Count = bar.Count;
                        sportProducts.Add(sportProduct);
                    }
                    return sportProducts;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
