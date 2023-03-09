using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Enums;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class EmpolyeeStatisticService : IEmpolyeeStatsiticService
    {
        AppDbContext appDbContext = new AppDbContext();

        public async Task<bool> CreateBarAsync(double totalPrice, string paymentType)
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
                    numberCount++;
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
                        numberCount++;
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

        public async Task<bool> CreateSportAsync(double totalPrice, string paymentType)
        {
            try
            {
                var dateDay = DayHelper.GetCurrentServerDay();
                var empolyeeStatisticResult = await appDbContext.EmpolyeeStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);

                if (empolyeeStatisticResult is null)
                {
                    EmpolyeeStatistic empolyeeStatistic = new EmpolyeeStatistic();
                    empolyeeStatistic.DateTime = dateDay;
                    empolyeeStatistic.SportSum = totalPrice;
                    empolyeeStatistic.UserId = GlobalVariable.UserId;

                    appDbContext.EmpolyeeStatistics.Add(empolyeeStatistic);
                }
                else
                {
                    var empolyeeStatisticUserId = await appDbContext.EmpolyeeStatistics.FirstOrDefaultAsync
                        (x => x.DateTime == dateDay && x.UserId == GlobalVariable.UserId);

                    if (empolyeeStatisticUserId is not null)
                    {
                        appDbContext.Entry(empolyeeStatisticUserId).State = EntityState.Detached;
                        empolyeeStatisticUserId.SportSum += totalPrice;
                        appDbContext.EmpolyeeStatistics.Update(empolyeeStatisticUserId);
                    }
                    else
                    {
                        EmpolyeeStatistic empolyeeStatistic = new EmpolyeeStatistic();
                        empolyeeStatistic.DateTime = dateDay;
                        empolyeeStatistic.SportSum = totalPrice;
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

        public async Task<bool> CreateTableAsync(double totalPrice, string paymentType)
        {
            try
            {
                var dateDay = DayHelper.GetCurrentServerDay();
                var empolyeeStatisticResult = await appDbContext.EmpolyeeStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);

                if (empolyeeStatisticResult is null)
                {
                    EmpolyeeStatistic empolyeeStatistic = new EmpolyeeStatistic();
                    if (paymentType != Payment.VipKarta.ToString())
                    {
                        empolyeeStatistic.DateTime = dateDay;
                        empolyeeStatistic.TableSum = totalPrice;
                        empolyeeStatistic.UserId = GlobalVariable.UserId;
                    }
                    else
                    {
                        empolyeeStatistic.DateTime = dateDay;
                        empolyeeStatistic.VipCardSum = totalPrice;
                        empolyeeStatistic.UserId = GlobalVariable.UserId;
                    }
                    appDbContext.EmpolyeeStatistics.Add(empolyeeStatistic);
                }
                else
                {
                    var empolyeeStatisticUserId = await appDbContext.EmpolyeeStatistics.FirstOrDefaultAsync
                        (x => x.DateTime == dateDay && x.UserId == GlobalVariable.UserId);

                    if (empolyeeStatisticUserId is not null)
                    {
                        if (paymentType != Payment.VipKarta.ToString())
                        {
                            appDbContext.Entry(empolyeeStatisticUserId).State = EntityState.Detached;
                            empolyeeStatisticUserId.TableSum += totalPrice;
                            appDbContext.EmpolyeeStatistics.Update(empolyeeStatisticUserId);
                        }
                        else
                        {
                            appDbContext.Entry(empolyeeStatisticUserId).State = EntityState.Detached;
                            empolyeeStatisticUserId.VipCardSum += totalPrice;
                            appDbContext.EmpolyeeStatistics.Update(empolyeeStatisticUserId);
                        }
                    }
                    else
                    {
                        EmpolyeeStatistic empolyeeStatistic = new EmpolyeeStatistic();

                        if (paymentType != Payment.VipKarta.ToString())
                        {
                            empolyeeStatistic.DateTime = dateDay;
                            empolyeeStatistic.TableSum = totalPrice;
                            empolyeeStatistic.UserId = GlobalVariable.UserId;
                        }
                        else
                        {
                            empolyeeStatistic.DateTime = dateDay;
                            empolyeeStatistic.VipCardSum = totalPrice;
                            empolyeeStatistic.UserId = GlobalVariable.UserId;
                        }

                        appDbContext.EmpolyeeStatistics.Add(empolyeeStatistic);
                    }
                }

                var result = await appDbContext.SaveChangesAsync();

                return result > 0;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync()
        {
            try
            {
                var resultUserStatistic = await appDbContext.EmpolyeeStatistics.AsNoTracking().ToListAsync();
                foreach (var item in resultUserStatistic)
                {
                    var resultUser = await appDbContext.Users.FindAsync(item.UserId);
                    if (resultUser is null)
                    {
                        appDbContext.EmpolyeeStatistics.Remove(item);
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

        public async Task<IList<EmpolyeeStatisticView>> GetAllEmpolyeeStatistic(string search, PaginationParams @params)
        {
            try
            {
                IList<EmpolyeeStatisticView> empolyeeStatisticViews = new List<EmpolyeeStatisticView>();
                int numberCount = 1;
                var result = await DeleteAsync();

                if (search == "")
                {

                    var moon = MoonHelper.GetCurrentMoon();

                    var statisticResults = from statics in appDbContext.EmpolyeeStatistics.Where(x => x.DateTime.StartsWith(moon)).OrderBy(x => x.DateTime)
                                           select statics;
                    var statisticResult = await PagedList<EmpolyeeStatistic>.ToPageListAsync(statisticResults, @params);

                    if (statisticResult is not null)
                    {
                        foreach (var statistic in statisticResult)
                        {
                            var user = await appDbContext.Users.FindAsync(statistic.UserId);
                            appDbContext.Entry(user).State = EntityState.Detached;


                            EmpolyeeStatisticView empolyeeStatisticView = new EmpolyeeStatisticView();
                            empolyeeStatisticView.NumberCount = $"{numberCount}.";
                            empolyeeStatisticView.UserName = user.Name;
                            empolyeeStatisticView.VipCardSum = statistic.VipCardSum;
                            empolyeeStatisticView.SportSum = statistic.SportSum;
                            empolyeeStatisticView.BarSum = statistic.BarSum;
                            empolyeeStatisticView.TableSum = statistic.TableSum;
                            empolyeeStatisticView.DateTime = statistic.DateTime;
                            empolyeeStatisticView.ViCardToSell = statistic.ViCardToSell;

                            empolyeeStatisticViews.Add(empolyeeStatisticView);
                        }
                    }
                }
                else
                {
                    var userQuery = (from user in appDbContext.Users.Where(x => x.Name.ToLower().Contains(search))
                                     select user.Id).ToList();

                    var statisticResults = from statics in appDbContext.EmpolyeeStatistics.Where(x => x.DateTime.ToLower().Contains(search) || userQuery.Contains(x.UserId)).OrderBy(x => x.DateTime)
                                           select statics;

                    var statisticResult = await PagedList<EmpolyeeStatistic>.ToPageListAsync(statisticResults, @params);
                    if (statisticResult is not null)
                    {
                        foreach (var statistic in statisticResult)
                        {
                            var user = await appDbContext.Users.FindAsync(statistic.UserId);

                            appDbContext.Entry(user).State = EntityState.Detached;

                            EmpolyeeStatisticView empolyeeStatisticView = new EmpolyeeStatisticView();
                            empolyeeStatisticView.NumberCount = $"{numberCount}.";
                            empolyeeStatisticView.UserName = user.Name;
                            empolyeeStatisticView.VipCardSum = statistic.VipCardSum;
                            empolyeeStatisticView.SportSum = statistic.SportSum;
                            empolyeeStatisticView.BarSum = statistic.BarSum;
                            empolyeeStatisticView.TableSum = statistic.TableSum;
                            empolyeeStatisticView.DateTime = statistic.DateTime;
                            empolyeeStatisticView.ViCardToSell = statistic.ViCardToSell;

                            empolyeeStatisticViews.Add(empolyeeStatisticView);
                        }
                    }
                }

                return empolyeeStatisticViews;
            }
            catch
            {
                return null;
            }
        }
    }
}
