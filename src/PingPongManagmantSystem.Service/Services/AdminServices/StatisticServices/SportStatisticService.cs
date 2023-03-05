using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class SportStatisticService : ISportStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        public Task<IList<SportStatisticView>> GetAllSportStatistic(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Dictionary<string, int> keyValuePairs, string paymentType)
        {
            try
            {
                var dateDay = DayHelper.GetCurrentServerDay();
                var sportCount = await appDbContext.SportStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);

                if (sportCount is null)
                {
                    SportStatistic sportStatistic = new SportStatistic();
                    sportStatistic.DateTime = dateDay;
                    foreach (var keyValue in keyValuePairs)
                    {
                        var sportPrice = await appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        double sportSum = keyValue.Value * sportPrice.SalePrice;
                        sportStatistic.SportSum += sportSum;
                        sportStatistic.NumberOfSaleSport += keyValue.Value;
                        if (paymentType == "Naxt")
                        {
                            sportStatistic.Cash += sportSum;
                        }
                        else if (paymentType == "Karta")
                        {
                            sportStatistic.Card += sportSum;
                        }
                    }
                    appDbContext.SportStatistics.Add(sportStatistic);
                }
                else
                {
                    foreach (var keyValue in keyValuePairs)
                    {
                        var sportPrice = await appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        double barSum = keyValue.Value * sportPrice.SalePrice;
                        sportCount.SportSum += barSum;
                        sportCount.NumberOfSaleSport += keyValue.Value;
                        if (paymentType == "Naxt")
                        {
                            sportCount.Cash += barSum;
                        }
                        else if (paymentType == "Karta")
                        {
                            sportCount.Card += barSum;
                        }
                    }
                    appDbContext.SportStatistics.Update(sportCount);
                }

                var result = await appDbContext.SaveChangesAsync();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
