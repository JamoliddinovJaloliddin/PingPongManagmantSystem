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
        AppDbContext appDbContext = new AppDbContext();
        ICustomerService customerService = new CustomerService();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        IPingPongTableService pingPongTableService = new PingPongTableService();
        ITimeService timeService = new TimeService();
        ICardService cardService = new CardService();

        public async Task<(bool Resault, string Text, DesktopCassa cassa)> TotalPrice(int tableNumbe, string customer)
        {
            try
            {
                var customerPercent = await customerService.GetByIdAsync(customer);
                var TimeStop = TimeHelper.GetCurrentServerTimeParseFloat();
                var timeCheapOrExpencive = await timeService.GetAll();
                var pingPongTable = await desktopCassaService.GetByIdAsync(tableNumbe);
                var pingPongTablePrice = (PingPongTable)await pingPongTableService.GetByIdAsync(pingPongTable.StolNumber);

                var secondExpenciveFrom = (timeCheapOrExpencive.TimeExpensiveFrom * 3600 / 100);
                var secondExpenciveUpTo = (timeCheapOrExpencive.TimeExpensiveUpTo * 3600 / 100);
                var secondCheapFrom = (timeCheapOrExpencive.TimeCheapFrom * 3600 / 100);
                var secondCheapUpTo = (timeCheapOrExpencive.TimeCheapUpTo * 3600 / 100);

                string accountBook = "";
                double totalSum = 0;

                if (customerPercent.Status != "VipKarta" && customer != Payment.Trener_Kattalar.ToString() || customer != Payment.Trener_Kichik.ToString())
                {
                    if (TimeStop > secondCheapFrom && secondCheapUpTo > TimeStop && pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime == 0)
                    {
                        totalSum = (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100) * (pingPongTable.TimeAccount / 3600) + pingPongTable.BarSum + pingPongTable.TransferSum;
                        pingPongTable.TimeAccount = pingPongTable.TimeAccount / 3600;
                        var time = pingPongTable.TimeAccount / 60;
                        if (time > 60)
                        {
                            time = time * 60 / 3600;
                        }
                        pingPongTable.TransferSum = totalSum;
                        accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                    }

                    else if (TimeStop > secondCheapFrom && secondCheapUpTo > TimeStop && pingPongTable.TimeAccount == 0 && pingPongTable.PlayTime > 0)
                    {
                        var secondCheap = (((TimeStop - pingPongTable.PlayTime) / 3600) * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100));
                        totalSum = secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                        var time = (TimeStop - pingPongTable.PlayTime) / 60;
                        if (time > 60)
                        {
                            time = time * 60 / 3600;
                        }
                        pingPongTable.TransferSum += totalSum;
                        accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                    }

                    else if (TimeStop > secondCheapFrom && secondCheapUpTo > TimeStop && pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime > 0)
                    {
                        var secondCheap = (((TimeStop - pingPongTable.PlayTime) / 3600) * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100));
                        totalSum = secondCheap + pingPongTable.BarSum;
                        totalSum = (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100) * (pingPongTable.TimeAccount / 3600) + pingPongTable.TransferSum;
                        var time = (TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount) / 60;
                        if (time > 60)
                        {
                            time = time * 60 / 3600;
                        }
                        pingPongTable.TransferSum = totalSum;
                        accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                    }


                    if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime == 0 && secondExpenciveFrom <= TimeStop && TimeStop <= 86400 ||
                        pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime == 0 && TimeStop <= 0 && TimeStop < secondExpenciveUpTo)
                    {
                        totalSum = (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100) * (pingPongTable.TimeAccount / 3600)
                            + pingPongTable.BarSum + pingPongTable.TransferSum;
                        pingPongTable.TimeAccount = pingPongTable.TimeAccount / 3600;
                        var time = pingPongTable.TimeAccount / 60;
                        if (time > 60)
                        {
                            time = time * 60 / 3600;
                        }
                        pingPongTable.TransferSum = totalSum;
                        accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                    }

                    else if (pingPongTable.TimeAccount == 0 && pingPongTable.PlayTime > 0 && secondExpenciveFrom <= TimeStop && TimeStop <= 86400 ||
                        pingPongTable.TimeAccount == 0 && pingPongTable.PlayTime > 0 && TimeStop <= 0 && TimeStop <= secondExpenciveUpTo)
                    {
                        var secondCheap = (((TimeStop - pingPongTable.PlayTime) / 3600) * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100));
                        totalSum = secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                        var time = (TimeStop - pingPongTable.PlayTime) / 60;
                        if (time > 60)
                        {
                            time = time * 60 / 3600;
                        }
                        pingPongTable.TransferSum = totalSum;
                        accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                    }
                    else if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime > 0 && secondExpenciveFrom <= TimeStop && TimeStop <= 86400 ||
                        pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime > 0 && TimeStop <= 0 && TimeStop <= secondExpenciveUpTo)
                    {
                        var secondCheap = (((TimeStop - pingPongTable.PlayTime) / 3600) * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100));
                        totalSum = secondCheap + pingPongTable.BarSum;
                        totalSum = (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100) * (pingPongTable.TimeAccount / 3600) + pingPongTable.TransferSum;
                        var time = (TimeStop - pingPongTable.PlayTime) / 60;
                        if (time > 60)
                        {
                            time = time * 60 / 3600;
                        }
                        pingPongTable.TransferSum = totalSum;
                        accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                    }
                }

                else if (customerPercent.Status == Payment.Trener_Kattalar.ToString())
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    var time = (TimeStop - pingPongTable.PlayTime) / 60;
                    if (time > 60)
                    {
                        time = time * 60 / 3600;
                    }
                    accountBook += $"Vaqt: {pingPongTable.TimeAccount} \n Summa: {totalSum} so'm";
                }
                else if (customerPercent.Status == Payment.Trener_Kichik.ToString())
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    pingPongTable.TimeAccount = TimeStop - pingPongTable.PlayTime / 3600;
                    accountBook += $"Vaqt: {pingPongTable.TimeAccount} \n Summa: {totalSum} so'm";
                }
                else if (customerPercent.Status == Payment.VipKarta.ToString())
                {
                    var vipKart = (Card)await cardService.GetByIdAsync(customer);
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
                            accountBook += $"Vaqt: {pingPongTable.TimeAccount} \n Summa: {totalSum} so'm";
                        }
                        else
                        {
                            var second = TimeStop - secondExpenciveFrom + pingPongTable.TimeAccount;
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
                            accountBook += $"Vaqt: {pingPongTable.TimeAccount} \n Summa: {totalSum} so'm";
                        }

                    }
                    else
                    {
                        return (Resault: false, Text: "Bu karta raqami mavjum emas", cassa: null);
                    }

                }
                return (Resault: true, Text: accountBook, cassa: pingPongTable);
            }
            catch
            {
                return (Resault: false, Text: "", cassa: null);
            }
        }

        public async Task<bool> TransferCreateAsync(int id, DesktopCassa cassa)
        {
            try
            {
                var resaultId = await desktopCassaService.GetByIdAsync(id);
                resaultId.Id = id;
                resaultId.Play = false;
                resaultId.Pause = true;
                resaultId.Stop = true;
                resaultId.Label = false;
                resaultId.Transfer = true;
                resaultId.Bar = true;
                resaultId.Calc = true;
                resaultId.AccountBook = cassa.AccountBook;
                resaultId.BarSum = cassa.BarSum;
                resaultId.TransferSum = cassa.TransferSum;
                resaultId.TimeAccount = 0;
                resaultId.UserId = cassa.UserId;
                resaultId.PlayTime = TimeHelper.GetCurrentServerTimeParseFloat();
                appDbContext.DesktopCassas.Update(resaultId);
                var resa = await appDbContext.SaveChangesAsync();


                cassa.Id = cassa.Id;
                cassa.Play = true;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Transfer = false;
                cassa.Bar = false;
                cassa.Calc = false;
                cassa.Label = true;
                cassa.BarSum = 0;
                cassa.AccountBook = "";
                cassa.PlayTime = 0;
                cassa.TimeAccount = 0;
                cassa.UserId = 0;
                cassa.TransferSum = 0;

                appDbContext.DesktopCassas.Update(cassa);
                var res = await appDbContext.SaveChangesAsync();
                return resa > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
