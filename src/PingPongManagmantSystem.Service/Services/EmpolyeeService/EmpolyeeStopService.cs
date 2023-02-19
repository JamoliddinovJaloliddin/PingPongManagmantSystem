using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Enums;
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
        IPingPongTableService pingPongTableService = new PingPongTableService();
        ITimeService timeService = new TimeService();   
        ICardService cardService = new CardService();   

        public async Task<(bool Resault, string Text)> TotalPrice(byte tableNumbe, string customer)
        {
            try
            {
                var customerPercent =  await customerService.GetByIdAsync(customer);
                var TimeStop = TimeHelper.GetCurrentServerTimeParseFloat();
                var timeCheapOrExpencive = await timeService.GetAll();
                var pingPongTable = await desktopCassaService.GetByIdAsync(tableNumbe);
                var pingPongTablePrice = (PingPongTable)await pingPongTableService.GetByIdAsync(pingPongTable.StolNumber);
                var secondExpencive = (timeCheapOrExpencive.TimeExpensiveFrom * 3600 / 100);

                double totalSum = 0;

                if (customerPercent.Status != "VipKarta" && customer != Payment.Trener_Kattalar.ToString() || customer != Payment.Trener_Kichik.ToString())
                {
                    if (pingPongTable.PlayTime > timeCheapOrExpencive.TimeCheapFrom / 100
                        && timeCheapOrExpencive.TimeCheapUpTo / 100 < TimeStop && pingPongTable.TimeAccount > 0)
                    {
                        var second = TimeStop - pingPongTable.PlayTime;
                        second += pingPongTable.TimeAccount;
                        totalSum = (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100) * (second / 3600) + pingPongTable.BarSum;
                        pingPongTable.TimeAccount += TimeStop - pingPongTable.PlayTime / 3600;
                        pingPongTable.AccountBook += $"Vaqt: {pingPongTable.TimeAccount} /n Summa: {totalSum} so'm";
                        return (Resault: true, Text: pingPongTable.AccountBook);
                    }
                    else if (pingPongTable.PlayTime < timeCheapOrExpencive.TimeExpensiveFrom / 100 && TimeStop > timeCheapOrExpencive.TimeExpensiveFrom / 100
                        && pingPongTable.TimeAccount == 0)
                    {
                        var secondCheap = (((secondExpencive - pingPongTable.PlayTime) / 3600) * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100));
                        secondCheap = secondCheap / (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                        var second = (secondCheap + (TimeStop - secondExpencive)) / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                        totalSum = second + pingPongTable.BarSum;
                        pingPongTable.AccountBook += $"Vaqt: {pingPongTable.TimeAccount} /n Summa: {totalSum} so'm";
                        return (Resault: true, Text: pingPongTable.AccountBook);
                    }
                    else if (pingPongTable.PlayTime >= timeCheapOrExpencive.TimeExpensiveFrom)
                    {
                        var second = pingPongTable.TimeAccount + (TimeStop - pingPongTable.PlayTime);
                        pingPongTable.TimeAccount = TimeStop - pingPongTable.PlayTime / 3600;
                        second = (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100) * second / 3600;
                        totalSum = second + pingPongTable.BarSum;
                        pingPongTable.AccountBook += $"Vaqt: {pingPongTable.TimeAccount} /n Summa: {totalSum} so'm";
                        return (Resault: true, Text: pingPongTable.AccountBook);
                    }
                   
                }
                else if (customerPercent.Status == Payment.Trener_Kattalar.ToString())
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    pingPongTable.TimeAccount = TimeStop - pingPongTable.PlayTime / 3600;
                    pingPongTable.AccountBook += $"Vaqt: {pingPongTable.TimeAccount} /n Summa: {totalSum} so'm";
                    return (Resault: true, Text: pingPongTable.AccountBook);
                }
                else if (customerPercent.Status == Payment.Trener_Kichik.ToString())
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    pingPongTable.TimeAccount = TimeStop - pingPongTable.PlayTime / 3600;
                    pingPongTable.AccountBook += $"Vaqt: {pingPongTable.TimeAccount} /n Summa: {totalSum} so'm";
                    return (Resault: true, Text: pingPongTable.AccountBook);
                }
                else if (customerPercent.Status == Payment.VipKarta.ToString())
                {
                    var vipKart = (Card) await cardService.GetByIdAsync(customer);
                    if (vipKart != null)
                    {
                        if (pingPongTable.TimeAccount == 0)
                        {
                            var second = TimeStop - pingPongTable.PlayTime;
                            if (vipKart.TimeLimit * 3600 - second > 0)
                            {
                                vipKart.TimeLimit -= second / 3600;
                            }
                            else
                            { 
                                second -= vipKart.TimeLimit;
                                vipKart.TimeLimit = 0;  
                            }
                            if (vipKart.TimeLimit > 0)
                            {
                                totalSum = pingPongTable.BarSum;
                            }
                            else
                            {
                                totalSum = pingPongTablePrice.PriceCheap * (second / 3600) + pingPongTable.BarSum;
                            }
                            pingPongTable.TimeAccount = TimeStop - pingPongTable.PlayTime;
                            pingPongTable.AccountBook += $"Vaqt: {pingPongTable.TimeAccount} /n Summa: {totalSum} so'm";
                            return (Resault: true, Text: pingPongTable.AccountBook);
                        }
                        else
                        { 
                            var second = TimeStop - secondExpencive + pingPongTable.TimeAccount;
                            if (vipKart.TimeLimit * 3600 - second > 0)
                            {
                                vipKart.TimeLimit -= second / 3600;
                            }
                            else
                            {
                                second -= vipKart.TimeLimit;
                                vipKart.TimeLimit = 0;
                            }
                            if (vipKart.TimeLimit > 0)
                            {
                                totalSum = pingPongTable.BarSum;
                            }
                            else
                            {
                                totalSum = pingPongTablePrice.PriceCheap * (second / 3600) + pingPongTable.BarSum;
                            }
                            pingPongTable.TimeAccount = TimeStop - pingPongTable.PlayTime;
                            pingPongTable.AccountBook += $"Vaqt: {pingPongTable.TimeAccount} /n Summa: {totalSum} so'm";
                             return (Resault: true, Text: pingPongTable.AccountBook);
                        }
                    }
                    else
                    {
                        return (Resault: false, Text: "Bu karta raqami mavjum emas");
                    }
                    pingPongTable.AccountBook += $"Summa: {totalSum} so'm";
                    return (Resault: true, Text: pingPongTable.AccountBook);
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
