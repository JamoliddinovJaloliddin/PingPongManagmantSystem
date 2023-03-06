using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Enums;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.ViewModels.StatisticViews;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class TableStatisticService : ITableStatisticService
    {
        AppDbContext appDbContext = new AppDbContext();
        IEmpolyeeStatsiticService empolyeeStatsiticService = new EmpolyeeStatisticService();

        public async Task<bool> CreateAsync()
        {
            try
            {
                string day = DayHelper.GetCurrentServerDay();

                var dayResult = await appDbContext.TableStatistics.FirstOrDefaultAsync(x => x.DateTime == day);

                if (dayResult is null)
                {
                    TableStatistic tableStatistic = new TableStatistic();
                    tableStatistic.TableSum = 0;
                    tableStatistic.DateTime = day;
                    tableStatistic.VipCard = 0;
                    tableStatistic.Card = 0;
                    tableStatistic.Card = 0;

                    appDbContext.TableStatistics.Add(tableStatistic);

                    var result = await appDbContext.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<TableStatisticView>> GetAllAsync(string search, PaginationParams @params)
        {
            try
            {
                IList<TableStatisticView> tableStatisticViews = new List<TableStatisticView>();

                if (search == "")
                {
                    var tableStatistics = from statics in appDbContext.TableStatistics.OrderBy(x => x.DateTime)
                                          select statics;
                    var tableStatistic = await PagedList<TableStatistic>.ToPageListAsync(tableStatistics, @params);


                    if (tableStatistic is not null)
                    {
                        foreach (var item in tableStatistic)
                        {
                            TableStatisticView tableStatisticView = new TableStatisticView();
                            tableStatisticView.DateTime = item.DateTime;
                            tableStatisticView.TotalSum += item.TableSum;
                            tableStatisticView.TableSum += item.TableSum;
                            tableStatisticView.CardTime += item.VipCard;
                            tableStatisticView.Card = item.Card;
                            tableStatisticView.Cash = item.Cash;

                            var barStatistic = await appDbContext.BarStatistics.FirstOrDefaultAsync(x => x.DateTime == item.DateTime);
                            if (barStatistic is not null)
                            {
                                tableStatisticView.TotalSum += barStatistic.BarSum;
                                tableStatisticView.BarSum += barStatistic.BarSum;
                                tableStatisticView.Card = barStatistic.Card;
                                tableStatisticView.Cash = barStatistic.Cash;
                            }
                            var sportStatistic = await appDbContext.SportStatistics.FirstOrDefaultAsync(x => x.DateTime == item.DateTime);
                            if (sportStatistic is not null)
                            {
                                tableStatisticView.TotalSum += sportStatistic.SportSum;
                                tableStatisticView.SportSum += sportStatistic.SportSum;
                                tableStatisticView.Card = sportStatistic.Card;
                                tableStatisticView.Cash = sportStatistic.Cash;
                            }
                            var cardStatistic = await appDbContext.Cards.FirstOrDefaultAsync(x => x.DateTime == item.DateTime);
                            if (cardStatistic is not null)
                            {
                                tableStatisticView.TotalSum += cardStatistic.Price;
                                tableStatisticView.ViCardToSell += cardStatistic.Price;
                            }
                            tableStatisticViews.Add(tableStatisticView);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    var tableStatistics = from statiscs in
                            appDbContext.TableStatistics.Where(x => x.DateTime.ToLower().Contains(search)).OrderBy(x => x.DateTime)
                                          select statiscs;

                    var tableStatistic = await PagedList<TableStatistic>.ToPageListAsync(tableStatistics, @params);

                    if (tableStatistic is not null)
                    {
                        foreach (var item in tableStatistic)
                        {
                            TableStatisticView tableStatisticView = new TableStatisticView();
                            tableStatisticView.DateTime = item.DateTime;
                            tableStatisticView.TotalSum += item.TableSum;
                            tableStatisticView.TableSum += item.TableSum;
                            tableStatisticView.CardTime += item.VipCard;
                            tableStatisticView.Card = item.Card;
                            tableStatisticView.Cash = item.Cash;

                            var barStatistic = await appDbContext.BarStatistics.FirstOrDefaultAsync(x => x.DateTime == item.DateTime);
                            if (barStatistic is not null)
                            {
                                tableStatisticView.TotalSum += barStatistic.BarSum;
                                tableStatisticView.BarSum += barStatistic.BarSum;
                                tableStatisticView.Card = barStatistic.Card;
                                tableStatisticView.Cash = barStatistic.Cash;
                            }
                            var sportStatistic = await appDbContext.SportStatistics.FirstOrDefaultAsync(x => x.DateTime == item.DateTime);
                            if (sportStatistic is not null)
                            {
                                tableStatisticView.TotalSum += sportStatistic.SportSum;
                                tableStatisticView.SportSum += sportStatistic.SportSum;
                                tableStatisticView.Card = sportStatistic.Card;
                                tableStatisticView.Cash = sportStatistic.Cash;
                            }
                            var cardStatistic = await appDbContext.Cards.FirstOrDefaultAsync(x => x.DateTime == item.DateTime);
                            if (cardStatistic is not null)
                            {
                                tableStatisticView.TotalSum += cardStatistic.Price;
                                tableStatisticView.ViCardToSell += cardStatistic.Price;
                            }
                            tableStatisticViews.Add(tableStatisticView);
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                return tableStatisticViews;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(double totalPrice, string paymentType)
        {
            try
            {
                var dateDay = DayHelper.GetCurrentServerDay();
                var tableCount = await appDbContext.TableStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);

                if (tableCount is null)
                {
                    TableStatistic tableStatistic = new TableStatistic();
                    tableStatistic.DateTime = dateDay;

                    if (paymentType == "Naxt")
                    {
                        tableStatistic.Cash = totalPrice;
                    }
                    else if (paymentType == "Karta")
                    {
                        tableStatistic.Card = totalPrice;
                    }
                    else if (paymentType == Payment.VipKarta.ToString())
                    {
                        tableStatistic.VipCard = totalPrice;
                    }
                    appDbContext.TableStatistics.Add(tableStatistic);
                }
                else
                {
                    var tableStatic = await appDbContext.TableStatistics.FirstOrDefaultAsync(x => x.DateTime == dateDay);
                    appDbContext.Entry(tableStatic).State = EntityState.Detached;
                    if (paymentType == "Naxt")
                    {
                        tableStatic.Cash += totalPrice;
                    }
                    else if (paymentType == "Karta")
                    {
                        tableStatic.Card += totalPrice;
                    }
                    else if (paymentType == Payment.VipKarta.ToString())
                    {
                        tableStatic.VipCard += totalPrice;
                    }
                    appDbContext.TableStatistics.Update(tableStatic);
                }

                var result = await appDbContext.SaveChangesAsync();
                if (result > 0)
                {
                    var empolyeeStatistic = await empolyeeStatsiticService.CreateTableAsync(totalPrice, paymentType);
                    return empolyeeStatistic;
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
