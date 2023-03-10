using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class SportStatisticService : ISportStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<IList<SportStatisticView>> GetAllSportStatistic(string search, PaginationParams @params)
        {
            try
            {
                IList<SportStatisticView> sportStatisticViews = new List<SportStatisticView>();
                int numberCount = 1;

                if (search == "")
                {
                    var moon = MoonHelper.GetCurrentMoon();
                    var statisticResults = from statics in appDbContext.SportStatistics.Where(x => x.DateTime.Contains(moon)).OrderByDescending(x => x.DateTime)
                                           select statics;
                    var statisticResult = await PagedList<SportStatistic>.ToPageListAsync(statisticResults, @params);

                    foreach (var statistic in statisticResult)
                    {
                        SportStatisticView sportStatisticView = new SportStatisticView();

                        sportStatisticView.NumberCount = $"{numberCount}.";
                        sportStatisticView.SportSum = statistic.SportSum;
                        sportStatisticView.NumberOfSaleSport = statistic.NumberOfSaleSport;
                        sportStatisticView.DateTime = statistic.DateTime;
                        sportStatisticView.Check = statistic.Check;
                        sportStatisticViews.Add(sportStatisticView);
                        numberCount++;
                    }
                }
                else
                {
                    var statisticResults = from statistic in appDbContext.SportStatistics.Where(x => x.DateTime.ToLower().Contains(search)).OrderBy(x => x.DateTime)
                                           select statistic;
                    var statisticResult = await PagedList<SportStatistic>.ToPageListAsync(statisticResults, @params);

                    foreach (var statistic in statisticResult)
                    {
                        SportStatisticView sportStatisticView = new SportStatisticView();

                        sportStatisticView.NumberCount = $"{numberCount}.";
                        sportStatisticView.SportSum = statistic.SportSum;
                        sportStatisticView.NumberOfSaleSport = statistic.NumberOfSaleSport;
                        sportStatisticView.Check = statistic.Check;
                        sportStatisticView.DateTime = statistic.DateTime;

                        sportStatisticViews.Add(sportStatisticView);
                        numberCount++;
                    }
                }

                return sportStatisticViews;
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
                var sportCount = await appDbContext.SportStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);

                if (sportCount is null)
                {


                    SportStatistic sportStatistic = new SportStatistic();
                    sportStatistic.DateTime = dateDay;
                    sportStatistic.Check = $"\n\n{GlobalVariable.UserName}\n\n";

                    foreach (var keyValue in keyValuePairs)
                    {
                        var sportPrice = await appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        double sportSum = keyValue.Value * sportPrice.SalePrice;
                        sportStatistic.SportSum += sportSum;
                        sportStatistic.NumberOfSaleSport += keyValue.Value;
                        sportStatistic.Check += $"{keyValue.Key} - {keyValue.Value}\n";
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
                    sportCount.Check += $"\n\n{GlobalVariable.UserName}\n\n";
                    foreach (var keyValue in keyValuePairs)
                    {
                        var sportPrice = await appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == keyValue.Key);
                        double barSum = keyValue.Value * sportPrice.SalePrice;
                        sportCount.SportSum += barSum;
                        sportCount.NumberOfSaleSport += keyValue.Value;
                        sportCount.Check += $"{keyValue.Key} - {keyValue.Value}\n";
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
