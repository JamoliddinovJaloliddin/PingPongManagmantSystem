using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;

#pragma warning disable

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class EmpolyeeBarProductService : IEmpolyeeBarProductService
    {
        AppDbContext _appDbContext = new AppDbContext();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        IBarStatisticService barStatisticService = new BarStatisticService();
        ITableStatisticService tableStatisticService = new TableStatisticService();
        IEmpolyeeStatsiticService empolyeeStatsiticService = new EmpolyeeStatisticService();

        int count = 0;

        public async Task<bool> CreateAsync(int number, BarCount barCount)
        {
            try
            {
                var countResult = await _appDbContext.BarCounts.FindAsync(barCount.Id);

                if (number == 1)
                {
                    _appDbContext.Entry(countResult).State = EntityState.Detached;
                    countResult.Count++;
                    _appDbContext.BarCounts.Update(countResult);
                }
                else if (number == 2)
                {
                    if (barCount.Count > 0 && countResult.Count >= barCount.Count && countResult.Count != null)
                    {
                        _appDbContext.Entry(countResult).State = EntityState.Detached;
                        countResult.Count--;
                        _appDbContext.BarCounts.Update(countResult);
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
                List<BarCount> barProducts = new List<BarCount>();

                var barPro = await _appDbContext.BarProducts.OrderBy(x => x.Name).AsNoTracking().ToListAsync();

                foreach (var item in barPro)
                {
                    BarCount barCount = new BarCount();

                    _appDbContext.Entry(barCount).State = EntityState.Detached;
                    barCount.Name = item.Name;
                    barCount.Count = 0;
                    barCount.Price = item.SalePrice;
                    _appDbContext.BarCounts.Add(barCount);
                }
                var res = await _appDbContext.SaveChangesAsync();

                var barCountt = await _appDbContext.BarCounts.AsNoTracking().ToListAsync();
                foreach (var item in barCountt)
                {
                    barProducts.Add(item);
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
                        _appDbContext.Entry(barProduct).State = EntityState.Detached;
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
                foreach (var item in barCount)
                {
                    var itemCount = (BarCount)await _appDbContext.BarCounts.FindAsync(item.Id);
                    _appDbContext.Entry(itemCount).State = EntityState.Detached;
                    _appDbContext.BarCounts.Remove(itemCount);
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

        public async Task<bool> DeleteBarProductAsync(Dictionary<string, int> keyValuePairs, string paymentType)
        {
            try
            {
                double totalSum = 0;
                var barStatistic = await barStatisticService.UpdateAsync(keyValuePairs, paymentType);
               
                foreach (var product in keyValuePairs)
                {
                    var barProduct = (BarProduct)await _appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == product.Key);


                    if (barProduct is not null)
                    {
                        _appDbContext.Entry(barProduct).State = EntityState.Detached;
                        if ((barProduct.Count - (int)product.Value) > 0)
                        {
                            barProduct.Count = barProduct.Count - (int)product.Value;
                            totalSum += product.Value * barProduct.SalePrice;
                            _appDbContext.BarProducts.Update(barProduct);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                var result = await _appDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    var empolyeeStatistic = await empolyeeStatsiticService.CreateBarAsync(totalSum, paymentType);
                }
                totalSum = 0;
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CheckProductAsync(Dictionary<string, int> keyValuePairs)
        {
            try
            {
                foreach (var product in keyValuePairs)
                {
                    var barProduct = (BarProduct)await _appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == product.Key);

                    if (barProduct is not null)
                    {
                        _appDbContext.Entry(barProduct).State = EntityState.Detached;
                        if ((barProduct.Count -= product.Value) < 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
