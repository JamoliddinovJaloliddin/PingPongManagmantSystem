using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class EmpolyeeBarProductService : IEmpolyeeBarProductService
    {
        AppDbContext _appDbContext = new AppDbContext();
        public async Task<IList<BarView>> GetAllAsync()
        {
            try
            {
                IList<BarView> barProducts = new List<BarView>();
                var barPro = _appDbContext.BarProducts.OrderBy(x => x.Name).AsNoTracking();
                if (barPro is not null)
                {
                    foreach (var bar in barPro)
                    {
                        BarView barProduct = new BarView();
                        barProduct.Id = bar.Id;
                        barProduct.Name = bar.Name;
                        barProduct.SalePrice = bar.SalePrice;
                        barProduct.Count = 0;
                        barProducts.Add(barProduct);
                    }
                    return barProducts;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
