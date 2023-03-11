using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class BarStatisticService : IBarStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<IList<BarStatisticView>> GetAllBarStatistic(string search, PaginationParams @params)
        {
            try
            {
                IList<BarStatisticView> barStatisticViews = new List<BarStatisticView>();
                int numberCount = 1;
                if (search == "")
                {
                    var moon = MoonHelper.GetCurrentMoon();

                    var statisticResults = from statics in appDbContext.BarStatistics.Where(x => x.DateTime.Contains(moon)).OrderByDescending(x => x.DateTime)
                                           select statics;
                    var statisticResult = await PagedList<BarStatistic>.ToPageListAsync(statisticResults, @params);
                    foreach (var statistic in statisticResult)
                    {
                        BarStatisticView barStatisticView = new BarStatisticView();

                        barStatisticView.NumberCount = $"{numberCount}.";
                        barStatisticView.NumberOfSaleBar = statistic.NumberOfSaleBar;
                        barStatisticView.DateTime = statistic.DateTime;
                        barStatisticView.BarSum = statistic.BarSum;
                        barStatisticViews.Add(barStatisticView);
                        numberCount++;
                    }
                }
                else
                {
                    var statisticResults = from statics in appDbContext.BarStatistics.Where(x => x.DateTime.ToLower().Contains(search)).OrderBy(x => x.DateTime)
                                           select statics;
                    var statisticResult = await PagedList<BarStatistic>.ToPageListAsync(statisticResults, @params);
                    foreach (var statistic in statisticResult)
                    {
                        BarStatisticView barStatisticView = new BarStatisticView();


                        barStatisticView.NumberCount = $"{numberCount}.";
                        barStatisticView.NumberOfSaleBar = statistic.NumberOfSaleBar;
                        barStatisticView.DateTime = statistic.DateTime;
                        barStatisticView.BarSum = statistic.BarSum;
                        barStatisticViews.Add(barStatisticView);
                        numberCount++;
                    }
                }
                return barStatisticViews;
            }
            catch
            {
                return null;
            }
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
