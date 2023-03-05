using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Enums;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface.ButtonService;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService.ButtonService
{
    public class EmpolyeeStopService : IEmpolyeeStopService
    {
        AppDbContext appDbContext = new AppDbContext();
        ICustomerService customerService = new CustomerService();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        IPingPongTableService pingPongTableService = new PingPongTableService();
        ITableStatisticService tableStatisticService = new TableStatisticService();
        ITimeService timeService = new TimeService();
        ICardService cardService = new CardService();

        public async Task<(bool Resault, string Text, DesktopCassa cassa, double totalSum)> TotalPrice(int tableNumbe, string customer, string typeOfPey)
        {
            try
            {
                var customerPercent = await customerService.GetByIdAsync(customer);
                var TimeStop = TimeHelper.GetCurrentServerTimeParseFloat();
                var timeCheapOrExpencive = await timeService.GetAll();
                var pingPongTable = await desktopCassaService.GetByIdAsync(tableNumbe);
                var pingPongTablePrice = await pingPongTableService.GetByIdAsync(pingPongTable.StolNumber);

                var secondExpenciveFrom = timeCheapOrExpencive.TimeExpensiveFrom * 3600 / 100;
                var secondExpenciveUpTo = timeCheapOrExpencive.TimeExpensiveUpTo * 3600 / 100;
                var secondCheapFrom = timeCheapOrExpencive.TimeCheapFrom * 3600 / 100;
                var secondCheapUpTo = timeCheapOrExpencive.TimeCheapUpTo * 3600 / 100;

                string accountBook = "";
                double totalSum = 0;
                double tablePrice = 0;

           
                //NotVipKart, NotTrener
                if (customerPercent.Status != "VipKarta" && customer != Payment.Trener_Kattalar.ToString() || customer != Payment.Trener_Kichik.ToString())
                {



                    //secondCheap and secondExpencive
                    if (TimeStop > secondExpenciveFrom && pingPongTable.PlayTime < secondCheapUpTo &&
                        pingPongTable.TimeAccount == 0 && pingPongTable.PlayTime > 0)
                    {
                        var secondCheapExpencive = (secondCheapUpTo - pingPongTable.PlayTime) / 3600 *
                            (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100);
                        secondCheapExpencive += (TimeStop - secondExpenciveFrom) / 3600 *
                            (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                        tablePrice += secondCheapExpencive;

                        totalSum += secondExpenciveFrom + pingPongTable.BarSum + pingPongTable.TransferSum;
                        var time = (TimeStop - pingPongTable.PlayTime) / 60;
                        if (time >= 60)
                        {
                            time = time * 600 / 3600;
                            accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                        }
                        else
                        {
                            accountBook += $"Vaqt: {time} daqiqa \n Summa: {totalSum} so'm";
                        }
                        var tableResult = await tableStatisticService.UpdateAsync(secondCheapExpencive, typeOfPey);
                    }



                    //secondCheap
                    else if (TimeStop <= secondCheapUpTo)
                    {
                        if (pingPongTable.TimeAccount == 0)
                        {
                            var secondCheap = (TimeStop - pingPongTable.PlayTime) / 3600 * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100);
                            tablePrice += secondCheap;

                            totalSum = secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            var time = (TimeStop - pingPongTable.PlayTime) / 60;
                            if (time >= 60)
                            {
                                time = time * 60 / 3600;
                                accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {time} daqiqa \n Summa: {totalSum} so'm";
                            }
                            var tableResult = await tableStatisticService.UpdateAsync(secondCheap, typeOfPey);
                        }
                        else if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime > 0)
                        {
                            var secondCheap = (TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount) /
                                3600 * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100);
                            tablePrice += secondCheap;

                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            var time = (TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount) / 60;
                            if (time >= 60)
                            {
                                time = time * 60 / 3600;
                                accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                            }
                            accountBook += $"Vaqt: {time} daqiqa \n Summa: {totalSum} so'm";
                            var tableResult = await tableStatisticService.UpdateAsync(secondCheap, typeOfPey);
                        }
                        else if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime == 0)
                        {
                            var secondCheap = pingPongTable.TimeAccount / 3600 * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100);
                            tablePrice += secondCheap;
                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            var time = (TimeStop - pingPongTable.PlayTime) / 60;
                            if (time >= 60)
                            {
                                time = time * 60 / 3600;
                                accountBook += $"Vaqt: {time}  \n Summa: {totalSum} so'm";
                            }
                            accountBook += $"Vaqt: {time} daqiqa\n Summa: {totalSum} so'm";
                            var tableResult = await tableStatisticService.UpdateAsync(secondCheap, typeOfPey);
                        }
                    }



                    //secondExpencive
                    else if (TimeStop >= secondExpenciveFrom && TimeStop <= 86400 || TimeStop >= 0 && TimeStop < secondExpenciveUpTo)
                    {
                        if (pingPongTable.TimeAccount == 0)
                        {
                            var secondExpensive = (TimeStop - pingPongTable.PlayTime) / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            totalSum += secondExpensive + pingPongTable.BarSum + pingPongTable.TransferSum;
                            tablePrice += secondExpensive;
                            var time = (TimeStop - pingPongTable.PlayTime) / 60;
                            if (time >= 60)
                            {
                                time = time * 60 / 3600;
                                accountBook += $"Vaqt: {time}  \n Summa: {totalSum} so'm";
                            }
                            accountBook += $"Vaqt: {time} daqiqa \n Summa: {totalSum} so'm";
                            var tableResult = await tableStatisticService.UpdateAsync(secondExpensive, typeOfPey);
                        }
                        else if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime > 0)
                        {
                            var secondExpensive = (TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount) /
                                3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            totalSum += secondExpensive + pingPongTable.BarSum + pingPongTable.TransferSum;
                            tablePrice += secondExpensive;
                            var time = (TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount) / 60;
                            if (time >= 60)
                            {
                                time = time * 60 / 3600;
                                accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                            }
                            accountBook += $"Vaqt: {time} daqiqa\n Summa: {totalSum} so'm";
                            var tableResult = await tableStatisticService.UpdateAsync(secondExpensive, typeOfPey);
                        }
                        else if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime == 0)
                        {
                            var secondCheap = pingPongTable.TimeAccount / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);

                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            tablePrice += secondCheap;
                            var time = (TimeStop - pingPongTable.PlayTime) / 60;
                            if (time >= 60)
                            {
                                time = time * 60 / 3600; accountBook += $"Vaqt: {time} \n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {time} daqiqa \n Summa: {totalSum} so'm";
                            }
                            var tableResult = await tableStatisticService.UpdateAsync(secondCheap, typeOfPey);
                        }
                    }
                }


                //TrenerBig
                else if (customerPercent.Status == Payment.Trener_Kattalar.ToString())
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    tablePrice += customerPercent.Percent;
                    pingPongTable.TimeAccount += TimeStop - pingPongTable.PlayTime;
                    pingPongTable.TimeAccount = pingPongTable.TimeAccount / 60;
                    if (pingPongTable.TimeAccount >= 60)
                    {
                        pingPongTable.TimeAccount = pingPongTable.TimeAccount * 60 / 3600;
                        accountBook += $"Vaqt: {pingPongTable.TimeAccount} \n Summa: {totalSum} so'm";
                    }
                    else
                    {
                        accountBook += $"Vaqt: {pingPongTable.TimeAccount} daqiqa \n Summa: {totalSum} so'm";
                    }
                    var tableResult = await tableStatisticService.UpdateAsync(customerPercent.Percent, typeOfPey);
                }


                //Trener
                else if (customerPercent.Status == Payment.Trener_Kichik.ToString())
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    tablePrice += customerPercent.Percent;
                    pingPongTable.TimeAccount = (TimeStop - pingPongTable.PlayTime) / 60;
                    if (pingPongTable.TimeAccount >= 60)
                    {
                        pingPongTable.TimeAccount = pingPongTable.TimeAccount / 60;
                        accountBook += $"Vaqt: {pingPongTable.TimeAccount} \n Summa: {totalSum} so'm";
                    }
                    accountBook += $"Vaqt: {pingPongTable.TimeAccount} daqiqa \n Summa: {totalSum} so'm";
                    var tableResult = await tableStatisticService.UpdateAsync(customerPercent.Percent, typeOfPey);
                }


                //VipKart
                else if (customerPercent.Status == Payment.VipKarta.ToString())
                {
                    var vipKart = await cardService.GetByIdAsync(customer);
                    if (vipKart != null)
                    {
                        if (vipKart.TimeLimit > 0)
                        {
                            if (pingPongTable.TimeAccount == 0)
                            {
                                var second = TimeStop - pingPongTable.PlayTime;
                                if (vipKart.TimeLimit * 3600 - second > 0)
                                {
                                    vipKart.TimeLimit = (vipKart.TimeLimit * 3600 - second) / 3600;
                                    var tableResult = await tableStatisticService.UpdateAsync(second, typeOfPey);
                                }
                                else
                                {
                                    second -= vipKart.TimeLimit;
                                    vipKart.TimeLimit = 0;
                                }
                                if (vipKart.TimeLimit > 0)
                                {
                                    totalSum = pingPongTable.BarSum + pingPongTable.TransferSum;
                                }
                                else
                                {
                                    totalSum = pingPongTablePrice.PriceExpensive * (second / 3600) + pingPongTable.BarSum;
                                    var tableResult = await tableStatisticService.UpdateAsync(pingPongTablePrice.PriceExpensive * (second / 3600), "Naxt");
                                }
                                pingPongTable.TimeAccount = (TimeStop - pingPongTable.PlayTime) / 60;
                                if (pingPongTable.TimeAccount >= 60)
                                {
                                    pingPongTable.TimeAccount = pingPongTable.TimeAccount / 60;
                                    accountBook += $"Vaqt: {pingPongTable.TimeAccount} \n Summa: {totalSum} so'm";
                                }
                                accountBook += $"Vaqt: {pingPongTable.TimeAccount} daqiqa \n Summa: {totalSum} so'm";
                            }


                            else if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime > 0)
                            {
                                var second = TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount;
                                if (vipKart.TimeLimit * 3600 - second > 0)
                                {
                                    vipKart.TimeLimit -= second / 3600;
                                    var tableResult = await tableStatisticService.UpdateAsync(second, typeOfPey);
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
                                    totalSum = pingPongTablePrice.PriceExpensive * (second / 3600) + pingPongTable.BarSum;
                                    var tableResult = await tableStatisticService.UpdateAsync(pingPongTablePrice.PriceExpensive * (second / 3600), "Naxt");
                                }
                                pingPongTable.TimeAccount += TimeStop - pingPongTable.PlayTime;
                                if (pingPongTable.TimeAccount / 60 >= 60)
                                {
                                    pingPongTable.TimeAccount /= 3600;
                                    accountBook += $"Vaqt: {second} \n Summa: {totalSum} so'm";
                                }
                                else
                                {
                                    accountBook += $"Vaqt: {second} daqiqa \n Summa: {totalSum} so'm";
                                }
                            }



                            else if (pingPongTable.TimeAccount > 0 && pingPongTable.PlayTime == 0)
                            {
                                var second = pingPongTable.TimeAccount;
                                if (vipKart.TimeLimit * 3600 - second > 0)
                                {
                                    vipKart.TimeLimit -= second / 3600;
                                    var tableResult = await tableStatisticService.UpdateAsync(second, typeOfPey);
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
                                    totalSum = pingPongTablePrice.PriceExpensive * (second / 3600) + pingPongTable.BarSum;
                                    var tableResult = await tableStatisticService.UpdateAsync(pingPongTablePrice.PriceExpensive * (second / 3600), "Naxt");
                                }
                                if (pingPongTable.TimeAccount / 60 >= 60)
                                {
                                    pingPongTable.TimeAccount /= 60;
                                    accountBook += $"Vaqt: {second} \n Summa: {totalSum} so'm";
                                }
                                else
                                {
                                    accountBook += $"Vaqt: {second} daqiqa \n Summa: {totalSum} so'm";
                                }
                            }
                        }
                        else
                        {
                            return (Resault: false, Text: "Bu karta raqami mavjum emas", cassa: null, totalSum);
                        }
                    }
                    else
                    {
                        return (Resault: false, Text: "Hosbingiz 0", cassa: null, totalSum);
                    }
                }

                var userEmpolyee = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == 1);
                if (userEmpolyee is not null)
                {
                    Cassa cassa = new Cassa();
                    cassa.UserName = userEmpolyee.Name;
                    cassa.BarProductPrice = pingPongTable.BarSum;
                    cassa.SportProductPrice += 0;
                    cassa.SumPrice = totalSum.ToString();
                    cassa.TablePrice = totalSum - pingPongTable.BarSum;
                    cassa.Check = accountBook;
                    cassa.TypeOfPrice = typeOfPey;
                    cassa.DateTime = DayHelper.GetCurrentServerDay();

                    appDbContext.Cassas.Add(cassa);
                    var resault = await appDbContext.SaveChangesAsync();
                }

                accountBook = "";
                totalSum = 0;
                tablePrice = 0;

                return (Resault: true, Text: accountBook, cassa: pingPongTable, totalSum: totalSum);
            }
            catch
            {
                return (Resault: false, Text: "", cassa: null, totalSum: 0);
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
