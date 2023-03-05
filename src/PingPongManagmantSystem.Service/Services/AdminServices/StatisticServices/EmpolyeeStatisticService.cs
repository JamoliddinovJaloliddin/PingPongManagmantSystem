using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class EmpolyeeStatisticService : IEmpolyeeStatsiticService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> CreateAsync(double totalPrice, string paymentType)
        {
            try
            {
                string dateDay = DayHelper.GetCurrentServerDay();
                var empolyeeStatisticResult = await appDbContext.EmpolyeeStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);
                if (empolyeeStatisticResult is null)
                {
                    EmpolyeeStatistic empolyeeStatistic = new EmpolyeeStatistic();
                    empolyeeStatistic.DateTime = dateDay;
                    empolyeeStatistic.BarSum = totalPrice;
                    empolyeeStatistic.UserId = GlobalVariable.UserId;

                    appDbContext.EmpolyeeStatistics.Add(empolyeeStatistic);
                }
                else
                {
                    var empolyeeStatisticUserId = await appDbContext.EmpolyeeStatistics.FirstOrDefaultAsync(
                        x => x.UserId == GlobalVariable.UserId && x.DateTime == dateDay);

                    if (empolyeeStatisticUserId is not null)
                    {
                        appDbContext.Entry(empolyeeStatisticUserId).State = EntityState.Detached;
                        empolyeeStatisticUserId.BarSum += totalPrice;
                        appDbContext.EmpolyeeStatistics.Update(empolyeeStatisticUserId);
                    }
                    else
                    {
                        EmpolyeeStatistic empolyeeStatistic = new EmpolyeeStatistic();
                        empolyeeStatistic.DateTime = dateDay;
                        empolyeeStatistic.BarSum = totalPrice;
                        empolyeeStatistic.UserId = GlobalVariable.UserId;

                        appDbContext.EmpolyeeStatistics.Add(empolyeeStatistic);
                    }
                }

                var result = await appDbContext.SaveChangesAsync();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<SportStatisticView>> GetAllSportStatistic(string search)
        {
            try
            {


                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
