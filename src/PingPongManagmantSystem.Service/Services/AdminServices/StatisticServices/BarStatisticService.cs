using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

#pragma warning disable

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
                        barStatisticView.Check = statistic.Check;
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
                        barStatisticView.Check = statistic.Check;
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
                    barStatistic.Check = $"\n\n{GlobalVariable.UserName}\n\n";
                    foreach (var keyValue in keyValuePairs)
                    {
                        var barPrice = await appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        appDbContext.Entry(barPrice).State = EntityState.Detached;
                        double barSum = keyValue.Value * barPrice.SalePrice;
                        barStatistic.BarSum += barSum;
                        barStatistic.NumberOfSaleBar += keyValue.Value;
                        barStatistic.Check += $"{keyValue.Key} - {keyValue.Value}\n";
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
                    appDbContext.Entry(barCount).State = EntityState.Detached;
                    barCount.Check += $"\n\n{GlobalVariable.UserName}\n\n";
                    foreach (var keyValue in keyValuePairs)
                    {
                        double barSum = 0;
                        var barPrice = await appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        if (barPrice is not null)
                        {
                            appDbContext.Entry(barPrice).State = EntityState.Detached;
                            barSum = keyValue.Value * barPrice.SalePrice;
                            barCount.BarSum += barSum;
                            barCount.NumberOfSaleBar += keyValue.Value;
                            barCount.Check += $"{keyValue.Key} - {keyValue.Value}\n";
                        }
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
