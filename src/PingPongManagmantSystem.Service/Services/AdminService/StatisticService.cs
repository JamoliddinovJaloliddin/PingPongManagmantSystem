using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.AdminService
{
    public class StatisticService : IStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<IList<TableStatisticView>> GetAllAsyncStatistic(string search)
        {
            try
            {
                IList<TableStatisticView> tableStatisticViews = new List<TableStatisticView>();
                if (search == "")
                {

                }
                else
                { 
                
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<BarStatisticView>> GetAllBarStatistic(string search)
        {
            try
            {
                IList<BarStatisticView> barStatisticViews = new List<BarStatisticView>();
                if (search == "")
                {

                    BarProduct barProduct = new BarProduct();
                    appDbContext.Entry<BarProduct>(barProduct).State = EntityState.Detached;
                }
                else
                { 
                
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IList<SportStatisticView>> GetAllSportStatistic(string search)
        {
            try
            {
                List<SportStatisticView> sportStatisticViews = new List<SportStatisticView>();
                if (search == "")
                {

                }
                else
                { 
                   
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
