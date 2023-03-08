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
                var resultSportProduct = await _appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == sportProduct.Name); ;
                if (resultSportProduct is null)
                {
                    await _appDbContext.SportProducts.AddAsync(sportProduct);
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
                var sportProduct = await _appDbContext.SportProducts.FindAsync(id);
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
                    var sportProo = from sport in _appDbContext.SportProducts.OrderBy(x => x.Name)
                                    select sport;
                    var sportPro = await PagedList<SportProduct>.ToPageListAsync(sportProo, @params);

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
                    var sportProo = from sport in _appDbContext.SportProducts.Where(x => x.Name.ToLower().Contains(search.ToLower())
                    || x.ArrivalPrice.ToString().Contains(search)
                    || x.SalePrice.ToString().Contains(search)
                    || x.Count.ToString().Contains(search)
                    ).OrderBy(x => x.Name)
                                    select sport;

                    var sportPro = await PagedList<SportProduct>.ToPageListAsync(sportProo, @params);

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

        public async Task<bool> UpdateAsync(SportProduct sportProduct)
        {
            try
            {
                var resultSport = await _appDbContext.SportProducts.FindAsync(sportProduct.Id);
                _appDbContext.Entry(resultSport).State = EntityState.Detached;

                if (resultSport is not null)
                {

                    var resultSports = await _appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == sportProduct.Name && x.Id != sportProduct.Id);
                    if (resultSports is null)
                    {
                        sportProduct.Id = resultSport.Id;
                        _appDbContext.SportProducts.Update(sportProduct);
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
