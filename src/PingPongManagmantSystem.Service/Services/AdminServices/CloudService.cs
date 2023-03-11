using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Common;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;

namespace PingPongManagmantSystem.Service.Services.AdminServices
{
    public class CloudService : ICloudService
    {
        AppDbContext appContext = new AppDbContext();
        ITableStatisticService tableStatisticService = new TableStatisticService();
        public async Task<string> GetAllBarAsync(string from)
        {
            try
            {
                var resultBarStatistic = await appContext.BarStatistics.Where(x => x.DateTime.Contains(from)).
                    OrderBy(x => x.DateTime).AsNoTracking().ToListAsync();

                if (resultBarStatistic is null)
                {
                    return "";
                }
                else
                {
                    string jsonData = $"Sotuvlar soni\t\t\tSumma\t\t\tSana\n\n";

                    foreach (var item in resultBarStatistic)
                    {
                        jsonData += $"\t{item.NumberOfSaleBar}\t\t\t\t\t{item.BarSum}\t\t\t{item.DateTime}\n";
                    }

                    CreateJsonFile.CreateAsync(jsonData);
                    return "bar";
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        public async Task<string> GetAllEmpolyeeAsync(string from)
        {
            try
            {
                var resultEmpolyeeStatistic = await appContext.EmpolyeeStatistics.
                    Where(x => x.DateTime.Contains(from)).OrderBy(x => x.DateTime).AsNoTracking().ToListAsync();

                if (resultEmpolyeeStatistic is null)
                {
                    return "";
                }
                else
                {
                    string jsonData = $"Ism\t\t\tBar\t\t\tSport\t\t\tStol\t\t\tKarta\t\t\tKarta vaqt\n\n";

                    foreach (var item in resultEmpolyeeStatistic)
                    {
                        var query = (from name in appContext.Users.Where(x => x.Id == item.UserId)
                                     select name.Name).ToList();

                        jsonData += $"{query[0]}\t\t\t{item.BarSum}\t\t\t{item.SportSum}\t\t\t" +
                            $"{item.TableSum}\t\t\t{item.ViCardToSell}\t\t\t{item.VipCardSum}\t\t\t{item.DateTime}\n";
                    }
                    CreateJsonFile.CreateAsync(jsonData);
                    return "bar";
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        public async Task<string> GetAllSportAsync(string from)
        {
            try
            {

                var resultSportStatistic = await appContext.SportStatistics.Where(x => x.DateTime.Contains(from)).
                    OrderBy(x => x.DateTime).AsNoTracking().ToListAsync();

                if (resultSportStatistic is null)
                {
                    return "";
                }
                else
                {
                    string jsonData = $"Sotuvlar soni\t\t\tSumma\t\t\tSana\n\n";

                    foreach (var item in resultSportStatistic)
                    {
                        jsonData += $"\t{item.NumberOfSaleSport}\t\t\t\t\t{item.SportSum}\t\t\t{item.DateTime}\n";
                    }

                    CreateJsonFile.CreateAsync(jsonData);
                    return "sport";
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        public async Task<string> GetAllTableAsync(string from)
        {
            try
            {
                var resultTable = await tableStatisticService.GetAllAsync(from, new PaginationParams(1, 31));

                if (resultTable is null)
                {
                    return "";
                }
                else
                {
                    string jsonData = $"Bar\t\t\tSport\t\t\tStol\t\t\tKarta Sotuv\t\t\tKarta vaqt\t\t\tNaxt\t\t\tKarta\t\t\tJami\n\n";

                    foreach (var item in resultTable)
                    {
                        jsonData += $"{item.BarSum}\t\t\t\t{item.SportSum}\t\t\t\t" +
                            $"{item.TableSum}\t\t\t\t{item.ViCardToSell}\t\t\t\t{item.CardTime}\t\t\t\t" +
                            $"{item.Cash}\t\t\t\t{item.Card}\t\t\t\t{item.TotalSum}\t\t\t\t{item.DateTime}\n";
                    }

                    CreateJsonFile.CreateAsync(jsonData);
                    return "table";
                }

                return "";
            }
            catch
            {
                return "";
            }
        }
    }
}
