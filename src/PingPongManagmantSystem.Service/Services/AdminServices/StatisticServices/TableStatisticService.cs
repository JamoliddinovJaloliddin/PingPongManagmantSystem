using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Enums;
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
        public Task<List<TableStatisticView>> GetAllAsync()
        {
            throw new NotImplementedException();
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
