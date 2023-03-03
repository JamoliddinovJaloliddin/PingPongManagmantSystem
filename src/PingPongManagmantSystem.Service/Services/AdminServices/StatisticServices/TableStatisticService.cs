using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;

namespace PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices
{
    public class TableStatisticService : ITableStatisticService
    {
        //AppDbContext appDbContext = new AppDbContext();
        //ITrackingDetech trackingDetech = new TrackingDetech();

        //public async Task<bool> CreateAsync(double tablePrice)
        //{
        //    try
        //    {
        //        var dateString = DayHelper.GetCurrentServerDay();
        //        var dateResault = await appDbContext.Statistics.FirstOrDefaultAsync(x => x.DateTime == dateString);
        //        if (dateResault is null)
        //        {
        //            Statistic statistic = new Statistic();
        //            statistic.DateTime = dateString;
        //            statistic.UserId = 1;
        //            appDbContext.Statistics.Add(statistic);
        //        }
        //        var result = await appDbContext.SaveChangesAsync();
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public Task<bool> CreateAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IList<TableStatisticView>> GetAllAsyncStatistic(string search)
        //{
        //    try
        //    {
        //        IList<TableStatisticView> tableStatisticViews = new List<TableStatisticView>();
        //        if (search == "")
        //        {

        //        }
        //        else
        //        {

        //        }
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public async Task<bool> UpdateBarAsync(Dictionary<string, int> keyValuePairs)
        //{
        //    try
        //    {
        //        var dateTime = DayHelper.GetCurrentServerDay();
        //        var resultStatistic = await appDbContext.Statistics.FirstOrDefaultAsync(x => x.DateTime == dateTime);

        //        foreach (var product in keyValuePairs)
        //        {
        //            if (resultStatistic is not null)
        //            {
        //                var barProduct = await appDbContext.BarProducts.FirstOrDefaultAsync(x => x.Name == product.Key);
        //                if (barProduct is not null)
        //                {
        //                    trackingDetech.TrackingDeteched(resultStatistic);
        //                    resultStatistic.NumberOfSaleBar += product.Value;
        //                    resultStatistic.BarSum += product.Value * barProduct.SalePrice;
        //                    resultStatistic.TotalSum += resultStatistic.BarSum;
        //                    appDbContext.Statistics.Update(resultStatistic);
        //                    await appDbContext.SaveChangesAsync();
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> UpdateProductAsync(Dictionary<string, int> keyValuePairs)
        //{
        //    try
        //    {
        //        var dateTime = DayHelper.GetCurrentServerDay();
        //        var resultStatistic = await appDbContext.Statistics.FirstOrDefaultAsync(x => x.DateTime == dateTime);

        //        foreach (var product in keyValuePairs)
        //        {
        //            if (resultStatistic is not null)
        //            {
        //                var sportProduct = await appDbContext.SportProducts.FirstOrDefaultAsync(x => x.Name == product.Key);
        //                if (sportProduct is not null)
        //                {
        //                    trackingDetech.TrackingDeteched(resultStatistic);
        //                    resultStatistic.NumberOfSaleSport += product.Value;
        //                    resultStatistic.SportSum += product.Value * sportProduct.SalePrice;
        //                    resultStatistic.TotalSum += resultStatistic.SportSum;
        //                    appDbContext.Statistics.Update(resultStatistic);
        //                    await appDbContext.SaveChangesAsync();
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> UpdateTableAsync(double totalPrice)
        //{
        //    try
        //    {
        //        var dateString = DayHelper.GetCurrentServerDay();
        //        var dateResult = await appDbContext.Statistics.FirstOrDefaultAsync(x => x.DateTime == dateString);

        //        if (dateResult is not null)
        //        {
        //            trackingDetech.TrackingDeteched(dateResult);
        //            dateResult.TableSum += totalPrice;
        //            appDbContext.Update(dateResult);
        //            var result = await appDbContext.SaveChangesAsync();
        //            return result > 0;
        //        }
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

    }
}
