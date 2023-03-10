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
using PingPongManagmantSystem.Service.ViewModels;

#pragma warning disable

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
                double time = 0;
                double transferTime = 0;
                int check = 0;

                //NotVipKart, NotTrener
                if (typeOfPey != "VipKarta" && customer != "TrenerKatta" && customer != "TrenerKichik")
                {
                    if (pingPongTable.PlayTime == 0)
                    {
                        if (TimeStop > secondCheapFrom && TimeStop <= secondCheapUpTo)
                        {
                            transferTime = pingPongTable.TimeAccount;
                            var secondCheap = transferTime / 3600 * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100);
                            tablePrice += Math.Floor(secondCheap);
                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;
                            if (time >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {(Math.Floor(time / 60))} \n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheap), typeOfPey);
                        }

                        else if (TimeStop > secondExpenciveFrom && TimeStop <= 86400)
                        {
                            transferTime = pingPongTable.TimeAccount;
                            var secondCheap = transferTime / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            tablePrice += Math.Floor(secondCheap);
                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;
                            if (time >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {(Math.Floor(time / 60))} daqiqa\n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheap), typeOfPey);
                        }

                        else if (TimeStop < 14400)
                        {
                            transferTime = pingPongTable.TimeAccount;
                            var secondCheap = transferTime / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            tablePrice += Math.Floor(secondCheap);
                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;
                            if (transferTime + pingPongTable.TransferTime >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {(Math.Floor(time / 60))} daqiqa\n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheap), typeOfPey);
                        }


                    }
                    else if (pingPongTable.PlayTime > 0)
                    {
                        if (TimeStop > secondExpenciveFrom && pingPongTable.PlayTime < secondCheapUpTo)
                        {
                            transferTime = pingPongTable.TimeAccount + TimeStop - pingPongTable.PlayTime;
                            var secondCheapExpencive = (secondCheapUpTo - pingPongTable.PlayTime) / 3600 *
                                (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100);
                            secondCheapExpencive += (TimeStop - secondExpenciveFrom) / 3600 *
                                (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            tablePrice += Math.Floor(secondCheapExpencive);
                            totalSum += tablePrice + pingPongTable.BarSum + pingPongTable.TransferSum;
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;
                            if (time >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat  \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {Math.Floor(time / 60)} daqiqa \n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheapExpencive), typeOfPey);
                        }

                        else if (TimeStop > secondCheapFrom && TimeStop <= secondCheapUpTo &&
                            pingPongTable.PlayTime >= secondCheapFrom && pingPongTable.PlayTime < secondCheapUpTo)
                        {
                            transferTime = TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount;
                            var secondCheap = transferTime / 3600 * (pingPongTablePrice.PriceCheap * customerPercent.Percent / 100);
                            tablePrice += Math.Floor(secondCheap);
                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;
                            if (time >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {Math.Floor(time / 60)} daqiqa   \n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheap), typeOfPey);
                        }

                        else if (TimeStop > secondExpenciveFrom && TimeStop <= 86400 &&
                            pingPongTable.PlayTime > secondExpenciveFrom && pingPongTable.PlayTime < 86400)
                        {
                            transferTime = pingPongTable.TimeAccount + TimeStop - pingPongTable.PlayTime;

                            var secondExpensive = transferTime / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            totalSum += secondExpensive + pingPongTable.BarSum + pingPongTable.TransferSum;
                            tablePrice += Math.Floor(secondExpensive);
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;
                            if (time >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                time = Math.Floor(time / 60);
                                accountBook += $"Vaqt: {time} daqiqa  \n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondExpensive), typeOfPey);
                        }

                        else if (TimeStop < 14400 && pingPongTable.PlayTime <= 16400)
                        {
                            transferTime = pingPongTable.TimeAccount + (TimeStop - pingPongTable.PlayTime);
                            var secondCheap = transferTime / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            tablePrice += Math.Floor(secondCheap);
                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;
                            if (time >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {(Math.Floor(time / 60))} daqiqa\n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheap), typeOfPey);
                        }

                        else if (pingPongTable.PlayTime <= 86400 && TimeStop <= 16400 && pingPongTable.PlayTime > secondExpenciveFrom)
                        {
                            transferTime = (86400 - pingPongTable.PlayTime) + TimeStop;
                            var secondCheap = transferTime / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                            tablePrice += Math.Floor(secondCheap);
                            totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                            totalSum = Math.Floor(totalSum);
                            time = transferTime + pingPongTable.TransferTime;

                            if (time >= 3600)
                            {
                                time = Math.Round(time / 3600, 2);
                                string resultTime = (time.ToString().Split(".")[0]);
                                double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                                resultMinut = Math.Floor(36 * resultMinut / 60);
                                accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                            }
                            else
                            {
                                accountBook += $"Vaqt: {(Math.Floor(time / 60))} daqiqa\n\n Summa: {totalSum} so'm";
                            }
                            check = 1;
                            var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheap), typeOfPey);
                        }
                        //else if (pingPongTable.PlayTime <= 86400 && TimeStop <= 16400 && pingPongTable.PlayTime < secondExpenciveFrom)
                        //{
                        //    transferTime = (86400 - pingPongTable.PlayTime) + TimeStop;
                        //    var secondCheap = transferTime / 3600 * (pingPongTablePrice.PriceExpensive * customerPercent.Percent / 100);
                        //    tablePrice += Math.Floor(secondCheap);
                        //    totalSum += secondCheap + pingPongTable.BarSum + pingPongTable.TransferSum;
                        //    totalSum = Math.Floor(totalSum);
                        //    time = transferTime + pingPongTable.TransferTime;

                        //    if (time >= 3600)
                        //    {
                        //        time = Math.Round(time / 3600, 2);
                        //        string resultTime = (time.ToString().Split(".")[0]);
                        //        double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                        //        resultMinut = Math.Floor(36 * resultMinut / 60);
                        //        accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                        //    }
                        //    else
                        //    {
                        //        accountBook += $"Vaqt: {(Math.Floor(time / 60))} daqiqa\n\n Summa: {totalSum} so'm";
                        //    }
                        //    check = 1;
                        //    var tableResult = await tableStatisticService.UpdateAsync(Math.Floor(secondCheap), typeOfPey);
                        //}
                    }
                }


                //TrenerBig
                else if (customer == "TrenerKatta")
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    tablePrice = Math.Floor(customerPercent.Percent);
                    totalSum = Math.Floor(totalSum);
                    if (pingPongTable.PlayTime == 0)
                    {
                        time = pingPongTable.TimeAccount;
                        if (time >= 3600)
                        {
                            time = Math.Round(time / 3600, 2);
                            string resultTime = (time.ToString().Split(".")[0]);
                            double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                            resultMinut = Math.Floor(36 * resultMinut / 60);
                            accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                        }
                        else
                        {
                            accountBook += $"Vaqt: {Math.Floor(time / 60)} daqiqa \n Summa: {totalSum} so'm";
                        }
                    }
                    else
                    {
                        time = TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount;
                        if (time >= 3600)
                        {
                            time = Math.Round(time / 3600, 2);
                            string resultTime = (time.ToString().Split(".")[0]);
                            double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                            resultMinut = Math.Floor(36 * resultMinut / 60);
                            accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                        }
                        else
                        {
                            accountBook += $"Vaqt: {Math.Floor(time / 60)} daqiqa \n Summa: {totalSum} so'm";
                        }
                    }
                    check = 1;
                    var tableResult = await tableStatisticService.UpdateAsync(tablePrice, typeOfPey);
                }


                //Trener
                else if (customer == "TrenerKichik")
                {
                    totalSum = customerPercent.Percent + pingPongTable.BarSum;
                    tablePrice = Math.Floor(customerPercent.Percent);
                    totalSum = Math.Floor(totalSum);
                    if (pingPongTable.PlayTime == 0)
                    {
                        time = pingPongTable.TimeAccount;
                        if (time >= 3600)
                        {
                            time = Math.Round(time / 3600, 2);
                            string resultTime = (time.ToString().Split(".")[0]);
                            double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                            resultMinut = Math.Floor(36 * resultMinut / 60);
                            accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                        }
                        else
                        {
                            accountBook += $"Vaqt: {Math.Floor(time / 60)} daqiqa \n Summa: {totalSum} so'm";
                        }
                    }
                    else
                    {
                        time = TimeStop - pingPongTable.PlayTime + pingPongTable.TimeAccount;
                        if (time >= 3600)
                        {
                            time = Math.Round(time / 3600, 2);
                            string resultTime = (time.ToString().Split(".")[0]);
                            double resultMinut = double.Parse(time.ToString().Split(".")[1]);
                            resultMinut = Math.Floor(36 * resultMinut / 60);
                            accountBook += $"Vaqt: {resultTime}.{resultMinut} soat \n\n Summa: {totalSum} so'm";
                        }
                        else
                        {
                            accountBook += $"Vaqt: {Math.Floor(time / 60)} daqiqa \n Summa: {totalSum} so'm";
                        }
                    }
                    check = 1;
                    var tableResult = await tableStatisticService.UpdateAsync(tablePrice, typeOfPey);
                }


                //VipKart
                else if (customer == Payment.VipKarta.ToString())
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
                                    vipKart.TimeLimit = Math.Round(((vipKart.TimeLimit * 3600 - second) / 3600), 2);
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
                            appDbContext.Cards.Update(vipKart);
                            await appDbContext.SaveChangesAsync();
                        }
                        else
                        {
                            return (Resault: false, Text: "Hosbingiz 0", cassa: null, totalSum);
                        }
                    }
                    else
                    {
                        return (Resault: false, Text: "Bu karta raqami mavjum emas", cassa: null, totalSum);
                    }
                }

                if (GlobalVariable.StopId == 0 && check == 1)
                {
                    var userEmpolyee = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == GlobalVariable.UserId);

                    if (userEmpolyee is not null)
                    {
                        Cassa cassa = new Cassa();
                        cassa.UserName = userEmpolyee.Name;
                        cassa.BarProductPrice = pingPongTable.BarSum;
                        cassa.SumPrice = totalSum.ToString();
                        cassa.TablePrice = totalSum - pingPongTable.BarSum;
                        cassa.Check = $"{pingPongTable.AccountBook}\n";
                        cassa.Check += accountBook;
                        cassa.TypeOfPrice = typeOfPey;
                        cassa.DateTime = DayHelper.GetCurrentServerDay();


                        accountBook = cassa.Check;
                        appDbContext.Cassas.Add(cassa);
                        var resault = await appDbContext.SaveChangesAsync();

                    }
                }
                else
                {
                    pingPongTable.TransferTime += transferTime;
                }
                return (Resault: true, Text: accountBook, cassa: pingPongTable, totalSum: totalSum);
            }
            catch
            {
                return (Resault: false, Text: "", cassa: null, totalSum: 0);
            }
        }

        public async Task<bool> TransferCreateAsync(int id, DesktopCassa cassa, double totalPrice)
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
                resaultId.BarSum = 0;
                resaultId.TransferSum = totalPrice;
                resaultId.TimeAccount = 0;
                resaultId.UserId = cassa.UserId;
                resaultId.TransferTime = cassa.TransferTime;
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
                cassa.TransferTime = 0;

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
