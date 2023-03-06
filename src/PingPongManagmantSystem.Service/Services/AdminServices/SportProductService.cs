using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class SportProductService : ISportProductService
    {
        AppDbContext _appDbContext = new AppDbContext();
        public async Task<bool> CreateAsync(SportProduct sportProduct)
        {
            try
            {
                await _appDbContext.SportProducts.AddAsync(sportProduct);
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
                var sportProduct = _appDbContext.SportProducts.Find(id);
                if (sportProduct is not null)
                {
                    _appDbContext.SportProducts.Remove(sportProduct);
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

        public async Task<IList<SportProduct>> GetAllAsync(string search, PaginationParams @params)
        {
            try
            {
                IList<SportProduct> spotProduct = new List<SportProduct>();
                if (search == "")
                {
                    var sportPro = _appDbContext.SportProducts.OrderBy(x => x.Name).AsNoTracking();
                    if (sportPro is not null)
                    {
                        foreach (var sport in sportPro)
                        {
                            SportProduct sportProduct = new SportProduct();
                            sportProduct.Id = sport.Id;
                            sportProduct.Name = sport.Name;
                            sportProduct.ArrivalPrice = sport.ArrivalPrice;
                            sportProduct.SalePrice = sport.SalePrice;
                            sportProduct.Count = sport.Count;
                            spotProduct.Add(sportProduct);
                        }
                        return spotProduct;
                    }
                }
                else
                {
                    var sportPro = _appDbContext.SportProducts.Where(x => x.Name.ToLower().Contains(search.ToLower())
                    || x.ArrivalPrice.ToString().Contains(search)
                    || x.SalePrice.ToString().Contains(search)
                    || x.Count.ToString().Contains(search)
                    ).OrderBy(x => x.Name).AsNoTracking();
                    if (sportPro is not null)
                    {
                        foreach (var sport in sportPro)
                        {
                            SportProduct sportProduct = new SportProduct();
                            sportProduct.Id = sport.Id;
                            sportProduct.Name = sport.Name;
                            sportProduct.ArrivalPrice = sport.ArrivalPrice;
                            sportProduct.SalePrice = sport.SalePrice;
                            sportProduct.Count = sport.Count;
                            spotProduct.Add(sportProduct);
                        }
                        return spotProduct;
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

        public async Task<bool> UpdateAsync(SportProduct sportProduct)
        {
            try
            {
                _appDbContext.SportProducts.Update(sportProduct);
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
