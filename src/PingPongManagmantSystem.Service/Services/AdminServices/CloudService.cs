using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Service.Common;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;

namespace PingPongManagmantSystem.Service.Services.AdminServices
{
    public class CloudService : ICloudService
    {
        AppDbContext appContext = new AppDbContext();
        public async Task<string> GetAllBarAsync(string from)
        {
            try
            {

                var resultBarStatistic = await appContext.BarStatistics.Where(x => x.DateTime.Contains(from)).
                    AsNoTracking().ToListAsync();

                if (resultBarStatistic == null)
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
            throw new NotImplementedException();
        }

        public async Task<string> GetAllSportAsync(string from)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetAllTableAsync(string from)
        {
            throw new NotImplementedException();
        }
    }
}
