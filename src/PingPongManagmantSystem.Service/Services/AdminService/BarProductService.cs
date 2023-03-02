using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class BarProductService : IBarProductService
    {
        AppDbContext _appDbContext = new AppDbContext();
        public async Task<bool> CreateAsync(BarProduct barProduct)
        {
            try
            {
                await _appDbContext.BarProducts.AddAsync(barProduct);
                var resault = await _appDbContext.SaveChangesAsync();
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
                var barProduct = await _appDbContext.BarProducts.FindAsync(id);
                if (barProduct is not null)
                {
                    _appDbContext.BarProducts.Remove(barProduct);
                    var resault = await _appDbContext.SaveChangesAsync();
                    return resault > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<IList<BarProduct>> GetAllAsync(string search)
        {
            try
            {
                IList<BarProduct> barProducts = new List<BarProduct>();
                if (search == "")
                {
                    var barPro = _appDbContext.BarProducts.OrderBy(x => x.Name).AsNoTracking();
                    if (barPro is not null)
                    {
                        foreach (var bar in barPro)
                        {
                            BarProduct barProduct = new BarProduct();
                            barProduct.Id = bar.Id;
                            barProduct.Name = bar.Name;
                            barProduct.ArrivalPrice = bar.ArrivalPrice;
                            barProduct.SalePrice = bar.SalePrice;
                            barProduct.Count = bar.Count;
                            barProducts.Add(barProduct);
                        }
                        return barProducts;
                    }
                }
                else
                {
                    var barPro = _appDbContext.BarProducts.Where(x => x.Name.ToLower().Contains(search)
                    || x.ArrivalPrice.ToString().Contains(search)
                    || x.SalePrice.ToString().Contains(search)
                    || x.Count.ToString().Contains(search)
                    ).OrderBy(x => x.Name).AsNoTracking();
                    if (barPro is not null)
                    {
                        foreach (var bar in barPro)
                        {
                            BarProduct barProduct = new BarProduct();
                            barProduct.Id = bar.Id;
                            barProduct.Name = bar.Name;
                            barProduct.ArrivalPrice = bar.ArrivalPrice;
                            barProduct.SalePrice = bar.SalePrice;
                            barProduct.Count = bar.Count;
                            barProducts.Add(barProduct);
                        }
                        return barProducts;
                    }
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

        public async Task<bool> UpdateAsync(BarProduct barProduct)
        {
            try
            {
                _appDbContext.BarProducts.Update(barProduct);
                var resault = await _appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
