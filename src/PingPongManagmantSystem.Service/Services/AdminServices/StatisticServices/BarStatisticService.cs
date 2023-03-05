using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.Common;
using PingPongManagmantSystem.Service.Services.Common;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class BarStatisticService : IBarStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        ITrackingDetech trackingDetech = new TrackingDetech();
        public Task<IList<BarStatisticView>> GetAllBarStatistic(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Dictionary<string, int> keyValuePairs, string paymentType)
        {
            try
            {
                var dateDay = DayHelper.GetCurrentServerDay();
                var barCount = await appDbContext.BarStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);

                if (barCount is null)
                {
                    BarStatistic barStatistic = new BarStatistic();
                    barStatistic.DateTime = dateDay;
                    foreach (var keyValue in keyValuePairs)
                    {
                        var barPrice = await appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        double barSum = keyValue.Value * barPrice.SalePrice;
                        barStatistic.BarSum += barSum;
                        barStatistic.NumberOfSaleBar += keyValue.Value;
                        if (paymentType == "Naxt")
                        {
                            barStatistic.Cash += barSum;
                        }
                        else if (paymentType == "Karta")
                        {
                            barStatistic.Card += barSum;
                        }
                    }
                    appDbContext.BarStatistics.Add(barStatistic);
                }
                else
                {
                    foreach (var keyValue in keyValuePairs)
                    {
                        var barPrice = await appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        double barSum = keyValue.Value * barPrice.SalePrice;
                        barCount.BarSum += barSum;
                        barCount.NumberOfSaleBar += keyValue.Value;
                        if (paymentType == "Naxt")
                        {
                            barCount.Cash += barSum;
                        }
                        else if (paymentType == "Karta")
                        {
                            barCount.Card += barSum;
                        }
                    }
                    appDbContext.BarStatistics.Update(barCount);
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
