using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminService;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{
    public class EmpolyeeStopService : IEmpolyeeStopService
    {
        private readonly AppDbContext appDbContext;
        ICustomerService customerService = new CustomerService();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();

        public async Task<(bool Resault, string Text)> TotalPrice(byte tableNumbe, string customer)
        {
            try
            {

                var customerPercent = await customerService.GetByIdAsync(customer);
                var TimeStop = TimeHelper.GetCurrentServerTimeParseFloat();
                var timeCheapOrExpencive = (Time) appDbContext.Times.AsNoTracking();
                var pingPongTable = (DesktopCassa) await desktopCassaService.GetByIdAsync(tableNumbe);
                double totalSum = 0;

                if (customerPercent.Status != "VipKarta")
                {
                    if (pingPongTable.PlayTime > timeCheapOrExpencive.TimeCheapFrom
                        && timeCheapOrExpencive.TimeCheapUpTo < TimeStop)
                    {
                        if (TimeStop == 0)
                        {

                        }
                        else
                        { 
                        
                        }
                    }
                    else
                    { 
                        
                    }
                }
                else
                { 
                
                }
                


                return (Resault: false, Text: "");
            }
            catch
            {
                return (Resault: false, Text: "");
            }
        }
    }
}
