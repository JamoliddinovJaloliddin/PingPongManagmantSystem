using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class BarProductService : IBarProductService
    {
       
        public async Task<bool> CreateAsync(BarProduct barProduct)
        {
            try
            {
                AppDbContext _appDbContext = new AppDbContext();
                var resultBar = await _appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == barProduct.Name);
                if (resultBar is null)
                {
                    _appDbContext.BarProducts.Add(barProduct);
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

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                AppDbContext _appDbContext = new AppDbContext();
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

        public async Task<IList<BarProduct>> GetAllAsync(string search, PaginationParams @params)
        {
            try
            {
                AppDbContext _appDbContext = new AppDbContext();
                IList<BarProduct> barProducts = new List<BarProduct>();
                if (search == "")
                {
                    var barPros = from barProo in _appDbContext.BarProducts.OrderBy(x => x.Name)
                                  select barProo;
                    var barPro = await PagedList<BarProduct>.ToPageListAsync(barPros, @params);

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
                    var barPros = from barProo in _appDbContext.BarProducts.Where(x => x.Name.ToLower().Contains(search)
                    || x.ArrivalPrice.ToString().Contains(search)
                    || x.SalePrice.ToString().Contains(search)
                    || x.Count.ToString().Contains(search)
                    ).OrderBy(x => x.Name)
                                  select barProo;

                    var barPro = await PagedList<BarProduct>.ToPageListAsync(barPros, @params);

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

        public async Task<bool> UpdateAsync(BarProduct barProduct)
        {
            try
            {
                AppDbContext _appDbContext = new AppDbContext();
                var result = await _appDbContext.BarProducts.FindAsync(barProduct.Id);
                _appDbContext.Entry(result).State = EntityState.Detached;

                if (result is not null)
                {
                    var resultBar = await _appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == barProduct.Name && x.Id != barProduct.Id);

                    if (resultBar is null)
                    {
                        barProduct.Id = result.Id;
                        _appDbContext.BarProducts.Update(barProduct);
                        var resault = await _appDbContext.SaveChangesAsync();
                        return resault > 0;
                    }
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
