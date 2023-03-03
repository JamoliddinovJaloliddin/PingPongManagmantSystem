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
    public class EmpolyeeBarProductService : IEmpolyeeBarProductService
    {
        AppDbContext _appDbContext = new AppDbContext();
        ITrackingDetech trackingDetech = new TrackingDetech();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        ITableStatisticService tableStatisticService = new TableStatisticService();

        int count = 0;

        public async Task<bool> CreateAsync(int number, BarCount barCount)
        {
            try
            {
                var resault = (BarCount)await _appDbContext.BarCounts.FirstOrDefaultAsync(x => x.Name == barCount.Name);
                if (resault != null)
                {
                    trackingDetech.TrackingDeteched(resault);
                }


                if (number == 1)
                {
                    resault.Count++;
                    _appDbContext.BarCounts.Update(resault);
                }
                else if (number == 2)
                {
                    if (resault.Count > 0)
                    {
                        if (resault.Count > 0)
                        {
                            resault.Count -= 1;
                            _appDbContext.BarCounts.Update(resault);
                        }
                    }
                }
                var res = await _appDbContext.SaveChangesAsync();
                return res > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<BarCount>> GetAllAsync()
        {
            try
            {
                IList<BarCount> barProducts = new List<BarCount>();
                var barPro = await _appDbContext.BarProducts.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
                foreach (var item in barPro)
                {
                    var res = await _appDbContext.BarCounts.FirstOrDefaultAsync(x => x.Name == item.Name);
                    if (res is null)
                    {
                        BarCount barCount = new BarCount();
                        barCount.Name = item.Name;
                        barCount.Count = 0;
                        barCount.Price = item.SalePrice;
                        _appDbContext.BarCounts.Add(barCount);
                        await _appDbContext.SaveChangesAsync();
                    }
                }
                var barCounts = await _appDbContext.BarCounts.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
                foreach (var item in barCounts)
                {
                    BarCount barCount = new BarCount();
                    barCount.Id = item.Id;
                    barCount.Count = 0;
                    barCount.Name = item.Name;
                    barCount.Price = item.Price;
                    barProducts.Add(barCount);
                }
                return barProducts;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<BarCount>> GetAllBarCountAsync()
        {
            try
            {
                IList<BarCount> barProducts = new List<BarCount>();
                var barPro = await _appDbContext.BarCounts.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
                if (barPro is not null)
                {
                    foreach (var bar in barPro)
                    {
                        BarCount barProduct = new BarCount();
                        barProduct.Id = bar.Id;
                        barProduct.Name = bar.Name;
                        barProduct.Price = bar.Price;
                        barProduct.Count = bar.Count;
                        barProducts.Add(barProduct);
                    }
                    return barProducts;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }



        public async Task<bool> DeleteBarCountAsync(int id, string account, double sum)
        {
            try
            {
                var barCount = await _appDbContext.BarCounts.AsNoTracking().ToListAsync();
                foreach (var bar in barCount)
                {
                    var res = (BarCount)await _appDbContext.BarCounts.FirstOrDefaultAsync(x => x.Name == bar.Name);
                    trackingDetech.TrackingDeteched(res);
                    res.Count = 0;

                    _appDbContext.BarCounts.Update(res);
                }

                if (account != "NotButton")
                {
                    var barUser = (DesktopCassa)await desktopCassaService.GetByIdAsync(id);
                    barUser.AccountBook += $"{account}";
                    barUser.BarSum += sum;
                    _appDbContext.DesktopCassas.Update(barUser);
                }
                var resa = await _appDbContext.SaveChangesAsync();
                return resa > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteBarProductAsync(Dictionary<string, int> keyValuePairs)
        {
            try
            {
                foreach (var product in keyValuePairs)
                {
                    var barProduct = await _appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == product.Key);

                    if (barProduct is not null)
                    {
                        var result = tableStatisticService.UpdateBarAsync(keyValuePairs);


                        trackingDetech.TrackingDeteched(barProduct);
                        barProduct.Count -= product.Value;
                        _appDbContext.BarProducts.Update(barProduct);
                    }
                    else
                    {
                        return false;
                    }
                }
                await _appDbContext.SaveChangesAsync();
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
