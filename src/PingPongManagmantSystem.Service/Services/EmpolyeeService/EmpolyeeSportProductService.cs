using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.Common;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.Common;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class EmpolyeeSportProductService : IEmpolyeeSportProductService
    {
        AppDbContext appDbContext = new AppDbContext();
        ITrackingDetech<SportCount> trackingDetech = new TrackingDetech<SportCount>();
        ITrackingDetech<SportProduct> trackingDeteched = new TrackingDetech<SportProduct>();

        public async Task<bool> CreateAsync(int id, SportCount sportCount)
        {
            try
            {
                var resault = (SportCount)await appDbContext.SportCounts.FirstOrDefaultAsync(x => x.Name == sportCount.Name);
                if (resault != null)
                {
                    trackingDetech.TrackingDeteched(resault);
                    if (id == 1)
                    {
                        resault.Count++;
                        appDbContext.SportCounts.Update(resault);
                    }
                    else if (id == 2)
                    {
                        if (resault.Count > 0)
                        {
                            resault.Count--;
                            appDbContext.SportCounts.Update(resault);
                        }
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

        public async Task<bool> DeleteCountAsync()
        {
            try
            {
                var resault = await appDbContext.SportCounts.AsNoTracking().ToListAsync();
                if (resault is not null)
                {
                    foreach (var item in resault)
                    {
                        var res = (SportCount)await appDbContext.SportCounts.FirstOrDefaultAsync(x => x.Name == item.Name);
                        trackingDetech.TrackingDeteched(res);
                        res.Count = 0;
                        appDbContext.SportCounts.Update(res);
                    }
                }

                var ress = await appDbContext.SaveChangesAsync();
                return ress > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(Dictionary<string, int> keyValuePairs)
        {
            try
            {
                foreach (var product in keyValuePairs)
                {
                    var res = await appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == product.Key);
                    if (res is not null)
                    {
                        trackingDeteched.TrackingDeteched(res);
                        res.Count -= product.Value;
                        appDbContext.SportProducts.Update(res);
                    }
                }
                await appDbContext.SaveChangesAsync();

                return false;
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
                List<SportCount> products = new List<SportCount>();
                var resault = await appDbContext.SportProducts.AsNoTracking().ToListAsync();
                foreach (var product in resault)
                {
                    var sportPro = await appDbContext.SportCounts.FirstOrDefaultAsync(x => x.Name == product.Name);
                    if (sportPro is null)
                    {
                        SportCount sportCount = new SportCount();
                        sportCount.Name = product.Name;
                        sportCount.Price = product.SalePrice;
                        sportCount.Count = 0;
                        
                        appDbContext.SportCounts.Add(sportCount);
                        await appDbContext.SaveChangesAsync();
                    }
                }

                var sportProduct = await appDbContext.SportCounts.AsNoTracking().ToListAsync();
                foreach (var item in sportProduct)
                {
                    SportCount sportProduct1 = new SportCount();
                    sportProduct1.Count = item.Count;
                    sportProduct1.Name = item.Name;
                    sportProduct1.Price = item.Price;
                    products.Add(sportProduct1);
                }
                await appDbContext.SaveChangesAsync();

                return sportProduct;
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
                var resault =  await appDbContext.SportCounts.AsNoTracking().ToListAsync();
                foreach (var item in resault)
                { 
                    SportCount sportProduct = new SportCount();
                    sportProduct.Count = item.Count;
                    sportProduct.Price = item.Count;
                    sportProduct.Name = item.Name;
                    sportProducts.Add(sportProduct);
                }
                return sportProducts;
            }
            catch
            {
                return null;
            }
        }
    }
}
